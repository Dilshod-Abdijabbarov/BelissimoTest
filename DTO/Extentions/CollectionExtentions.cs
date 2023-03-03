using Domian.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Services.Extentions
{
    public static class CollectionExtentions
    {
        public static IQueryable<T> ToPagedList<T>(this IQueryable<T> source, PaginationParams @params)
        {

            return source.Skip((@params.PageIndex - 1) * @params.PageSize)
                  .Take(@params.PageSize);

            //var value = (@params.PageIndex - 1) * @params.PageSize;

            //return @params.PageIndex > 0 && @params.PageSize >= 0
            //    ? source.Take(value..(value + @params.PageSize)) : source;

        }
    }
}
