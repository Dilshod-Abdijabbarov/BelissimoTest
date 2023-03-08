using Domian.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

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
