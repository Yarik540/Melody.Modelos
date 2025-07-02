﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Melody.Modelos;
using Melody.API.Consumer;
using Microsoft.AspNetCore.Mvc.Rendering;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Melody.MVC.Controllers
{
    public class CancionesController : Controller
    {
        // GET: CancionesController
        public ActionResult Index()
        {
            var data = Crud<Cancion>.GetAll();
            return View(data);
        }

        // GET: CancionesController/Details/5
        public ActionResult Details(int id)
        {
            var data = Crud<Cancion>.GetById(id);
            return View();
        }

        // GET: CancionesController/Create
        public ActionResult Create()
        {
            ViewBag.Generos = GetGeneros();
            return View();
        }

        private List<SelectListItem> GetGeneros()
        {
            var generos = Crud<Genero>.GetAll();
            return generos.Select(g => new SelectListItem
            {
                Value = g.Id.ToString(),
                Text = g.Nombre
            }).ToList(); ;
        }

        // POST: CancionesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cancion data)
        {
            try
            {
                Crud<Cancion>.Create(data);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(data);
            }
        }

        // GET: CancionesController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = Crud<Cancion>.GetById(id);
            ViewBag.Generos = GetGeneros();
            return View(data);
        }

        // POST: CancionesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Cancion data)
        {
            try
            {
                Crud<Cancion>.Update(id, data);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(data);
            }
        }

        // GET: CancionesController/Delete/5
        public ActionResult Delete(int id)
        {
            var data = Crud<Cancion>.GetById(id);
            return View(data);
        }

        // POST: CancionesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Cancion data)
        {
            try
            {
                Crud<Cancion>.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(data);
            }
        }
    }
}
