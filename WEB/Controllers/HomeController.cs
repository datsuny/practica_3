using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;
using WEB.Entitites;
using WEB.Interfaces;
using WEB.Models;

namespace WEB.Controllers
{
    public class HomeController(IPrincipalModel iProductoModel) : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Consulta()
        {
            var respuesta = iProductoModel.ConsultarProductos();
            if (respuesta.Codigo == 1)
            {
                var datos = JsonSerializer.Deserialize<List<Principal>>((JsonElement)respuesta.Contenido!);
                return View(datos);
            }
            return View(new List<Principal>());
        }

        [HttpGet]
        public IActionResult Registro()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
