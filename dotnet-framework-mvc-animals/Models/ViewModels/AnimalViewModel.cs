using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace dotnet_framework_mvc_animals.Models.ViewModels
{
    public class AnimalViewModel
    {

        [Required]                      //Viene de la libreria system.datanotations
        [DataType(DataType.Text)]       
        [Display(Name = "Nombre Animal")] 
        public string NombreAnimal { get; set; }

        [Required]
        [DataType(DataType.Text)]      
        [Display(Name = "Raza")]
        public string Raza { get; set; }

        [Required]
        [Display(Name = "Tipo de animal")]
        public int RIdTipoAnimal { get; set; }

        [DataType(DataType.DateTime)]  
        [Display(Name = "Fecha de nacimiento")]
        public DateTime FechaNacimiento { get; set; }

        //Dropdown
        public List<TipoAnimal> tipoAnimals { get; set; }
    }
}