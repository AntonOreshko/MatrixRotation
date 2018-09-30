using System;
using System.Diagnostics;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using MatrixRotation.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace MatrixRotation.Controllers
{
    public class HomeController : Controller
    {
        public int MatrixSize = 6;

        public IActionResult Index()
        {
            return View(new MatrixViewModel(MatrixSize));
        }

        [HttpGet]
        public IActionResult Rotate(string matrixString)
        {
            var matrix = JsonConvert.DeserializeObject<MatrixViewModel>(matrixString);
            matrix.Rotate();
            return View("Index", matrix);
        }

        [HttpGet]
        public FileResult Save(string matrixString)
        {
            var matrix = JsonConvert.DeserializeObject<MatrixViewModel>(matrixString);
            return File(MatrixViewModel.SaveToCsv(matrix), System.Net.Mime.MediaTypeNames.Application.Octet, "matrix.csv");
        }

        [HttpGet]
        public IActionResult ChangeSize(int newSize)
        {
            return View("Index", new MatrixViewModel(newSize));
        }

        [HttpPost]
        public IActionResult Upload(IFormFile uploadedFile)
        {
            if (uploadedFile == null)
            {
                return RedirectToAction("Error");
            }

            try
            {
                var matrix = MatrixViewModel.LoadFromFile(uploadedFile);
                return View("Index", matrix);
            }
            catch (Exception)
            {
                return RedirectToAction("Error");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
