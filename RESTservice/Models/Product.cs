using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//Add a reference from your new service app project to your Web application project.This allow you to reference various common pieces of your application.  
//In a "real" project, you would factor the common pieces (models, database access, etc.) out into a separate 
//library project that both the Web application and the service application could reference.
namespace RESTservice.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
    }
}