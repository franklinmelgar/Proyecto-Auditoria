using Microsoft.AspNetCore.Mvc;
using Proyecto_Auditoria.Models;

namespace Proyecto_Auditoria.Controllers
{
    public class CaracteristicasTipoController : Controller
    {
        private readonly ILogger<ActivoController> _logger;
        private GestionInventarioAuditoriaContext conexionBD = new GestionInventarioAuditoriaContext();

        public IActionResult Index()
        {
            var listadoTipoActivos = conexionBD.TipoActivos.ToList();
            return View(listadoTipoActivos);
        }

        public IActionResult Create(int? Id)
        {

            if (Id == null)
            {
                return RedirectToAction("Index");
            }

            var tipoActivo = conexionBD.TipoActivos.Where(T => T.CodigoTipoActivo.Equals(Id)).FirstOrDefault();
            ViewData["TipoActivo"] = tipoActivo;

            var listadoCaracteristicas = conexionBD.ListadoCaracteristicaTipoActivos.Where(T => T.CodigoTipoActivo.Equals(Id)).ToList();
            ViewData["listado"] = listadoCaracteristicas;

            return View();
        }

        [HttpPost]
        public IActionResult Create(ListadoCaracteristicaTipoActivo tipo)
        {
            if (tipo is null)
            {
                throw new ArgumentNullException(nameof(tipo));
            }

            int Id = (int)tipo.CodigoTipoActivo;

            conexionBD.Add(tipo);
            conexionBD.SaveChanges();

            var tipoActivo = conexionBD.TipoActivos.Where(T => T.CodigoTipoActivo.Equals(Id)).FirstOrDefault();
            ViewData["TipoActivo"] = tipoActivo;

            var listadoCaracteristicas = conexionBD.ListadoCaracteristicaTipoActivos.Where(T => T.CodigoTipoActivo.Equals(Id)).ToList();
            ViewData["listado"] = listadoCaracteristicas;

            return View();
        }

        public IActionResult Detail(int? Id)
        {

            if (Id == null)
            {
                return RedirectToAction("Index");
            }

            var tipoActivo = conexionBD.TipoActivos.Where(T => T.CodigoTipoActivo.Equals(Id)).FirstOrDefault();
            ViewData["TipoActivo"] = tipoActivo;

            var listadoCaracteristicas = conexionBD.ListadoCaracteristicaTipoActivos.Where(T => T.CodigoTipoActivo.Equals(Id)).ToList();
            ViewData["listado"] = listadoCaracteristicas;

            return View();
        }



        public IActionResult Edit(int? Id)
        {

            if (Id == null)
            {
                return RedirectToAction("Index");
            }

            var caractetistica = conexionBD.ListadoCaracteristicaTipoActivos.Where(T => T.CodigoListadoCaracteristica.Equals(Id)).FirstOrDefault();

            if (caractetistica is null)
            {
                return RedirectToAction("Index");
            }

            return View(caractetistica);
        }

        [HttpPost]
        public IActionResult Edit(ListadoCaracteristicaTipoActivo caracteristica)
        {

            if (caracteristica == null)
            {
                return RedirectToAction("Index");
            }

            conexionBD.Update(caracteristica);

            conexionBD.SaveChangesAsync();

            ViewBag.Mensaje = "Se actualizo correctamente el activo";

            return View(caracteristica);
        }

        public IActionResult Delete(int? Id)
        {

            if (Id == null)
            {
                return RedirectToAction("Index");
            }

            var caractetistica = conexionBD.ListadoCaracteristicaTipoActivos.Where(T => T.CodigoListadoCaracteristica.Equals(Id)).FirstOrDefault();

            if (caractetistica is null)
            {
                return RedirectToAction("Index");
            }

            return View(caractetistica);
        }

        [HttpPost]
        public IActionResult Delete(ListadoCaracteristicaTipoActivo tipo)
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
