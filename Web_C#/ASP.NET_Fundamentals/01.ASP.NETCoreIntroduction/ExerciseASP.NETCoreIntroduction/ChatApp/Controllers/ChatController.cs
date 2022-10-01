namespace ChatApp.Controllers
{
    using ChatApp.Models;
    using Microsoft.AspNetCore.Mvc;

    public class ChatController : Controller
    {
        private static List<KeyValuePair<string, string>> Messages = new List<KeyValuePair<string, string>>();

        [HttpGet]
        public IActionResult Show()
        {
            if (Messages.Count < 1)
            {
                return View(new ChatViewModel());
            }
            ChatViewModel chatModel = new()
            {
                Messages = Messages.Select(m => new MessageViewModel
                {
                    Sender = m.Key,
                    MessageText = m.Value
                })
                .ToList()
            };

            return View(chatModel);
        }

        [HttpPost]
        public IActionResult Send(ChatViewModel chat)
        {
            MessageViewModel newMessage = chat.CurrentMessage;
            Messages.Add(new KeyValuePair<string, string>(newMessage.Sender, newMessage.MessageText));

            return RedirectToAction("Show");
        }
    }
}
