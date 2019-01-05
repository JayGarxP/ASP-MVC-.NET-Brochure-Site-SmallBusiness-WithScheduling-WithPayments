using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab6.Models;
using System.Web.Mvc;

namespace Lab6.Data
{
    public interface DatabaseAccessI
    {
        List<User> GetAllUsers();
        List<User> GetAllUsers(string username);
        List<SelectListItem> GetListItemofUsersCash(string username);
        void AddNewUser(User person);
        User GetAUserByID(int id);
        void UpdateUser(User id);
        void RemoveUser(User id);
        double BuyPet(double cost, int UzerID);
        

        List<Pet> GetAllPets();
        //Get list of all pets that belong to given ApplicationUser ' username
        List<Pet> GetAllPets(string username);
        void AddNewPet(Pet newPet);
        Pet GetAPetByID(int id);
        void UpdatePet(Pet id);
        void RemovePet(Pet id);


        double GetAccountTotalCash(string username);
        int GetNumberofEmployees(string username);
        int GetAccountTotalPets(string username);
    }
}
