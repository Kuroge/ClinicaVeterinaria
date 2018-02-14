using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiClinic.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Model.Repositories;

namespace ApiClinic.Controllers
{
    public class ClientController : Controller
    {
        
        private IMapper _mapper;
        IRepository<Client> repository;
        public ClientController(IRepository<Client> repository, IMapper mapper )
        {
            this.repository = repository;
            this._mapper = mapper;
        }
        // GET: Client
        public ActionResult Index()
        {
            return View(_mapper.Map<IEnumerable<VMClient>>(this.repository.Get()));
        }

        // GET: Client/Create
        public ActionResult Create()
        {
            return View(new VMClient());
        }

        // POST: Client/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VMClient vmclient)
        {
            if (ModelState.IsValid)
            {
                this.repository.Add(_mapper.Map<Client>(vmclient));
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(vmclient);
            }
        }

        // GET: Client/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<VMClient>(this.repository.GetById(id)));
        }

        // POST: Client/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, VMClient vmclient)
        {
            try
            {
                // TODO: Add update logic here
                this.repository.Update(_mapper.Map<Client>(vmclient));
                
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Client/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<VMClient>(this.repository.GetById(id)));
        }

        // POST: Client/Delete/5
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