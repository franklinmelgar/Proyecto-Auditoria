using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_Auditoria.Models;

namespace Proyecto_Auditoria.Controllers
{
    public class ActivoController : Controller
    {
        private readonly ILogger<ActivoController> _logger;
        private GestionInventarioAuditoriaContext conexionBD = new GestionInventarioAuditoriaContext();
        
        private void obtenerListados()
        {
            var listaTipoActivo = conexionBD.TipoActivos.ToList();
            ViewData["Tipos"] = listaTipoActivo;

            var listaUbicacion = conexionBD.Ubicacions.ToList();
            ViewData["Ubicacion"] = listaUbicacion;
        }
        
        public IActionResult Index()
        {
            var listadoActivos = conexionBD.Set<Activo>().Include(U => U.CodigoUbicacionNavigation).Include(T => T.CodigoTipoActivoNavigation).ToList();
            return View(listadoActivos);
        }

        public IActionResult Create()
        {

            obtenerListados();

            return View();
        }

        [HttpPost]
        public IActionResult Create(Activo activo)
        {
            if (activo is null)
            {
                throw new ArgumentNullException(nameof(activo));
            }

            conexionBD.Add(activo);
            conexionBD.SaveChanges();

            return Redirect("Index");
        }

        public IActionResult Detail(int? Id)
        {

            if (Id == null)
            {
                return RedirectToAction("Index");
            }

            var activo = conexionBD.Set<Activo>().Include(A => A.CodigoTipoActivoNavigation).Include(A => A.CodigoUbicacionNavigation).Where(A => A.CodigoActivo.Equals(Id)).FirstOrDefault();
            
            if (activo is null)
            {
                return RedirectToAction("Index");
            }

            return View(activo);
        }

        public IActionResult Edit(int? Id)
        {

            if (Id == null)
            {
                return RedirectToAction("Index");
            }

            var activo = conexionBD.Set<Activo>().Include(A => A.CodigoTipoActivoNavigation).Include(A => A.CodigoUbicacionNavigation).Where(A => A.CodigoActivo.Equals(Id)).FirstOrDefault();

            if (activo is null)
            {
                return RedirectToAction("Index");
            }

            obtenerListados();

            return View(activo);
        }

        [HttpPost]
        public IActionResult Edit(Activo _activo)
        {

            if (_activo == null)
            {
                return RedirectToAction("Index");
            }

            obtenerListados();

            conexionBD.Update(_activo);

            conexionBD.SaveChangesAsync();

            ViewBag.Mensaje = "Se actualizo correctamente el activo";          

            return View(_activo);
        }

        public IActionResult Delete(int? Id)
        {

            if (Id == null)
            {
                return RedirectToAction("Index");
            }

            var activo = conexionBD.Set<Activo>().Include(A => A.CodigoTipoActivoNavigation).Include(A => A.CodigoUbicacionNavigation).Where(A => A.CodigoActivo.Equals(Id)).FirstOrDefault();

            if (activo is null)
            {
                return RedirectToAction("Index");
            }

            obtenerListados();

            return View(activo);
        }

        [HttpPost]
        public IActionResult Delete(Activo _activo)
        {

            if (_activo == null)
            {
                return RedirectToAction("Index");
            }

            obtenerListados();

            conexionBD.Remove(_activo);

            conexionBD.SaveChangesAsync();

            ViewBag.Mensaje = "Se elimino correctamente el activo";

            return View(_activo);
        }
    }
}
