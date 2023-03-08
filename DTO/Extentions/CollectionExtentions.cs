using Domian.Configurations;

namespace Services.Extensions
{
    public static class CollectionExtentions
    {
        public static IQueryable<T> ToPagedList<T>(this IQueryable<T> source, PaginationParams @params)
        {
            return source.Skip((@params.PageIndex - 1) * @params.PageSize)
                  .Take(@params.PageSize);
        }
    }
}
