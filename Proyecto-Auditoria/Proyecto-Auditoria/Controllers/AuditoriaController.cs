using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_Auditoria.Models;

namespace Proyecto_Auditoria.Controllers
{
    public class AuditoriaController : Controller
    {
        private readonly ILogger<AuditoriaController> _logger;
        private GestionInventarioAuditoriaContext conexionBD = new GestionInventarioAuditoriaContext();

        private void obtenerListados()
        {
            var listaActivos = conexionBD.Activos.ToList();
            ViewData["Activo"] = listaActivos;
        }
        // GET: AuditoriaController
        public IActionResult Index()
        {
            var listadoAuditoria = conexionBD.Set<Auditorium>().Include(U => U.CodigoActivoNavigation).ToList();
            return View(listadoAuditoria);
        }

        // GET: AuditoriaController/Create
        public ActionResult Create()
        {
            obtenerListados();
            return View();
        }

        // POST: AuditoriaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Auditorium auditoria)
        {
            if (auditoria is null)
            {
                throw new ArgumentNullException(nameof(auditoria));
            }

            conexionBD.Add(auditoria);
            conexionBD.SaveChanges();
            obtenerListados();
            return Redirect("Index");
        }

        // GET: AuditoriaController/Details/5
        public ActionResult Details(int id)
        {
            obtenerListados();
            Auditorium auditoria = conexionBD.Auditoria.Where(a => a.CodigoAuditoria.Equals(id)).FirstOrDefault();
            return View(auditoria);
        }

        // GET: AuditoriaController/Edit/5
        public ActionResult Edit(int id)
        {
            obtenerListados();
            Auditorium auditoria = conexionBD.Auditoria.Where(a => a.CodigoAuditoria.Equals(id)).FirstOrDefault();
            return View(auditoria);
        }

        // POST: AuditoriaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Auditorium auditoria)
        {
            try
            {
                conexionBD.Update(auditoria);
                conexionBD.SaveChanges();
                obtenerListados();
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        // GET: AuditoriaController/Delete/5
        public ActionResult Delete(int id)
        {
            obtenerListados();
            Auditorium auditoria = conexionBD.Auditoria.Where(a => a.CodigoAuditoria.Equals(id)).FirstOrDefault();
            return View(auditoria);
        }

        // POST: AuditoriaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Auditorium auditoria)
        {
            try
            {
                conexionBD.Remove(auditoria);
                conexionBD.SaveChanges();
                obtenerListados();
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
    }
}
