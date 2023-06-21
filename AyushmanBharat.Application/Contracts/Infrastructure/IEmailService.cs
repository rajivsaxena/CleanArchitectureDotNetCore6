using AyushmanBharat.Application.Models;

namespace AyushmanBharat.Application.Contracts.Infrastructure
{
    public interface IEmailService
    {
        Task<bool> SendEmailAsync(Email email);
    }
}
