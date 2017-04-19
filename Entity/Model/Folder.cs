using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entity.Model
{
    public class Folder
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int? ParentId { get; set; }
        public virtual Folder Parent { get; set; }

        public virtual List<File> Files  { get; set; }
    }
}