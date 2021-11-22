using HumanResourcesWebApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace HumanResourcesWebApp.Controllers
{
    public class HistorialPagosController : Controller
    {

        private const string V = "https://localhost:44308/";
        readonly string BaseUrl = V;
        public async Task<ActionResult> Index()
        {
            List<HistorialPagoType> lstReg = new List<HistorialPagoType>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("aplication/json"));
                HttpResponseMessage resp = await client.GetAsync("api/HistorialPagos");
                if (resp.IsSuccessStatusCode)
                {
                    var lstResponse = resp.Content.ReadAsStringAsync().Result;
                    lstReg = JsonConvert.DeserializeObject<List<HistorialPagoType>>(lstResponse);
                }
                //por pruebas tomo los 5 ultimos registros para mejor visualizacion de los datos en la tabla
                // hasta que se habilite el pagineo de registro (pendiente) en la visualizacion de la informacion
                return View(lstReg.Take(5));
            }
        }




    }
}