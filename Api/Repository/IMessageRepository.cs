using Api.Models;

namespace Api.Repository
{
    public interface IMessageRepository
    {
        List<Message> GetAllMessagesFromDB();
        Message AddMessageToDB(Message message);
        Message RemoveMessageFromDB(int id);
    }
}
