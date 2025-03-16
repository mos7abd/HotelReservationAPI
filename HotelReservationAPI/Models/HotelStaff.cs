namespace HotelReservationAPI.Models
{
    public class HotelStaff : BaseModel
    {
        public decimal Salary { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }

    }
}
