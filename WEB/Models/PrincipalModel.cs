using Microsoft.Extensions.Configuration;
using static System.Net.WebRequestMethods;
using System.Net.Http.Headers;
using WEB.Interfaces;
using WEB.Entitites;

namespace WEB.Models
{
    public class PrincipalModel(HttpClient http, IConfiguration iConfiguration, IHttpContextAccessor iAccesor) : IPrincipalModel
    {
        public Respuesta ConsultarProductos()
        {
            string url = iConfiguration.GetSection("Llaves:UrlApi").Value + "Principal/ConsultarProductos";
            // string token = iAccesor.HttpContext!.Session.GetString("TOKEN")!.ToString();

            // http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var result = http.GetAsync(url).Result;

            if (result.IsSuccessStatusCode)
                return result.Content.ReadFromJsonAsync<Respuesta>().Result!;
            else
                return new Respuesta();
        }

    }
}
