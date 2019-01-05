using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Lab6.Models;
using Lab6.Data; //database repo services
using Microsoft.AspNet.Identity;

namespace Lab6.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private readonly DatabaseAccessI _dataRepository;

        public UsersController(DatabaseAccessI dataRepository) {
            _dataRepository = dataRepository;
        }

        // GET: UsersEF
        public ActionResult Index()
        {
            //var persons = _dataRepository.GetAllUsers();
            var persons = _dataRepository.GetAllUsers(System.Web.HttpContext.Current.User.Identity.GetUserName());
            return View(persons);
        }

        
        // GET: UsersEF/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //int nonNullableId = id ?? default(int); ////http://stackoverflow.com/questions/5995317/how-to-convert-c-sharp-nullable-int-to-int
            User user = _dataRepository.GetAUserByID(id.Value); //nullableInt.Value will throw exception here if it is null!

            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: UsersEF/Create
        public ActionResult Create()
        {
            var pets = _dataRepository.GetAllPets();
            ViewBag.GroupList = new MultiSelectList(pets, "PetID", "Nickname");
            return View();
        }

        // POST: UsersEF/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PersonID,FirstName,LastName,EmailAddress,GalRanchConsumed")] User user, 
            List<int>PetIds)
        {
            if (ModelState.IsValid)
            {
                string creatore = System.Web.HttpContext.Current.User.Identity.GetUserName();
                Wealth MyMoney = new Wealth();
                MyMoney.Cash = 300;
                
                // TODO: add UI hook to add pets either in create or seperate service 
                if (PetIds != null)
                {
                    user.MyPets = new List<Pet>();
                    // Add all pets to user's collection of pets
                    foreach (var petNum in PetIds)
                    {
                        user.MyPets.Add(
                            new Pet { PetID = petNum }
                            );
                    }
                }
                user.creator = creatore;
                user.MyWealth = MyMoney;
                _dataRepository.AddNewUser(user);

                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: UsersEF/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = _dataRepository.GetAUserByID(id.Value);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: UsersEF/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PersonID,FirstName,LastName,EmailAddress,GalRanchConsumed")] User user)
        {
            if (ModelState.IsValid)
            {
                _dataRepository.UpdateUser(user);
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: UsersEF/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = _dataRepository.GetAUserByID(id.Value);
            if (user == null)
            {
                return HttpNotFound();
            }

            _dataRepository.RemoveUser(user);

            return RedirectToAction("Index");
        }

        // POST: UsersEF/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = _dataRepository.GetAUserByID(id); //should this be nullable int?
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
