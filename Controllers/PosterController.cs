using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MichalRykowskiWebsite.Models;


namespace MichalRykowskiWebsite.Controllers
{
    [Route("/poster")]
    public class PosterController : Controller
    {
        private readonly MessageContext _context;
        public PosterController(MessageContext context)
        {
            this._context = context;
        }

        public IActionResult Index()
        {
            Message msg = _context.MessageItems.Find(1);
            ViewData.Model = msg;
            return View();
        }
    }
}
