using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MichalRykowskiWebsite.Models;

namespace MichalRykowskiWebsite.Controllers
{
    [Route("/")]
    public class IndexController : Controller
    {
        private Random rnd;

        public IActionResult Index()
        {
            return View();
        }

        [Route("/Message")]
        public IActionResult Message()
        {
            MessageController controller = ((MessageController)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(MessageController)));

            return View();
        }

        [Route("/cv")]
        public IActionResult CV()
        {
            return View();
        }

        [Route("/projects")]
        public IActionResult Projects()
        {
            return View();
        }
    }
}
