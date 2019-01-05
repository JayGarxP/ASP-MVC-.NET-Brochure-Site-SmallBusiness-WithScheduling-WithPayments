using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace RESTclient
{

    //https://www.asp.net/web-api/overview/advanced/calling-a-web-api-from-a-net-client
    class Program
    {
        static HttpClient client = new HttpClient();

        static void ShowPet(MockPet pet)
        {
            Console.WriteLine($"Name: {pet.NickName}");
        }

        static async Task<string> GetPetAsync()
        {
            string name = null;
            HttpResponseMessage response = await client.GetAsync("api/random/name");
            if (response.IsSuccessStatusCode)
            {
                name = await response.Content.ReadAsAsync<string>();
            }
            return name;
        }
        //static async Task<MockPet> GetPetAsync(string path)
        //{
        //    MockPet pet = null;
        //    HttpResponseMessage response = await client.GetAsync(path);
        //    if (response.IsSuccessStatusCode)
        //    {
        //        pet = await response.Content.ReadAsAsync<MockPet>();
        //    }
        //    return pet;
        //}


        static void Main()
        {
            RunAsync().Wait();
        }

        static async Task RunAsync()
        {
            client.BaseAddress = new Uri("http://localhost:7916/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //make pet
            MockPet pat = new MockPet { Color ="blu", NickName ="init", merchantAbility=0, PwrLvl=0,Species="client" };
            ShowPet(pat);

            Console.WriteLine("  New nickname: ");

            //get pet api url
            pat.NickName = GetPetAsync().Result;
            
            ShowPet(pat);

            Console.ReadLine();
        }


    }
}