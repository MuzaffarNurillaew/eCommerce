using eCommerce.Domain.Configurations;
using eCommerce.Domain.Entities.Chats;
using eCommerce.Service.Dtos.Chats;
using eCommerce.Service.Interfaces;
using System.Linq.Expressions;

namespace eCommerce.Service.Services
{
    public class ChatService : IChatService
    {
        public Task<ChatDto> CreateAsync(ChatCreationDto userDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Expression<Func<Chat, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<List<ChatDto>> GetAllAsync(PaginationParams @params, Expression<Func<Chat, bool>> expression = null)
        {
            throw new NotImplementedException();
        }

        public Task<ChatDto> GetAsync(Expression<Func<Chat, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<ChatDto> UpdateAsync(Expression<Func<Chat, bool>> expression, ChatUpdateDto userDto)
        {
            throw new NotImplementedException();
        }
    }
}
