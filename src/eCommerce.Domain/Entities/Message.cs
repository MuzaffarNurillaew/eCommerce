using eCommerce.Domain.Commons;

namespace eCommerce.Domain.Entities
{
    public class Message : Auditable
    {
        public string Content { get; set; }
        public long? RepliedMessageId { get; set; }
        public Message RepliedMessage { get; set; }
    }
}
