using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab6.Models;
using Lab6.Services;

namespace SBP_TestSuite
{
    using NUnit.Framework;

    [TestFixture]
    public class PetServicesTests
    {
        private I_PetServices _petService;


        [SetUp]
        public void SetUp()
        {
            _petService = new PetServices();
        }

        //Tests if Merchant ability is set correctly on Saturday using default service
        [Test]
        public void DefaultMerchantAbilityToSevensOnSaturdayTest()
        {
            Pet MimiKyu = new Pet();

            int finalResult = 0;

            if (DateTime.Now.DayOfWeek == DayOfWeek.Saturday)
            {
                finalResult = 777;
            }
            else
            {
                finalResult = -6;
            }

            MimiKyu.MerchantSkill = _petService.GenerateDailyShopAbility(MimiKyu);

            Assert.AreEqual(finalResult, MimiKyu.MerchantSkill);
        }


        //Tests if seededDatetimes set Merchant Ability correctly.
        // /How test edge cases / time-zone differences across server???
        [Test]
        public void SeededMerchantAbilityTest()
        {
            Pet Totodile_SAT = new Pet();
            DateTime SaturdaySeed = new DateTime(2016, 11, 5);

            Pet Larvitar_SUN = new Pet();
            DateTime SundaySeed = new DateTime(2016, 11, 6);

            int SaturdayResult = 777;
            int nonSaturdayResult = -1;

            Totodile_SAT.MerchantSkill = _petService.GenerateDailyShopAbility(Totodile_SAT, SaturdaySeed);
            Larvitar_SUN.MerchantSkill = _petService.GenerateDailyShopAbility(Larvitar_SUN, SundaySeed);

            Assert.AreEqual(SaturdayResult, Totodile_SAT.MerchantSkill);
            Assert.AreEqual(nonSaturdayResult, Larvitar_SUN.MerchantSkill);

        }

    }
}
