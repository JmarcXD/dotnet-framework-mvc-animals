using dotnet_framework_mvc_animals.Models.ViewModels;
using dotnet_framework_mvc_animals.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using dotnet_framework_mvc_animals.DataAccesLayer;

namespace dotnet_framework_mvc_animals.BusinessLogicLayer
{
    public class AnimalService
    {
        private AnimalRepository _repository;

        public AnimalService()
        {
            _repository = new AnimalRepository();
        }
        public List<Animal> GetAnimalList()
        {
            return _repository.GetAnimalListFromDB();
        }

        public void InsertNewAnimal(Animal newAnimal)
        {
            _repository.InsertAnimalToDB(newAnimal);
        }

        public void UpdateTipoAnimal(Animal animal)
        {

            _repository.UpdateAnimalInDB(animal);
        }

        public void DeleteTipoAnimal(int idAnimal)
        {
            _repository.DeleteAnimalFromDB(idAnimal);
        }
    }
}