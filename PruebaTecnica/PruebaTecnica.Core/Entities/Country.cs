
namespace PruebaTecnica.Core.Entities
{
    using System;
    using System.Collections.Generic;

    public partial class Country
    {
        public Country()
        {
        }

        public int ContryId { get; set; }
        public string Name { get; set; }
        public DateTime? Date { get; set; }

    }
}
