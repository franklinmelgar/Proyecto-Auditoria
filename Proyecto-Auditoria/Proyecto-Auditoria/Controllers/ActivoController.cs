using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_Auditoria.Models;

namespace Proyecto_Auditoria.Controllers
{
    public class ActivoController : Controller
    {
        private readonly ILogger<ActivoController> _logger;
        private GestionInventarioAuditoriaContext conexionBD = new GestionInventarioAuditoriaContext();
        public IActionResult Index()
        {
            var listadoActivos = conexionBD.Set<Activo>().Include(U => U.CodigoUbicacionNavigation).Include(T => T.CodigoTipoActivoNavigation).ToList();
            return View(listadoActivos);
        }

        public IActionResult Create()
        {

            var listaTipoActivo = conexionBD.TipoActivos.ToList();
            ViewData["Tipos"] = listaTipoActivo;

            var listaUbicacion = conexionBD.Ubicacions.ToList();
            ViewData["Ubicacion"] = listaUbicacion;

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
    }
}
