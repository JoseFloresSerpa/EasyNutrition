using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyNutrition.API.Domain.Models
{
    public class SessionDetail
    {

        public int Id { get; set; }

        public string State { get; set; }

        public int SessionId { get; set; }

        public Session Session { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public IList<Session> Sessions { get; set; } = new List<Session>();
    }
}
