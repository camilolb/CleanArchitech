using System;
using System.Collections.Generic;

#nullable disable

namespace PruebaTecnica.Core.Entities
{
    public partial class Movie
    {
        public int MovieId { get; set; }
        public int GenderId { get; set; }
        public int CountryId { get; set; }
        public int ActorId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? Date { get; set; }

        public virtual Actor Actor { get; set; }
        public virtual Country Country { get; set; }
        public virtual Gender Gender { get; set; }
    }
}
