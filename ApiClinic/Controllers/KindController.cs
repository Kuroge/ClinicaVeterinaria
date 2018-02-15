using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Model.Repositories;

namespace ApiClinic.Controllers
{
    public class KindController : Controller
    {
        IRepository<Kind> repository;
        public KindController(IRepository<Kind> repository)
        {
            this.repository = repository;
        }
        // GET: Kind
        public ActionResult Index()
        {
            return View(this.repository.Get());
        }

        // GET: Kind/Create
        public ActionResult Create()
        {
            return View(new Kind());
        }

        // POST: Kind/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Kind kind)
        {
            try
            {
                // TODO: Add insert logic here
                this.repository.Add(kind);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(kind);
            }
        }

        // GET: Kind/Edit/5
        public ActionResult Edit(int id)
        {
            return View(this.repository.GetById(id));
        }

        // POST: Kind/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Kind kind)
        {
            try
            {
                // TODO: Add update logic here
                this.repository.Update(kind);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(kind);
            }
        }

        // GET: Kind/Delete/5
        public ActionResult Delete(int id)
        {
            return View(this.repository.GetById(id));
        }

        // POST: Kind/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            try
            {
                // TODO: Add delete logic here
                this.repository.Remove(this.repository.GetById(id));
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}