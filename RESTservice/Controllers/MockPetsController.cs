using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using RESTservice.Models;
using RESTservice.Services;

namespace RESTservice.Controllers
{
    public class MockPetsController : ApiController
    {

        //Use the data respository you created in the Web application to access your entity data.  
        //In a "real" application you would use dependency injection to inject a instance of the repository into your service controller.  You can do that if you want or you can just "new" an instance in your controller.

        //pet lookup similar to products; get general info about pets.
        private I_MockPetServices _mockpetService = new MockPetServices();

        //[HttpGet]
        public MockPet Get(string nickname, string species, string colour)
        {
            return new MockPet
            {
                NickName = nickname,
                Species = species,
                Color = colour,
                merchantAbility = _mockpetService.GenMerchantAbility(nickname, species, colour),
                PwrLvl = _mockpetService.GenPwrLevel(nickname, species)
            };
        }

        [Route("api/random/name")]
        [HttpGet]
        public string GenNickname()
        {
            Random random = new Random();

            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            int nameSize = random.Next(2, 12);
            var stringChars = new char[nameSize];

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);

            return finalString;
        }


        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }

        //public IHttpActionResult PetPwrbyNickName(string nickname)
        //{
        //    int petPwrLvl = -1;
        //    DateTime today = DateTime.Now;
        //    if (today.DayOfWeek == DayOfWeek.Saturday)
        //    {
        //        petPwrLvl = 777;
        //    }
        //    else { petPwrLvl = 111; }

        //    IHttpActionResult response;
        //    //we want a 303 with the ability to set location
        //    HttpResponseMessage responseMsg = new HttpResponseMessage(HttpStatusCode.RedirectMethod);
        //    responseMsg.Headers.Location = new Uri("http://customLocation.blah");
        //    response = ResponseMessage(responseMsg);
        //    return response;
        //}
    }
}