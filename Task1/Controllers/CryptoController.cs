using Microsoft.AspNetCore.Mvc;
using Task1.Models;
using Task1.Services;

namespace Task1.Controllers
{
    public class CryptoController : Controller
    {
        private readonly ICaesarCipher _caesar;
        private readonly IRailFenceCipher _railFence;
        private readonly IVigenereCipher _vigenere;

        public CryptoController(ICaesarCipher caesar, IRailFenceCipher railFence, IVigenereCipher vigenere)
        {
            _caesar = caesar;
            _railFence = railFence;
            _vigenere = vigenere;
        }

        public IActionResult Index() => View();

        [HttpPost]
        public IActionResult Caesar(CaesarViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            model.EffectiveKey = ((model.RawKey % 26) + 26) % 26;

            model.Result = model.Mode == "Encrypt"
                ? _caesar.Encrypt(model.Text, model.EffectiveKey)
                : _caesar.Decrypt(model.Text, model.EffectiveKey);

            return View(model);
        }

        [HttpPost]
        public IActionResult RailFence(RailFenceViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            model.Result = model.Mode == "Encrypt"
                ? _railFence.Encrypt(model.Text, model.Rails)
                : _railFence.Decrypt(model.Text, model.Rails);

            return View(model);
        }

        [HttpPost]
        public IActionResult Vigenere(VigenereViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            model.Result = model.Mode == "Encrypt"
                ? _vigenere.Encrypt(model.Text, model.Key)
                : _vigenere.Decrypt(model.Text, model.Key);

            return View(model);
        }
    }
}
