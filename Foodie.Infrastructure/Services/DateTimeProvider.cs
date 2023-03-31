using Foodie.Application.Common.Interfaces.Services;

namespace Foodie.Infrastructure.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}
