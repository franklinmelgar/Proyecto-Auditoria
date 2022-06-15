using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_Auditoria.Models;

namespace Proyecto_Auditoria.Controllers
{
    public class TipoActivoController : Controller
    {
        private readonly ILogger<ActivoController> _logger;
        private GestionInventarioAuditoriaContext conexionBD = new GestionInventarioAuditoriaContext();

        public IActionResult Index()
        {
            var listadoTipoActivos = conexionBD.TipoActivos.ToList();
            return View(listadoTipoActivos);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TipoActivo tipo)
        {
            if (tipo is null)
            {
                throw new ArgumentNullException(nameof(tipo));
            }

            conexionBD.Add(tipo);
            conexionBD.SaveChanges();

            return Redirect("Index");
        }

        public IActionResult Edit(int? Id)
        {

            if (Id == null)
            {
                return RedirectToAction("Index");
            }

            var tipo = conexionBD.TipoActivos.Where(T => T.CodigoTipoActivo.Equals(Id)).FirstOrDefault();

            if (tipo is null)
            {
                return RedirectToAction("Index");
            }

            return View(tipo);
        }

        [HttpPost]
        public IActionResult Edit(TipoActivo tipo)
        {

            if (tipo == null)
            {
                return RedirectToAction("Index");
            }

            conexionBD.Update(tipo);

            conexionBD.SaveChangesAsync();

            ViewBag.Mensaje = "Se actualizo correctamente el activo";

            return View(tipo);
        }

        public IActionResult Delete(int? Id)
        {

            if (Id == null)
            {
                return RedirectToAction("Index");
            }

            var tipo = conexionBD.TipoActivos.Where(T => T.CodigoTipoActivo.Equals(Id)).FirstOrDefault();

            if (tipo is null)
            {
                return RedirectToAction("Index");
            }

            return View(tipo);
        }

        [HttpPost]
        public IActionResult Delete(TipoActivo tipo)
        {

            if (tipo == null)
            {
                return RedirectToAction("Index");
            }

            conexionBD.Remove(tipo);

            conexionBD.SaveChangesAsync();

            ViewBag.Mensaje = "Se elimino correctamente el tipo activo";

            return View(tipo);
        }
    }
}
