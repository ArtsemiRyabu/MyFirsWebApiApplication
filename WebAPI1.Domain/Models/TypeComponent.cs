using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace WebAPI1.Domain.Models
{
    public class TypeComponent
    {
        [Required]
        [Display(Name = "Id")]
        public int TypeComponentId { get; set; }
        [Required(ErrorMessage = "Не указан тип компонента")]
        [Display(Name = "Имя типа компонента")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Не указано описание")]
        [Display(Name = "Описание")]
        public string Description { get; set; }
        public ICollection<Component> Components { get; set; }
        public TypeComponent()
        {
            Components = new List<Component>();
        }
    }
}
