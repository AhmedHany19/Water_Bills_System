using Domain.IRepositiory;
using Infrastructure.Repositiory;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        
        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            ViewBag.SubscribersCount = _unitOfWork.Subscribers.Count();
            ViewBag.RealCount = _unitOfWork.Real_Estate_Types.Count();
            ViewBag.SubscriptionsCount = _unitOfWork.Subscriptions.Count();
            ViewBag.InvoicesCount = _unitOfWork.Invoices.Count();
            return View();
        }



      

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}