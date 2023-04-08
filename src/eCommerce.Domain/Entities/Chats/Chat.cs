using eCommerce.Domain.Commons;
using eCommerce.Domain.Entities.Users;

namespace eCommerce.Domain.Entities.Chats
{
    public class Chat : Auditable
    {
        public long FirstUserId { get; set; }
        public User FirstUser { get; set; }

        public long SecondUserId { get; set; }
        public User SecondUser { get; set; }
    }
}
