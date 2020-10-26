using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyNutrition.API.Domain.Models
{
    public class Experience
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public IList<Complaint> Complaints { get; set; } = new List<Complaint>();

    }

}
