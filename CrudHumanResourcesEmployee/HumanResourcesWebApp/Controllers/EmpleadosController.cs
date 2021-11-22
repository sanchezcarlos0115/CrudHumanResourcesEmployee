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
    public class EmpleadosController : Controller
    {
       
        private const string V = "https://localhost:44308/";
        readonly string BaseUrl = V;
        public async Task<ActionResult> Index()
        {
            List<EmpleadoType> lstReg = new List<EmpleadoType>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("aplication/json"));
                HttpResponseMessage resp = await client.GetAsync("api/Empleados");
                if (resp.IsSuccessStatusCode)
                {
                    var lstResponse = resp.Content.ReadAsStringAsync().Result;
                    lstReg = JsonConvert.DeserializeObject<List<EmpleadoType>>(lstResponse);
                }
                return View(lstReg);
            }
        }

        public ActionResult Crear()
        {
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Crear(Productos obj)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        ModelState.AddModelError(string.Empty, "Todos los campos son requeridos.");
        //        return View(obj);
        //    }

        //    try
        //    {
        //        using (var client = new HttpClient())
        //        {
        //            client.BaseAddress = new Uri(BaseUrl + "api/Productos");
        //            var postTask = client.PostAsJsonAsync<Productos>("Productos", obj);
        //            postTask.Wait();
        //            var result = postTask.Result;
        //            if (result.IsSuccessStatusCode)
        //            {
        //                return RedirectToAction("Index");
        //            }
        //            else
        //            {
        //                ModelState.AddModelError(string.Empty, "Ocurrio un error al guardar los datos.");
        //                return View(obj);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        ModelState.AddModelError(string.Empty, ex.Message);
        //        return View(obj);
        //    }
        //}

        public JsonResult ObtenerPersonas()
        {
            List<PersonaType> lstReg = new List<PersonaType>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                var respTask = client.GetAsync("api/Persona");
                respTask.Wait();
                HttpResponseMessage resp = respTask.Result;
                if (resp.IsSuccessStatusCode)
                {
                    var lstResponse = resp.Content.ReadAsStringAsync().Result;
                    lstReg = JsonConvert.DeserializeObject<List<PersonaType>>(lstResponse);
                }
            }
            return Json(lstReg, JsonRequestBehavior.AllowGet);
        }
    }
}