using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RESTservice.Services
{
    public class MockPetServices : I_MockPetServices
    {
        public int GenMerchantAbility(string nickname, string species, string colour)
        {
            int petMerchLvl = -1;
            DateTime today = DateTime.Now;
            if (today.DayOfWeek == DayOfWeek.Wednesday)
            {
                petMerchLvl = 7;
            }
            else { petMerchLvl = 11; }

            return petMerchLvl;
        }

        public int GenPwrLevel(string nickname, string species)
        {
            int petPwrLvl = -1;
            DateTime today = DateTime.Now;
            if (today.DayOfWeek == DayOfWeek.Saturday)
            {
                petPwrLvl = 777;
            }
            else { petPwrLvl = 111; }

            return petPwrLvl;
        }
    }
}