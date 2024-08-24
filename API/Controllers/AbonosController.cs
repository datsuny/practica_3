using API.Entities;
using API.Entitites;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AbonosController(IConfiguration iConfiguration) : ControllerBase
    {
        [HttpPost]
        [Route("AbonarMonto")]
        public async Task<IActionResult> AbonarMonto(Abonos abono)
        {
            Respuesta resp = new Respuesta();

            using (var context = new SqlConnection(iConfiguration.GetSection("ConnectionStrings:DefaultConnection").Value))
            {
                var result = await context.QueryAsync<Principal>("AbonarMonto",
                    new { abono.MontoAbono, abono.CodigoCompraPrincipalID },
                    commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    resp.Codigo = 1;
                    resp.Mensaje = "OK";
                    resp.Contenido = result;
                    return Ok(resp);
                }
                else
                {
                    resp.Codigo = 0;
                    resp.Mensaje = "No se pudo registrar el abono en este momento.";
                    resp.Contenido = false;
                    return Ok(resp);
                }
            }
        }

    }
}
