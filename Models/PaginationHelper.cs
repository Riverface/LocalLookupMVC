using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LocalLookupMVC.Models
{
    public static class PaginationHelper
    {
        public static IQueryable<Object> GetPaged(IQueryable<Object> businessQuery, int page, int pageSize = 1)
        {
            int TotalCount = businessQuery.Count();
            double pageCount = (int)Math.Ceiling(Convert.ToDouble(TotalCount) / pageSize);
            int Skip = (page - 1) * pageSize;
            IQueryable<Object> Results = (page > 0) ? businessQuery.Skip((page - 1) * pageSize).Take(pageSize) : businessQuery;
            return Results;
        }
    }
}