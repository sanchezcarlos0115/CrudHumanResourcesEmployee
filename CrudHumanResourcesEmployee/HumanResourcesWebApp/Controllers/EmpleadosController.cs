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
                //por pruebas tomo los 5 ultimos registros para mejor visualizacion de los datos en la tabla
                // hasta que se habilite el pagineo de registro (pendiente) en la visualizacion de la informacion
                return View(lstReg.Take(5));
            }
        }

        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(EmpleadoType obj)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Todos los campos son requeridos.");
                return View(obj);
            }

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(BaseUrl + "api/Empleados");
                    var postTask = client.PostAsJsonAsync<EmpleadoType>("Empleados", obj);
                    postTask.Wait();
                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Ocurrio un error al guardar los datos.");
                        return View(obj);
                    }
                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(string.Empty, ex.Message);
                return View(obj);
            }
        }

        public ActionResult Editar(int id)
        {
            EmpleadoType empl = new EmpleadoType();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                var respTask = client.GetAsync("api/Empleados/" + id.ToString());
                respTask.Wait();
                var result = respTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<EmpleadoType>();
                    readTask.Wait();
                    empl = readTask.Result;
                }
                return View(empl);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(EmpleadoType obj)
        {

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Todos los campos son requeridos.");
                return View(obj);
            }

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(BaseUrl);
                    var putTask = client.PutAsJsonAsync("api/Empleados/" + obj.BusinessEntityId.ToString(), obj);
                    putTask.Wait();
                    var result = putTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }
                ModelState.AddModelError(string.Empty, "Ocurrio un error al actualizar el registro.");
                return View(obj);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(obj);
            }

        }



        public ActionResult Eliminar(int? id)
        {
            EmpleadoType emp = new EmpleadoType();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                var respTask = client.GetAsync("api/Empleados/" + id.Value.ToString());
                respTask.Wait();
                var result = respTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<EmpleadoType>();
                    readTask.Wait();
                    emp = readTask.Result;
                }
                return View(emp);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Eliminar(EmpleadoType obj, int id)
        {

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(BaseUrl);
                    var deleteTask = client.DeleteAsync("api/Empleados/" + id.ToString());
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