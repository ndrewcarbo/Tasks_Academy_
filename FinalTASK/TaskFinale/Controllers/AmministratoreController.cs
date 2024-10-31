using Microsoft.AspNetCore.Mvc;
using TaskFinale.Services;

namespace TaskFinale.Controllers
{
    public class AmministratoreController : Controller
    {



        private readonly AmministratoreServices _adService;
        private readonly ILogger<AmministratoreController> _logger;

        public AmministratoreController(AmministratoreServices adService, ILogger<AmministratoreController> logger)
        {
            _adService = adService;
            _logger = logger;
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
