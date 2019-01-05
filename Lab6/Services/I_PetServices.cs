using Lab6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6.Services
{
    public interface I_PetServices
    {
        //Determine pet's daily shopkeep ability (buying/selling bonuses)
        int GenerateDailyShopAbility(Pet pet);
        int GenerateDailyShopAbility(Pet pet, DateTime daySeed);
    }
}
