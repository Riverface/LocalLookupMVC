using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Viewer.Models
{
    public static class PaginationHelper
    {
        public static IQueryable<Object> GetPaged(IQueryable<Object> characterQuery, int page, int pageSize = 1)
        {
            int TotalCount = characterQuery.Count();
            double pageCount = (int)Math.Ceiling(Convert.ToDouble(TotalCount) / pageSize);
            int Skip = (page - 1) * pageSize;
            IQueryable<Object> Results = (page > 0) ? characterQuery.Skip((page - 1) * pageSize).Take(pageSize) : characterQuery;
            return Results;
        }
    }
}