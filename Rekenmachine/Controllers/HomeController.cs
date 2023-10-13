using Microsoft.AspNetCore.Mvc;
using Rekenmachine.Models;
using System.Diagnostics;

namespace Rekenmachine.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Bereken()
        {
            return View();
        }

        [HttpPost("Bereken")]
        public IActionResult Bereken(double num1, double num2, string bewerking)
        {
            double resultaat = 0;

            switch (bewerking)
            {
                case "optellen":
                    resultaat = num1 + num2;
                    break;
                case "aftrekken":
                    resultaat = num1 - num2;
                    break;
                case "vermenigvuldigen":
                    resultaat = num1 * num2;
                    break;
                case "delen":
                    if (num2 != 0)
                        resultaat = num1 / num2;
                    else
                        resultaat = double.NaN;
                    break;
            }

            ViewData["Resultaat"] = resultaat;

            return View();

        }
        public IActionResult NaamOmgekeerd()
        {
            return View();
        }

        [HttpPost("NaamOmgekeerd")]
        public IActionResult NaamOmgekeerd(string naam)
        {
            char[] Tekenreeks = naam.ToCharArray();
            Array.Reverse(Tekenreeks);
            string omgekeerdeNaam = new(Tekenreeks);
            ViewData["OmgekeerdeNaam"] = omgekeerdeNaam;
            return View();
        }

        public IActionResult Boete()
        {
            return View();
        }

        [HttpPost("Boete")]
        public IActionResult Boete(int snelheid)
        {
            string result = "Proficiat, u bent een van de weinige die niet te hard rijdt!";
            ViewData["Snelheid"] = snelheid;

            if (snelheid > 50)
            {
                int boete = 125;
                do
                {
                    boete += 25;
                    snelheid--;
                } while (snelheid > 50);
                result = $"Foei, U krijgt een boete van €{boete}";
            }

            ViewData["Boete"] = result;
            return View();
        }


    }

}