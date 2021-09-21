using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoginPageApp.Models;

namespace LoginPageApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserContext _context;

        public AccountController(UserContext context)
        {
            _context = context;
        }
        public IActionResult Login()
        {
            return View();
        }

        public ActionResult Validate(User user)
        {
            var _admin = _context.Users.Where(s => s.Login == user.Login);
            if (_admin.Any())
            {
                if (_admin.Where(s => s.Password == user.Password).Any())
                {

                    return Json(new { status = true, message = "Password Successfull!" });
                }
                else
                {
                    return Json(new { status = false, message = "Invalid Password!" });
                }
            }
            else
            {
                return Json(new { status = false, message = "Invalid Login!" });
            }
        }
    }
}
