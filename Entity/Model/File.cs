using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entity.Model
{
    public class File
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public FileExtension Extension { get; set; }

        public int FolderId { get; set; }
        public virtual Folder Folder { get; set; }
    }

    public enum FileExtension
    {
        Txt,
        Pdf,
        Js
    }
}