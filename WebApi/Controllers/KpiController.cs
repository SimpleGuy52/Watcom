using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Entity.Context;
using Entity.Model;

namespace WebApi.Controllers
{
    public class KpiController : ApiController
    {
        [HttpPost]
        public void Update(UpdateParams[] @params)
        {
            using (BusinessContext context = new BusinessContext())
            {
                var kpiRepos = context.Kpies;
                foreach (var p in @params)
                {
                    Kpi kpi = null;
                    if (p.Id == null)
                    {
                        kpi = kpiRepos.Create();
                        kpiRepos.Add(kpi);
                    }
                    else
                        kpi = kpiRepos.First(i => i.Id == p.Id);

                    kpi.Name = p.Name;

                    //var kpi = kpiRepos
                }
                context.SaveChanges();
            }
        }


        [HttpGet]
        public object GetAll()
        {
            using (BusinessContext context = new BusinessContext())
            {
                // todo: need optimization
                var kpies = context.Kpies.ToList().Select(i=>
                {
                    var kpiValues = i.KpiValues.OrderByDescending(j => j.Date);
                    var kpiValueFirst = kpiValues.FirstOrDefault();
                    var kpiValuePrevious = kpiValues.Skip(1).Take(1).FirstOrDefault();
                    var valF = kpiValueFirst?.Value;
                    var valP = kpiValuePrevious?.Value;
                    
                    return new
                    {
                        Id = i.Id,
                        Name = i.Name,
                        Measure = i.Measure.ToString(),
                        Value = valF,
                        PreviousValue = valP
                    };
                })
                .ToList();

                return kpies;
            }
        }


        [HttpGet]
        public object GetPage()
        {
            using (BusinessContext context = new BusinessContext())
            {
                var kpiPage = context.Pages.First(i => i.Name == "KPI");
                var page = kpiPage.Value;

                return new
                {
                    IsSuccess = true,
                    value = page
                };
            }
        }
    }

    public class UpdateParams
    {
        public int? Id { get; set; } 
        public string Name { get; set; } 
    }
}