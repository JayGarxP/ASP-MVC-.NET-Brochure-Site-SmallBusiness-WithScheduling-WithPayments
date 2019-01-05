using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab6.Models;

namespace Lab6.Services
{
    public class PetServices : I_PetServices
    {

        ////HOW Do I make this class handle its use of DateTime better? mocking; see 'Moq'
        ////Research: https://blogs.msdn.microsoft.com/ploeh/2007/05/12/testing-against-the-current-time/
        ////Research: http://stackoverflow.com/questions/2425721/unit-testing-datetime-now

        //DateTime seedTime = DateTime.Now //NOT compile-time constant! //Too dumb to figure out provider injection pattern w/o framework
        public int GenerateDailyShopAbility(Pet pet, DateTime today)
        {
            //Random rnd = new Random();
            int merchantAbility = -1;
            
            //Later will make it so NickName and a random seed will influence
            //merchant ability for each day of week
            //rnd.Next(1, 252);
            if (today.DayOfWeek == DayOfWeek.Saturday)
            {
                merchantAbility = 777;
            }

            return merchantAbility;
        }


        public int GenerateDailyShopAbility(Pet pet)
        { 
            int merchantAbility = -6;

            //I want provider injection HERE to make each pet have its own special day and to make testing easier
            DateTime today = DateTime.Now;
            if (today.DayOfWeek == DayOfWeek.Saturday)
            {
                merchantAbility = 777;
            }

            return merchantAbility;
        }
    }
}