using BLL;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMaoApp_MVC.Models;

namespace WebMaoApp_MVC.Controllers
{
    [RoutePrefix("MaoAPP")]
    public class MaoAPPController : Controller
    {
        [HttpGet]
        [Route("")]
        public ActionResult Index()
        {
            ApplicationDbContext userscontext = new ApplicationDbContext();
            var userStore = new UserStore<ApplicationUser>(userscontext);
            var userManager = new UserManager<ApplicationUser>(userStore);

            if (User.Identity.IsAuthenticated)
            {
                if (userManager.IsInRole(User.Identity.GetUserId(), "Normal")  || userManager.IsInRole(User.Identity.GetUserId(), "Admin"))
                {
                    return View();

                }
            }
            return RedirectToAction("Login", "Account");
        }
        [HttpGet]
        [Route("notificacion")]
        public ActionResult Token()
        {
            ApplicationDbContext userscontext = new ApplicationDbContext();
            var userStore = new UserStore<ApplicationUser>(userscontext);
            var userManager = new UserManager<ApplicationUser>(userStore);

            if (User.Identity.IsAuthenticated)
            {
                if (userManager.IsInRole(User.Identity.GetUserId(), "Admin"))
                {
                    return View();

                }
            }
            return RedirectToAction("Login", "Account");
        }
        [HttpPost]
        public ActionResult UploadImages(string titulo, string mensaje, HttpPostedFileBase[] uploadImages)
        {
            ApplicationDbContext userscontext = new ApplicationDbContext();
            var userStore = new UserStore<ApplicationUser>(userscontext);
            var userManager = new UserManager<ApplicationUser>(userStore);

            if (User.Identity.IsAuthenticated)
            {
                if (userManager.IsInRole(User.Identity.GetUserId(), "Admin"))
                {
                    if (uploadImages.Count() == 0)
                    {
                        TempData["msg"] = "<script>alert('Debe añadir una imagen');</script>";
                        return RedirectToAction("Promocion");
                    }

                    foreach (var image in uploadImages)
                    {
                        if (image.ContentLength > 0)
                        {
                            byte[] imageData = null;
                            using (var binaryReader = new BinaryReader(image.InputStream))
                            {
                                imageData = binaryReader.ReadBytes(image.ContentLength);
                            }
                            PromocionBLL p = new PromocionBLL();
                            p.PostPromocion(imageData, titulo, mensaje);
                            TempData["msg"] = "<script>alert('Datos Guardados');</script>";
                        }
                    }
                    
                    return RedirectToAction("Promocion");

                }
            }
            return RedirectToAction("Login", "Account");
            
        }

        [HttpGet]
        public ActionResult Promocion()
        {
            ApplicationDbContext userscontext = new ApplicationDbContext();
            var userStore = new UserStore<ApplicationUser>(userscontext);
            var userManager = new UserManager<ApplicationUser>(userStore);

            if (User.Identity.IsAuthenticated)
            {
                if (userManager.IsInRole(User.Identity.GetUserId(), "Admin"))
                {
                    return View();

                }
            }
            return RedirectToAction("Login", "Account");
        }
    }
}