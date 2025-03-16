using FluentValidation;
using HotelReservationAPI.Dtos.Customers;
using HotelReservationAPI.Dtos.Users;
using HotelReservationAPI.Enum;
using HotelReservationAPI.Exceptions;
using HotelReservationAPI.Helper;
using HotelReservationAPI.Models;
using HotelReservationAPI.Services;
using HotelReservationAPI.Validators.Users;
using HotelReservationAPI.ViewModels;
using HotelReservationAPI.ViewModels.Users;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservationAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly CustomerService _customerService;

        private readonly IValidator<AddUserViewModel> _addUserViewModelValidator;

        public UserController(CustomerService customerService)
        {
            _userService = new UserService();
            _customerService = new CustomerService();
            _addUserViewModelValidator = new AddUserViewModelValidator();
        }

        [HttpPost("register")]
        public async Task<ResponseViewModel<bool>> Register([FromBody] AddUserViewModel addUserViewModel)
        {
            var validationResult = _addUserViewModelValidator.Validate(addUserViewModel);
            if (validationResult.IsValid is false)
            {
                throw new RequstValidationException(validationResult);
            }
            var isEmailExist = await _userService.IsEmailExist(addUserViewModel.Email);
            if (isEmailExist is true)
            {
                return ResponseViewModel<bool>.Failure(ErrorCode.UserEmailExist, "Email already exist");
            }


            var newUserDto = addUserViewModel.Map<AddUserDto>();
            newUserDto.Role = Role.Customer;
            var userId = await _userService.AddAsync(newUserDto);
            if (userId == 0)
            {
                return ResponseViewModel<bool>.Failure(ErrorCode.UserNotAdded, "User not added");
            }

            var newCustomerDto = new AddCustomerDto
            {
                UserId = userId
            };

            var customerId = await _customerService.AddAsync(newCustomerDto);

            if (customerId == 0)
            {
                return ResponseViewModel<bool>.Failure(ErrorCode.CustomerNotAdded, "Customer not added");
            }
            return ResponseViewModel<bool>.Sucess(true);
        }




    }
}
