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
        private Random rnd;
        private readonly MessageContext _context;
        public PosterController(MessageContext context)
        {
            this._context = context;
            rnd = new Random();
        }

        public IActionResult Index()
        {
            if (_context.MessageItems.Count() > 0)
            {
                int randomIndex = rnd.Next(0, _context.MessageItems.Count());
                Message msg = _context.MessageItems.OrderBy(m => m.Id).ToList()[randomIndex];
                ViewData.Model = msg;
            }
            return View();
        }
    }
}
