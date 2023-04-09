using eCommerce.Domain.Configurations;

namespace eCommerce.Service.Extensions
{
    public static class CollectionExtension
    {
        public static IQueryable<T> ToPagedList<T>(this IQueryable<T> source, PaginationParams @params)
        {
            int numberOfItemsToSkip = (@params.PageIndex - 1) * @params.PageSize;
            int totalCount = source.Count();

            if (numberOfItemsToSkip >= totalCount && totalCount > 0)
            {
                numberOfItemsToSkip = totalCount - totalCount % @params.PageSize;
            }

            return source.Skip(numberOfItemsToSkip).Take(@params.PageSize);
        }
    }
}
