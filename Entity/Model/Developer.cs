using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entity.Model
{
    public class Developer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Car> Cars { get; set; }
    }
}