using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ConfiguringApps.Infrastructure;

namespace ConfiguringApps.Controllers
{
    public class HomeController : Controller
    {
        private UptimeService upTime;
        private ILogger<HomeController> logger;

        public HomeController(UptimeService up, ILogger<HomeController> log)
        {
            upTime = up;
            logger = log;
        }

        public IActionResult Index(bool throwException = false) {
            if (throwException)
            {
                throw new NullReferenceException();
            }

            logger.LogDebug($"Handled {Request.Path} at uptime {upTime.Uptime}");

            return View(new Dictionary<string, string> {
                ["Message"] = "This is the Index action",
                ["Uptime"] = $"{upTime.Uptime} ms." }
            );
        }

        public IActionResult Error()
        {
            return View("Index", new Dictionary<string, string>
            {
                ["Message"] = "This is the Error action"
            });
        }
    }
}