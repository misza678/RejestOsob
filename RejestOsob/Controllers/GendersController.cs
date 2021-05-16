using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RejestOsob.Models;

namespace RejestOsob.Controllers
{
    public class GendersController : Controller
    {
        private PersonEntities db = new PersonEntities();

        // GET: Genders
        public ActionResult Index()
        {

         
            return View(db.Gender.ToList());
        }

    }
}
