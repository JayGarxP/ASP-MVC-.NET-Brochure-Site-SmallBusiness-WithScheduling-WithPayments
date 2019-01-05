using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab6.Models;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Web.Mvc;

namespace Lab6.Data
{
    public class DatabaseAccess : DatabaseAccessI
    {
        private readonly ApplicationDbContext _databaseContext;
        //Does this need context in each controller?
        protected UserManager<ApplicationUser> _UserManager { get; set; }

        public DatabaseAccess() : base()
        {
            //DBContext is the Entity framework auto-genned database
            _databaseContext = new ApplicationDbContext();
            _UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_databaseContext));
        }


        public List<User> GetAllUsers()
        {
            return _databaseContext.CustomUsers.ToList();

        }
        public List<User> GetAllUsers(string username)
        {
            var usersAccounts = _databaseContext.CustomUsers
                  .Where(uza => uza.creator == username)
                  .ToList();
            return usersAccounts;
        }

        //For Pet's dropdown buy menu; this should be in own ViewModel 
        public List<SelectListItem> GetListItemofUsersCash(string username)
        {
            List<SelectListItem> UserCash = new List<SelectListItem>();
            foreach (var uza in GetAllUsers(username))
            {
                UserCash.Add(new SelectListItem { Text = uza.FirstName + " " + uza.MyWealth.Cash.ToString(),
                    Value = uza.PersonID.ToString() });
            }
            
            return UserCash;
        }

        public void AddNewUser(User user)
        {
            if (user.MyPets != null)
            {
                foreach (var aPet in user.MyPets)
                {
                    _databaseContext.Pets.Attach(aPet);
                }
            }
            _databaseContext.CustomUsers.Add(user);
            _databaseContext.SaveChanges();
        }

        public User GetAUserByID(int id)
        {
            return _databaseContext.CustomUsers.Find(id);
        }

        public void UpdateUser(User uza)
        {
            _databaseContext.Entry(uza).State = EntityState.Modified;
            _databaseContext.SaveChanges();
        }

        public void RemoveUser(User uza)
        {
            _databaseContext.CustomUsers.Remove(uza);
            _databaseContext.SaveChanges();
        }

        public double BuyPet(double cost, int CustUserID)
        {
            User victim = GetAUserByID(CustUserID);
            victim.MyWealth.Cash = victim.MyWealth.Cash - cost;
            return victim.MyWealth.Cash;
        }



        /// <summary>
        /// Could bump out models DB Access into seperate implementations or
        /// seperate interface&implementations
        /// </summary>
        /// <returns></returns>
        public List<Pet> GetAllPets()
        {
            return _databaseContext.Pets.ToList();
        }

        public void AddNewPet(Pet newPet)
        {
            if (newPet.Users != null)
            {
                foreach (var uza in newPet.Users)
                {
                    _databaseContext.CustomUsers.Attach(uza);
                }
            }
            _databaseContext.Pets.Add(newPet);
            _databaseContext.SaveChanges();
        }

        public Pet GetAPetByID(int id)
        {
            return _databaseContext.Pets.Find(id);
        }

        public void UpdatePet(Pet pyet)
        {
            _databaseContext.Entry(pyet).State = EntityState.Modified;
            _databaseContext.SaveChanges();
        }

        public void RemovePet(Pet pyet)
        {
            _databaseContext.Pets.Remove(pyet);
            _databaseContext.SaveChanges();
        }

        public List<Pet> GetAllPets(string username)
        {
            var usersPets = _databaseContext.Pets
                  .Where(pat => pat.Creator == username)
                  .ToList();
            return usersPets;
        }

        public double GetAccountTotalCash(string username)
        {
            double totalCash = 0;
            var Allusers = GetAllUsers(username);
            foreach (var uza in Allusers)
            {
                totalCash += uza.MyWealth.Cash;
            }
            return totalCash;
        }

        public int GetNumberofEmployees(string username)
        {
            return GetAllUsers(username).Count;
        }

        public int GetAccountTotalPets(string username)
        {
            //Technically Users can jointly own a single pet, even across multiple ApplicationUser accounts
            return GetAllPets(username).Count;

            //var Allusers = GetAllUsers(username);
            //foreach (var uza in Allusers)
            //{
            //    uza.MyPets.Count /// etc. etc.
            //}
        }
    }
}