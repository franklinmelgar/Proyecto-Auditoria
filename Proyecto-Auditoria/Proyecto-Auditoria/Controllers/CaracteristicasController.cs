using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_Auditoria.Models;

namespace Proyecto_Auditoria.Controllers
{
    public class CaracteristicasController : Controller
    {
        private GestionInventarioAuditoriaContext conexionBD = new GestionInventarioAuditoriaContext();
        private int codigoActivo;
        private int codigoTipoActivo;
        public IActionResult Index(string id)
        {
            ViewBag.Tipo = id;
            var listadoActivos = conexionBD.Set<Activo>().Include(U => U.CodigoUbicacionNavigation).Include(T => T.CodigoTipoActivoNavigation).Where(F => F.CodigoTipoActivoNavigation.Descripcion.Equals(id)).ToList();

            return View(listadoActivos);
        }

        public IActionResult Create(int id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            obtenerInfomacionActivo(id);

            return View();
        }

        [HttpPost]
        public IActionResult Create(int id, CaracteristicaActivo caracteristica)
        {
            if (caracteristica is null)
            {
                throw new ArgumentNullException(nameof(caracteristica));
            }

            conexionBD.Add(caracteristica);
            conexionBD.SaveChanges();

            obtenerInfomacionActivo(id);

            return View();
        }

        public IActionResult Detail(int id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            obtenerInfomacionActivo(id);

            return View();
        }

        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var caracteristica = conexionBD.CaracteristicaActivos.Where(F => F.CodigoCaracteristica.Equals(id)).FirstOrDefault();
            int codigo = (int)caracteristica.CodigoActivo;

            conexionBD.CaracteristicaActivos.Remove(caracteristica);
            conexionBD.SaveChanges();

            obtenerInfomacionActivo(codigo);

            return RedirectToAction("Detail", new { id = codigo });
        }

        public IActionResult Edit(int Id)
        {
            //if (id == null)
            //{
            //    return RedirectToAction("Index");
            //}

            var caracteristica = conexionBD.Set<CaracteristicaActivo>().Include(C => C.CodigoListadoCaracteristicaNavigation).Where(C => C.CodigoCaracteristica.Equals(Id)).FirstOrDefault();

            return View(caracteristica);
        }

        [HttpPost]
        public IActionResult Edit(CaracteristicaActivo _caracteristica)
        {
            //if (id == null)
            //{
            //    return RedirectToAction("Index");
            //}

            int codigo = (int)_caracteristica.CodigoCaracteristica;

            conexionBD.Update(_caracteristica);
            conexionBD.SaveChanges();

            //var caracteristica = conexionBD.Set<CaracteristicaActivo>().Include(C => C.CodigoListadoCaracteristicaNavigation).Where(C => C.CodigoCaracteristica.Equals(codigo)).FirstOrDefault();

            return RedirectToAction("Edit", "Caracteristicas", new {Id = codigo});
        }


        private void obtenerInfomacionActivo(int idActivo)
        {
            var ActivoFiltrado = conexionBD.Set<Activo>().Include(U => U.CodigoUbicacionNavigation).Include(T => T.CodigoTipoActivoNavigation).Where(F => F.CodigoActivo.Equals(idActivo)).FirstOrDefault();
            codigoTipoActivo = (int)ActivoFiltrado.CodigoTipoActivo;
            ViewData["Activo"] = ActivoFiltrado;

            var listadoCaracteristicas = conexionBD.ListadoCaracteristicaTipoActivos.Where(F => F.CodigoTipoActivo.Equals(codigoTipoActivo)).ToList();
            ViewData["ListadoCaracteristicas"] = listadoCaracteristicas;

            var listadoCaracteristicasActivo = conexionBD.Set<CaracteristicaActivo>().Include(L => L.CodigoListadoCaracteristicaNavigation).Where(F => F.CodigoActivo.Equals(idActivo)).ToList();
            ViewData["ListadoCaracteristicasActivo"] = listadoCaracteristicasActivo;
        }
    }
}
