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
                //por pruebas tomo los 10 ultimos registros para mejor visualizacion de los datos en la tabla
                // hasta que se habilite el pagineo de registro (pendiente) en la visualizacion de la informacion
                return View(lstReg.Take(10));
            }
        }


        public ActionResult Eliminar(int? id, DateTime rateChangeDate)
        {
            HistorialPagoType histpago = new HistorialPagoType();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                var respTask = client.GetAsync("api/HistorialPagos/" + id.Value.ToString() + "/"+ rateChangeDate.ToString());
                respTask.Wait();
                var result = respTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<HistorialPagoType>();
                    readTask.Wait();
                    histpago = readTask.Result;
                }
                return View(histpago);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Eliminar(HistorialPagoType obj, int id,DateTime rateChangeDate)
        {

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(BaseUrl);
                    var deleteTask = client.DeleteAsync("api/HistorialPagos/" + id.ToString() + "/"+ rateChangeDate.ToString());
                    deleteTask.Wait();
                    var result = deleteTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);

            }
            return View(obj);
        }



    }
}