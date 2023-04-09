using eCommerce.Domain.Commons;
using eCommerce.Domain.Entities.Chats;
using eCommerce.Service.Dtos.Users;

namespace eCommerce.Service.Dtos.Chats
{
    public class ChatDto:Auditable
    {
        public UserDto FirstUser { get; set; }
        public UserDto SecondUser { get; set; }
        public ICollection<Message> Messages { get; set; }
    }
}
