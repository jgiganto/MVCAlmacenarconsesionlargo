using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCAlmacenarconsesionlargo.Models;

namespace MVCAlmacenarconsesionlargo.Controllers
{
    public class EmpleadosController : Controller
    {
        ModeloHospital modelo;
        public EmpleadosController()
        {
            modelo = new ModeloHospital();
        }
        public ActionResult AlmacenarEmpleadosSession(int? empno)
        {
            if (empno != null)
            {
                List<int> lista;
                if (Session["EMPLEADOS"] == null)
                {
                    lista = new List<int>();
                }
                else
                {
                    lista = Session["EMPLEADOS"] as List<int>;
                }
                lista.Add(empno.GetValueOrDefault());
                Session["EMPLEADOS"] = lista;
                ViewBag.Mensaje = "Empleados almacenados: " + lista.Count();
            }
            IQueryable empleados = this.modelo.GetEmpleados();
            return View(empleados);
        }
        public ActionResult MostrarEmpleadosSession(int? eliminar)
        {
            if (eliminar != null)
            {
                List<int> lista = (List<int>)Session["EMPLEADOS"];
                lista.Remove(eliminar.GetValueOrDefault());
                if (lista.Count() == 0)
                {
                    Session["EMPLEADOS"] = null;
                }
                else
                {
                    Session["EMPLEADOS"] = lista;
                }
            }
            if (Session["EMPLEADOS"] == null)
            {
                return View();
            }
            else
            {
                List<int> lista = (List<int>)Session["EMPLEADOS"];
                IQueryable<EMP> empleados = this.modelo.GetEmpleadosSession(lista);
                return View(empleados);
            }
        }


        // GET: Empleados
        public ActionResult Index()
        {
            return View();
        }
    }
}