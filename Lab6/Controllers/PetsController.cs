using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Lab6.Models;
using Lab6.Data;
using Lab6.App_Start;
using Lab6.Services;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Lab6.Controllers
{
    [Authorize]
    public class PetsController : Controller
    {
        private readonly DatabaseAccessI _dataRepository;
        private readonly I_PetServices _petServices;

        public PetsController(DatabaseAccessI dataRepository, I_PetServices petServices)
        {
            _dataRepository = dataRepository;
            _petServices = petServices;
        }

        // GET: Pets; 
        public ActionResult Index()
        {
            var petz = _dataRepository.GetAllPets(System.Web.HttpContext.Current.User.Identity.GetUserName());
            return View(petz);
        }

        // GET: Pets/Details/5 Set today's merchant skill for pet
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pet pet = _dataRepository.GetAPetByID(id.Value);
            pet.MerchantSkill = _petServices.GenerateDailyShopAbility(pet);

            if (pet == null)
            {
                return HttpNotFound();
            }
            return View(pet);
        }

        // GET: Pets/Create
        public ActionResult Create()
        {
            string usrname = System.Web.HttpContext.Current.User.Identity.GetUserName();

            var pets = _dataRepository.GetAllPets(usrname);
            ViewBag.GroupList = new MultiSelectList(pets, "PetID", "Nickname");
            ViewBag.UserCashDD = _dataRepository.GetListItemofUsersCash(usrname);
            return View();
        }

        // POST: Pets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PetID,NickName")] Pet pet,
            List<int>UserIds, string CustomUserID)
        {
           //string giveUP = Request.Form.ToString();
            string []UserDDForm = Request.Form.GetValues("UserCashDD");
            string[] SpeciesDDForm = Request.Form.GetValues("petClickedID");

            if (ModelState.IsValid)
            {
                string creator = System.Web.HttpContext.Current.User.Identity.GetUserName();
                int CustomUserEyeD = int.Parse(UserDDForm[0]);
                _dataRepository.BuyPet(100.00, CustomUserEyeD);
                int speeshis = int.Parse(SpeciesDDForm[0]);
                //ApplicationUser _user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());

                if (UserIds != null)
                {
                    pet.Users = new List<User>();
                    //many to many ORM ???
                    foreach (var aUserRef in UserIds)
                    {
                        pet.Users.Add(
                            new User { PersonID = aUserRef }
                            );
                    }
                }
                else {
                    bool alreadyExists = false;
                    if (pet.Users == null)
                    {
                        pet.Users = new List<User>();
                    }
                    else {//Pet already belongs to at least 1 user; don't add any users twice!
                        foreach (var uza in pet.Users)
                        {
                            if (uza.PersonID == CustomUserEyeD) { alreadyExists = true; }
                        }
                    }
                    if (!alreadyExists)
                    {
                        pet.Users.Add(_dataRepository.GetAUserByID(CustomUserEyeD));
                    }
                }
                
                pet.Creator = creator;
                pet.Species = speeshis;
                _dataRepository.AddNewPet(pet);
                

                return RedirectToAction("Index");
            }
            return View(pet);
        }

        // GET: Pets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pet pet = _dataRepository.GetAPetByID(id.Value);
            if (pet == null)
            {
                return HttpNotFound();
            }
            return View(pet);
        }

        // POST: Pets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PetID,NickName")] Pet pet)
        {
            if (ModelState.IsValid)
            {
                _dataRepository.UpdatePet(pet);
                return RedirectToAction("Index");
            }
            return View(pet);
        }

        // GET: Pets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pet pet = _dataRepository.GetAPetByID(id.Value);
            if (pet == null)
            {
                return HttpNotFound();
            }

            _dataRepository.RemovePet(pet);

            return RedirectToAction("Index");
        }

        // POST: Pets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pet pet = _dataRepository.GetAPetByID(id);
            return RedirectToAction("Index");
        }
    }
}
