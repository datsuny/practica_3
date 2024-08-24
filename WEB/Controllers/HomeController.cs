using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;
using WEB.Entitites;
using WEB.Interfaces;
using WEB.Models;

namespace WEB.Controllers
{
    public class HomeController(IPrincipalModel iProductoModel, IAbonoModel iAbonoModel) : Controller
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
            var respuesta = iProductoModel.ConsultarProductos();
            if (respuesta.Codigo == 1)
            {
                var datos = JsonSerializer.Deserialize<List<Principal>>((JsonElement)respuesta.Contenido!);
                var pendientes = datos.Where(d => !d.Estado).ToList();
                ViewBag.Pendientes = pendientes;
                return View(new Abonos());
            }
            return View(new Abonos());
        }

        [HttpGet]
        public IActionResult ConsultaProducto(int codigoCompra)
        {
            var respuesta = iProductoModel.ConsultarProducto(codigoCompra);
            if (respuesta.Codigo == 1)
            {
                var datos = JsonSerializer.Deserialize<Principal>((JsonElement)respuesta.Contenido!);
                return Json(datos);
            }
            return Json(null);
        }

        [HttpPost]
        public IActionResult AbonarMonto(Abonos abono)
        {
            var respuesta = iAbonoModel.AbonarMonto(abono);
            if (respuesta.Codigo == 1)
            {
                return RedirectToAction("Consulta");
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
