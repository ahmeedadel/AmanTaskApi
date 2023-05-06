using Api.DTO;
using Api.Repository;
using Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageRepository messageRepo;
        private readonly IMessageService messageService;

        public MessagesController(IMessageRepository messageRepo, IMessageService messageService)
        {
            this.messageRepo = messageRepo;
            this.messageService = messageService;
        }



        [HttpGet]
        public ActionResult GetAllMessages()
        {
            var messagesList = messageRepo.GetAllMessagesFromDB();
            if (messagesList == null)
                return NotFound();

            return Ok(messagesList);
        }


        [HttpPost]
        public ActionResult AddMessage(AddMessageDTO messageDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            messageService.AddMessageToRepo(messageDTO);
            var messagesList = messageRepo.GetAllMessagesFromDB();
            return Created("Added successfully", messagesList);
        }

        [HttpDelete]
        public ActionResult DeleteMessage(int id)
        {
            if (id == null)
                return BadRequest();

            messageService.DeleteMessage(id);
            var messagesList = messageRepo.GetAllMessagesFromDB();
            return Created("Removed successfully", messagesList);

        }
    }
}
