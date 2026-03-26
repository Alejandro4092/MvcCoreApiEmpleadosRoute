using Microsoft.AspNetCore.Mvc;
using MvcCoreApiEmpleadosRoute.Services;
using NugetApiModels.Models;

namespace MvcCoreApiEmpleadosRoute.Controllers
{
    public class EmpleadosController : Controller
    {
        private ServiceEmpleados service;

        public EmpleadosController(ServiceEmpleados service)
        {
            this.service = service;
        }

        public async Task<IActionResult> Index()
        {
            List<string> oficios = await this.service.GetOficiosAsync();
            List<Empleado> empleados = await this.service.GetEmpleadosAsync();
            ViewData["OFICIOS"] = oficios;

            return View(empleados);
        }

        [HttpPost]
        [Route("Empleados/FiltrarPorOficio")]
        public async Task<IActionResult> FiltrarPorOficio(string oficio)
        {
            List<string> oficios = await this.service.GetOficiosAsync();
            List<Empleado> empleados = await this.service.GetEmpleadosOficioAsync(oficio);
            ViewData["OFICIOS"] = oficios;

            return View("Index", empleados);
        }

        [HttpPost]
        [Route("Empleados/FiltrarPorOficio2")]
        public async Task<IActionResult> FiltrarPorOficio2(string oficio)
        {
            List<string> oficios = await this.service.GetOficiosAsync();
            List<Empleado> empleados = await this.service.GetEmpleadosOficioAsync(oficio);
            ViewData["OFICIOS"] = oficios;

            return View("Index", empleados);
        }
    }
}
