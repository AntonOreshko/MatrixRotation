using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MatrixRotation.Models;

namespace MatrixRotation.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(new MatrixViewModel(6));
        }

        public IActionResult Rotate(MatrixViewModel matrixModel)
        {
            matrixModel.Rotate();
            return View("Index", matrixModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
