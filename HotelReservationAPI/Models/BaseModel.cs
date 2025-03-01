namespace HotelReservationAPI.Models
{
    public class BaseModel
    {
        public int ID { get; set; }
        public bool Deleted { get; set; } = false;
        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
       
    }
}
