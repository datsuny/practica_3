using Microsoft.Extensions.Configuration;
using static System.Net.WebRequestMethods;
using System.Net.Http.Headers;
using WEB.Interfaces;
using WEB.Entitites;

namespace WEB.Models
{
    public class AbonoModel(HttpClient http, IConfiguration iConfiguration, IHttpContextAccessor iAccesor) : IAbonoModel
    {
        public Respuesta AbonarMonto(Abonos abono)
        {
            string url = iConfiguration.GetSection("Llaves:UrlApi").Value + "Abonos/AbonarMonto";
            JsonContent body = JsonContent.Create(abono);
            // string token = iAccesor.HttpContext!.Session.GetString("TOKEN")!.ToString();

            // http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var result = http.PostAsync(url, body).Result;

            if (result.IsSuccessStatusCode)
                return result.Content.ReadFromJsonAsync<Respuesta>().Result!;
            else
                return new Respuesta();
        }

    }
}
