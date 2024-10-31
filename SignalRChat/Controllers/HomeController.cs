using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalRChat.Data;
using SignalRChat.Models;
using System.Diagnostics;


namespace SignalRChat.Controllers
{
    public class HomeController : Controller
    {



        private readonly MyDbContext conn;
        public HomeController()
        {

            conn = new MyDbContext();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]

    

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult GetUserId()
        {
            var userId = HttpContext.Session.GetString("userId");
            return Json(new { UserId = userId });
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

       

        [HttpPost]
        public async Task<IActionResult> Login(user c,string userId,string connectionId)
        {
            try
            {
                var data = await conn.Users.SingleOrDefaultAsync(row => row.userId == c.userId && row.password == c.password);
                if (data != null)
                {
                    
                    HttpContext.Session.SetString("Admin", data.username);
                    HttpContext.Session.SetString("userId", data.userId.ToString());
                    //HttpContext.Session.SetString("Role", data.Role);
                    if(data.Role == "Admin")
                    {
                        return RedirectToAction("Index", "Client");
                    }

                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                   
                }
                else
                {
                    ViewBag.Message = "User Id Or Password Incorrect";
                    
                    return View();
                    
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }



        [HttpPost]
        public IActionResult DeleteMessage(int id)
        {
  
            var message = conn.UserMessage.Find(id);

            if (message != null)
            {
                conn.UserMessage.Remove(message);
                conn.SaveChanges();
            }
            return RedirectToAction("Index","Home");
        }





        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("Admin") != null)
            {
                var UserId = HttpContext.Session.GetString("userId");
                var message = conn.UserMessage.Where(m=> m.userId == int.Parse(UserId)).ToList();

                return View(message);
            }
            return RedirectToAction("Login", "Home");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
