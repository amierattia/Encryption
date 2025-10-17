using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Task1.Models;
using Task1.Services;

namespace Task1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICaesarCipher _caesar;
        private readonly IRailFenceCipher _railFence;
        private readonly IVigenereCipher _vigenere;

        public HomeController(ILogger<HomeController> logger , ICaesarCipher caesar, IRailFenceCipher railFence, IVigenereCipher vigenere)
        {
            _caesar = caesar;
            _railFence = railFence;
            _vigenere = vigenere;
            _logger = logger;

        }

        public IActionResult Index() => View();

       

       

       
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
