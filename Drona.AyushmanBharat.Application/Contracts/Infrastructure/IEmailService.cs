using Drona.AyushmanBharat.Application.Models;

namespace Drona.AyushmanBharat.Application.Contracts.Infrastructure
{
    public interface IEmailService
    {
        Task<bool> SendEmailAsync(Email email);
    }
}
