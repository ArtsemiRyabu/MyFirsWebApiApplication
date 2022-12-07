using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WebAPI1.Domain.Models
{
    public class ComputerService
    {
        [Required]
        [Display(Name = "Id")]
        public int ComputerServiceId { get; set; }
        [Required]
        [Display(Name = "Название сервиса")]
        public string Name { get; set; }
        [Required]
        [Range(1, 10000, ErrorMessage = "Недопустимая цена")]
        [Display(Name = "Цена")]
        [DataType(DataType.Currency)]
        public double Cost { get; set; }
        public ICollection<ServicesList> ServicesLists { get; set; }
        public ComputerService()
        {
            ServicesLists = new List<ServicesList>();
        }
    }
}
