using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyNutrition.API.Domain.Models
{
    public class Session
    {
        public int Id { get; set; }

        public string Start { get; set; }

        public string End { get; set; }

        public string Link { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }
    }
}
