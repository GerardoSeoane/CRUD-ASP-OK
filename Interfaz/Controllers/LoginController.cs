using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Validar;
using static Interfaz.Models.Alertas;

namespace Interfaz.Controllers
{
    public class LoginController : Controller
    {
        Validaciones val = new Validaciones();
        // GET: Login
        public ActionResult Mostrar()
        {
            try
            {
                TempData["Message"] = "";
                List<EntPersona> Lista = val.Mostrar();

                int conteo=Lista.Count();

                return View(Lista);
            }
            catch (Exception)
            {
                List<EntPersona> Lista = new List<EntPersona>();
                return View(Lista);
            }
            
        }

        public ActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Agregar(EntPersona persona)
        {
            TempData["Message"] = "AGREGAR";
            string Response = val.Insertar(persona);
            List<EntPersona> Lista = val.Mostrar();

            if (Response == "Insertado Correctamente")
                TempData["Message"] = "Insertado";

            return View("Mostrar",Lista);
        }

        public ActionResult Editar(int Id)
        {
            EntPersona p = val.BuscarById(Id);
            return View(p);
        }

        [HttpPost]
        public ActionResult Editar(EntPersona persona)
        {
            TempData["Message"] = "EDITAR";
            string Response = val.Editar(persona);
            List<EntPersona> Lista = val.Mostrar();
            if (Response== "Editado Correctamente")
                TempData["Message"] = "Editado";

            return View("Mostrar", Lista);
        }

        public ActionResult Eliminar(int Id)
        {
            EntPersona p = val.BuscarById(Id);
            return View(p);
        }

        [HttpPost]
        public ActionResult Eliminar(EntPersona p)
        {
            TempData["Message"] = "ELIMINADO";
            string response = val.Eliminar(p);
            List<EntPersona> Lista = val.Mostrar();

            if (response == "Eliminado Correctamente")
                TempData["Message"] = "Eliminado";

            return View("Mostrar", Lista);
        }
    }
}