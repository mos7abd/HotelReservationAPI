namespace HotelReservationAPI.Dtos.Customers
{
    public class GetCustomerByIdDto
    {
        public int Id { get; set; }
        public string FristName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}
