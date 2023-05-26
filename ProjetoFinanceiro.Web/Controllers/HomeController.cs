using Microsoft.AspNetCore.Mvc;
using ProjetoFinanceiro.Web.Models;
using System.Diagnostics;

namespace ProjetoFinanceiro.Web.Controllers
{
    public class HomeController : Controller
    {
        #region Props

        private readonly ILogger<HomeController> _logger;

        #endregion

        #region Constructor
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        #endregion

        #region INDEX
        public IActionResult Index()
        {
            return View();
        }

        #endregion

        #region ERROR

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        #endregion
    }
}