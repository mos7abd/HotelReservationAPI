using HotelReservationAPI.Dtos.Reservations;
using HotelReservationAPI.Helper;
using HotelReservationAPI.Models;
using HotelReservationAPI.Repositoried;
using Microsoft.EntityFrameworkCore;

namespace HotelReservationAPI.Services
{
    public class ReservationService
    {
        private readonly GeneralRepository<Reservation> _reservationRepository;
        public ReservationService()
        {
            _reservationRepository = new GeneralRepository<Reservation>();
        }


        public async Task<GetReservationIdDto> GetByIdAsync(int id)
        {
            var reservation = await _reservationRepository.GetByIDAsync(id);
            return reservation.Map<GetReservationIdDto>();
        }

        public async Task<int> AddAsync(AddReservationDto addReservationDto)
        {
            var newReservation = addReservationDto.Map<Reservation>();
            int newReservationId = await _reservationRepository.AddAsync(newReservation);
            return newReservationId;
        }


        public void Update(UpdateReservationDto updateReservationDto)
        {
            var updatedReservation = updateReservationDto.Map<Reservation>();
            _reservationRepository.Update(updatedReservation);
        }


        public async Task<bool> IsExistsAsync(int id)
        {
            bool IsreservationExists = await _reservationRepository.Get(R => R.ID == id).AnyAsync();

            return IsreservationExists;
        }

        public async Task<bool> IsRoomReservedAsync(int roomId, DateTime checkInDateTime, DateTime checkOutDateTime)
        {
            var isRoomReserved = await _reservationRepository
                .Get(R => R.RoomId == roomId && R.CheckIn < checkOutDateTime && R.CheckOut > checkInDateTime).AnyAsync();
            return isRoomReserved;
        }


        public async Task<bool> CancelAsync(int id)
        {
            Reservation reservation = new();

            reservation.Status = ReservationStatus.Canceled;
            reservation.CanceledAt = DateTime.UtcNow;
            _reservationRepository.UpdateInclude(reservation, nameof(Reservation.Status), nameof(reservation.CanceledAt));
            return true;
        }
    }
}
