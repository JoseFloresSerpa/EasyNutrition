using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyNutrition.API.Domain.Models
{
    public class Subscription
    {
        public int Id { get; set; }
        public bool active { get; set; }
        public int maxSessions { get; set; }
        public int price { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

    }
}

