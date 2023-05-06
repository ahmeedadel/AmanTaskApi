using Api.DTO;

namespace Api.Services
{
    public interface IMessageService
    {
        void AddMessageToRepo(AddMessageDTO messageDTO);
        void DeleteMessage(int id);
    }
}
