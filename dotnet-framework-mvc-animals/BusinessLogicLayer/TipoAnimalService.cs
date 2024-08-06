using dotnet_framework_mvc_animals.DataAccesLayer;
using dotnet_framework_mvc_animals.Models;
using System.Collections.Generic;

namespace dotnet_framework_mvc_animals.BusinessLogicLayer
{
    public class TipoAnimalService
    {
        private TipoAnimalRepository _repository;

        public TipoAnimalService()
        {
            _repository = new TipoAnimalRepository();
        }

        public List<TipoAnimal> GetTipoAnimalList()
        {
            return _repository.GetTipoAnimalListFromDB();
        }

        public void InsertNewTipoAnimal(TipoAnimal newTipoAnimal)
        {

            _repository.InsertTipoAnimalToDB(newTipoAnimal);
        }

        public void UpdateTipoAnimal(TipoAnimal updateTipoAnimal)
        {
            _repository.UpdateTipoAnimalInDB(updateTipoAnimal);
        }

        public void DeleteTipoAnimal(int idTipoAnimal)
        {
            _repository.DeleteTipoAnimalFromDB(idTipoAnimal);
        }
    }
}