using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyNutrition.API.Resources
{
    public class SaveScheduleResource
    {



        public string startAt { get; set; }

        public string endAt { get; set; }

        public bool state { get; set; }

        public int UserId { get; set; }




    }
}
