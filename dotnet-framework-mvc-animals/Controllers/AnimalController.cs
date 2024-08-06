using dotnet_framework_mvc_animals.BusinessLogicLayer;
using dotnet_framework_mvc_animals.Models;
using dotnet_framework_mvc_animals.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace dotnet_framework_mvc_animals.Controllers
{
    public class AnimalController : Controller
    {
        private AnimalService _animalService;
        private TipoAnimalService _tipoAnimalService;

        public AnimalController()
        {
            _animalService = new AnimalService();
            _tipoAnimalService = new TipoAnimalService();
        }

        // GET: Animal
        public ActionResult Index()
        {
            List<Animal> animals = _animalService.GetAnimalList();


            Random rnd = new Random();

            int randomNumber = rnd.Next(0, animals.Count - 1);

            ViewBag.luckyAnimal = $"Tu animal de la suerte es {animals[randomNumber].NombreAnimal}";

            return View(animals);
        }

        public ActionResult NewAnimalForm()
        {
            List<TipoAnimal> tipoAnimals = _tipoAnimalService.GetTipoAnimalList();

            AnimalViewModel model = new AnimalViewModel();
            model.tipoAnimals = tipoAnimals;


            return View(model);
        }

        [HttpPost]
        public ActionResult InsertNewAnimal(string NombreAnimal, string Raza, int RIdTipoAnimal, DateTime FechaNacimiento)
        {
            Animal newAnimal = new Animal();

            newAnimal.NombreAnimal = NombreAnimal;
            newAnimal.Raza = Raza;
            newAnimal.RIdTipoAnimal = RIdTipoAnimal;
            newAnimal.FechaNacimiento = FechaNacimiento;

            _animalService.InsertNewAnimal(newAnimal);

            return RedirectToAction("Index");
        }

        public ActionResult DeleteAnimalForm() 
        {
            List<Animal> animals = _animalService.GetAnimalList();

            return View(animals);
        }


        [HttpDelete]
        public ActionResult DeleteAnimal(int idAnimal)
        {
            return RedirectToAction("Index");
        }
        
    }
}