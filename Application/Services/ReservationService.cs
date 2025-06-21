using Booking.Domain.Entities;
using Booking.Domain.Interfaces;
using Booking.SharedKernel.Requests;

namespace Booking.Application.Services
{
    public class ReservationService
    {
        private readonly IUnitOfWork _uow;
        public ReservationService(IUnitOfWork uow) => _uow = uow;

        public async Task<Reservation> BookAsync(CreateReservationRequest req)
        {
            var slot = await _uow.AppointmentSlots.GetByIdAsync(req.AppointmentSlotId)
                       ?? throw new InvalidOperationException("Slot not found");
            if (slot.IsInPast() || slot.IsReserved)
                throw new InvalidOperationException("Slot not available");

            var reservation = new Reservation(req.UserId, req.ServiceId, req.AppointmentSlotId);
            slot.MarkReserved();
            await _uow.Reservations.AddAsync(reservation);
            await _uow.SaveChangesAsync();
            return reservation;
        }

        public async Task CancelAsync(int reservationId)
        {
            var res = await _uow.Reservations.GetByIdAsync(reservationId)
                      ?? throw new InvalidOperationException("Reservation not found");
            var slot = await _uow.AppointmentSlots.GetByIdAsync(res.AppointmentSlotId);
            slot?.MarkAvailable();
            _uow.Reservations.Delete(res);
            await _uow.SaveChangesAsync();
        }
    }

}