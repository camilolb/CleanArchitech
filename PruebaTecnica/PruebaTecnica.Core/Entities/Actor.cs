using System;
using System.Collections.Generic;

namespace PruebaTecnica.Core.Entities
{
    public partial class Actor
    {
        public Actor()
        {
        }

        public int ActorId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int CountryId { get; set; }
        public DateTime? Date { get; set; }

        
        
    }
}
