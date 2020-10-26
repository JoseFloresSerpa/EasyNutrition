using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace EasyNutrition.API.Resources
{
    public class SaveSubscriptionResource
    {
      
        public bool active { get; set; }
        public int maxSessions { get; set; }
        public int price { get; set; }



    }
}
