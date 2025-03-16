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
        UserService _userService;
        CustomerService _customerService;

        IValidator<AddUserViewModel> _addUserViewModelValidator;
        IValidator<LoginViewModel> _LoginViewModelValidator;

        public UserController()
        {
            _userService = new UserService();
            _customerService = new CustomerService();

            _addUserViewModelValidator = new AddUserViewModelValidator();
            _LoginViewModelValidator = new LoginViewModelValidator();
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

        [HttpPost("login")]
        public async Task<ResponseViewModel<string>> Login([FromBody] LoginViewModel loginViewModel)
        {
            var validationResult = _LoginViewModelValidator.Validate(loginViewModel);
            if (validationResult.IsValid is false)
            {
                throw new RequstValidationException(validationResult);
            }

            var user = await _userService.GetUserByEmailAsync(loginViewModel.Email);

            if (user == null || user.Password != loginViewModel.Password)
            {
                return ResponseViewModel<string>.Failure(ErrorCode.Unauthorized, "Invalid email or password");
            }

            var token = TokenGeneratorHelper.GenerateToken(user.Email, $"{user.FristName} {user.LastName}", user.Role.ToString());

            return ResponseViewModel<string>.Sucess(token);
        }




    }
}
