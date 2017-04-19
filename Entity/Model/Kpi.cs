using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entity.Model
{
    public class Kpi
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public KpiMeasure Measure { get; set; }

        public virtual List<KpiValue> KpiValues { get; set; }

    }

    public enum KpiMeasure
    {
        Human,
        Minute,
        Percent
    }
}