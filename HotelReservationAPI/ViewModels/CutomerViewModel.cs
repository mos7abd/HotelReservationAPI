namespace HotelReservationAPI.ViewModels
{
    public class CutomerViewModel
    {
        public Guid UID { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime? LastReservationDate { get; set; }
        public string Mobile { get; set; }

        public string Country { get; set; }
        public string City { get; set; }

        public string Address { get; set; }

    }
}
