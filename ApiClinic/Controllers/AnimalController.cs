using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiClinic.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Model;
using Model.Repositories;

namespace ApiClinic.Controllers
{
    public class AnimalController : Controller
    {
        IRepository<Animal> repository;
        IRepository<Client> clientRepository;
        IRepository<Kind> kindRepository;

        private IMapper _mapper;
        public AnimalController(IRepository<Animal> repository, 
                                IRepository<Client> repositoryClient, 
                                IRepository<Kind> repositoryKind, IMapper mapper)
        {
            this.repository = repository;
            this._mapper = mapper;
            this.clientRepository = repositoryClient;
            this.kindRepository = repositoryKind;
        }
        // GET: Animal
        public ActionResult Index()
        {
            return View(_mapper.Map<IEnumerable<VMAnimal>>(this.repository.Get()));
        }


        // GET: Animal/Create
        public ActionResult Create()
        {

            return View(new VMAnimalList() { Clients = _mapper.Map<IEnumerable<SelectListItem>>(this.clientRepository.Get()),
                                             Species = _mapper.Map<IEnumerable<SelectListItem>>(this.kindRepository.Get())
            });
        }

        // POST: Animal/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VMAnimalList animal)
        {
            try
            {
                Animal animalDef = _mapper.Map<Animal>(animal);
                animalDef.Owner = this.clientRepository.GetById(animal.ClientId);
                animalDef.Species = this.kindRepository.GetById(animal.SpecieId);
                // TODO: Add insert logic here
                this.repository.Add(animalDef);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Animal/Edit/5
        public ActionResult Edit(int id)
        {
            VMAnimalList animalDef = _mapper.Map<VMAnimalList>(this.repository.GetById(id));
            animalDef.Clients = _mapper.Map<IEnumerable<SelectListItem>>(this.clientRepository.Get());
            animalDef.Species = _mapper.Map<IEnumerable<SelectListItem>>(this.kindRepository.Get());
            return View(animalDef);
        }

        // POST: Animal/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, VMAnimalList editAnimal)
        {
            try
            {
                // TODO: Add update logic here
                Animal animalEdit = _mapper.Map<Animal>(editAnimal);
                animalEdit.Owner = this.clientRepository.GetById(editAnimal.ClientId);
                animalEdit.Species = this.kindRepository.GetById(editAnimal.SpecieId);
                this.repository.Update(animalEdit);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(editAnimal);
            }
        }

        // GET: Animal/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_mapper.Map<VMAnimal>(this.repository.GetById(id)));
        }

        // POST: Animal/Delete/5
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