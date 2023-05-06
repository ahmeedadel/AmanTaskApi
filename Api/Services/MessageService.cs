using Api.DTO;
using Api.Models;
using Api.Repository;

namespace Api.Services
{
    public class MessageService : IMessageService
    {

        private readonly IMessageRepository messageRepo;

        public MessageService(IMessageRepository messageRepo)
        {
            this.messageRepo = messageRepo;
        }


        public void AddMessageToRepo(AddMessageDTO messageDTO)
        {
            var message = new Message()
            {
                Subject = messageDTO.Subject,
                MessageContent = messageDTO.MessageContent,
            };
            messageRepo.AddMessageToDB(message);
        }

        public void DeleteMessage(int id)
        {
            messageRepo.RemoveMessageFromDB(id);
        }

    }
}
