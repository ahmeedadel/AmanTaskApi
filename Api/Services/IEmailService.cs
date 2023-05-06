using Api.DTO;

namespace Api.Services
{
    public interface IEmailService
    {
        void sendEmail(EmailDTO emailDTO);

    }
}
