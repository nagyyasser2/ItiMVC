using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;

namespace Example.Controllers
{
    public class PassDataController : Controller
    {
        public IActionResult First()
        {
            TempData["Msg"] = "Data From First Action";
            return Content("Data Saved!.");
        }

        public IActionResult Second()
        {
            if (TempData.ContainsKey("Msg"))
            {
                string msg = TempData.Peek("Msg").ToString();
                return Content("Second: " + msg);
            }
            else
            {
                return Content("Second: No data found.");
            }
        }

        public IActionResult Third()
        {
            if (TempData.ContainsKey("Msg"))
            {
                string msg = TempData["Msg"].ToString();
                TempData.Keep("Msg");
                return Content("Third: " + msg);
            }
            else
            {
                return Content("Third: No data found.");
            }
        }

        public IActionResult SetSession()
        {
            HttpContext.Session.SetString("MySessionData", "Hello from Session!");
            return Content("Session data has been set.");
        }

        public IActionResult GetSession()
        {
            string data = HttpContext.Session.GetString("MySessionData");
            if (string.IsNullOrEmpty(data))
            {
                return Content("No session data found.");
            }
            return Content("Session data: " + data);
        }

        public IActionResult SetCookie()
        {
            CookieOptions options = new CookieOptions
            {
                Expires = DateTime.Now.AddMinutes(10), // Cookie expiration
                HttpOnly = true
            };

            Response.Cookies.Append("MyCookie", "Hello from Cookie!", options);
            return Content("Cookie has been set.");
        }

        public IActionResult GetCookie()
        {
            string cookieValue = Request.Cookies["MyCookie"];
            if (string.IsNullOrEmpty(cookieValue))
            {
                return Content("No cookie found.");
            }

            return Content("Cookie value: " + cookieValue);
        }
    }
}
