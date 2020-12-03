
namespace PruebaTecnica.Core.Entities
{
    using System;
    using System.Collections.Generic;

    public partial class Gender
    {
        public Gender()
        {
        }

        public int GenderId { get; set; }
        public string Name { get; set; }
        public DateTime? Date { get; set; }

        
    }
}
