namespace HotelReservationAPI.ViewModels.Users
{
    public class AddUserViewModel
    {
        public string FristName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}
