using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Entity.Context;

namespace WebApi.Controllers
{
    public class FoldersController : ApiController
    {
        [HttpGet]
        public object Get()
        {
            using (BusinessContext context = new BusinessContext())
            {
                var folders = context.Folders
                    .Select(f => new
                    {
                        Id = f.Id,
                        Name = f.Name,
                        ParentId = f.ParentId
                    })
                    .ToList();

                return folders;
            }
        }
    }
}