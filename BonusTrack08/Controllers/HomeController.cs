using BonusTrack08.Models;
using BonusTrack08.Models.Entities;
using BonusTrack08.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BonusTrack08.Controllers
{
    public class HomeController : Controller
    {
        // GET: HomeController
        public IActionResult Index()
        {
            return View(new clsIndexVM());
        }
        [HttpPost]
        public IActionResult Index(int idCategoria)
        {
            //ViewBag.descripcion = clsListadoPlantas.detallesPlanta(planta.nombre).detalles;
            return View(new clsIndexVM(idCategoria));
        }

        // GET: HomeController/Edit
        public ActionResult Edit(int id)
        {
            return View(clsListadoPlantas.getPlanta(id));
        }

        // POST: HomeController/Edit
        [HttpPost]
        public ActionResult Edit(clsPlanta oPlanta)
        {
            try
            {
                clsGestoraPlantas.editarPlanta(oPlanta);
                return RedirectToAction("Index", new { resultado = "Planta editada con éxito." });
            }
            catch
            {
                return View();
            }
        }
    }
}
