using Bogus;
using HotelReservationAPI.ViewModels;

namespace HotelReservationAPI.Services
{
    public class CustomerFakeDataService
    {
        Faker<CutomerViewModel> _faker;

        public CustomerFakeDataService()
        {
            _faker = new Faker<CutomerViewModel>()
                .RuleFor(c => c.UID, f => f.Random.Guid())
                .RuleFor(c => c.ID, f => f.IndexFaker + 1)
                .RuleFor(c => c.Name, f => f.Name.FullName())
                .RuleFor(c => c.Birthdate, f => f.Date.Past(50, new DateTime(1970, 1, 1)))
                .RuleFor(c=> c.LastReservationDate, f => f.Date.Between(new DateTime(2010,1,1), new DateTime(2025,1,1)))
                .RuleFor(c=>c.Country, f => f.Address.County())
                .RuleFor(c => c.City, f => f.Address.City())
                .RuleFor(c=>c.Address, f => f.Address.StreetAddress());
        }

        public IEnumerable<CutomerViewModel> GetData()
        {
            return _faker.GenerateLazy(50);
        }
    }
}
