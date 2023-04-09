using eCommerce.Domain.Configurations;
using eCommerce.Domain.Entities.Chats;
using eCommerce.Service.Dtos.Chats;
using System.Linq.Expressions;

namespace eCommerce.Service.Interfaces
{
    public interface IChatService
    {
        Task<ChatDto> CreateAsync(ChatCreationDto userDto);
        Task<ChatDto> UpdateAsync(Expression<Func<Chat, bool>> expression, ChatUpdateDto userDto);
        Task<bool> DeleteAsync(Expression<Func<Chat, bool>> expression);
        Task<ChatDto> GetAsync(Expression<Func<Chat, bool>> expression);
        Task<List<ChatDto>> GetAllAsync(PaginationParams @params, Expression<Func<Chat, bool>> expression = null);
    }
}
