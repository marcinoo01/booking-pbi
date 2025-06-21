using Booking.SharedKernel.Requests;
using FluentValidation;

namespace Booking.Application.Validators
{
    public class CreateReservationRequestValidator : AbstractValidator<CreateReservationRequest>
    {
        public CreateReservationRequestValidator()
        {
            RuleFor(x => x.UserId).GreaterThan(0);
            RuleFor(x => x.ServiceId).GreaterThan(0);
            RuleFor(x => x.AppointmentSlotId).GreaterThan(0);
        }
    }
}