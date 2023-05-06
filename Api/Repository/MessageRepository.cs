using Api.Models;

namespace Api.Repository
{
    public class MessageRepository : IMessageRepository
    {
        private readonly EmailSenderDBContext DB;

        public MessageRepository(EmailSenderDBContext DB)
        {
            this.DB = DB;
        }

        public Message AddMessageToDB(Message message)
        {
            DB.Messages.Add(message);
            DB.SaveChanges();
            return message;
        }

        public List<Message> GetAllMessagesFromDB()
        {
            return DB.Messages.ToList();

        }

        public Message RemoveMessageFromDB(int id)
        {
            var message = DB.Messages.Find(id);
            DB.Messages.Remove(message);
            DB.SaveChanges();
            return message;
        }
    }
}
