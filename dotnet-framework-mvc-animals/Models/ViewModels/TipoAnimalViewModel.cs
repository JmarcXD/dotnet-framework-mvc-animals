using System.ComponentModel.DataAnnotations;

namespace dotnet_framework_mvc_animals.Models.ViewModels
{
    public class TipoAnimalViewModel
    {
        public int IdTipoAnimal { get; set; }

        [Required]                      //Viene de la libreria system.datanotations
        [DataType(DataType.Text)]       //Viene de la libreria system.datanotations
        [Display(Name = "Descripion")]  //Viene de la libreria system.datanotations
        public string TipoDescripcion { get; set; }
    }
}