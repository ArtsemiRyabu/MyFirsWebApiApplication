using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System;

namespace WebAPI1.Domain.Models
{
    public class ComputerOrder
    {
        public int ComputerOrderId { get; set; }
        [Required(ErrorMessage = "Не указана дата")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime OrderDate { get; set; }
        [Required(ErrorMessage = "Не указана дата")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ExecutionDate { get; set; }
        public Customer Customer { get; set; }
        [Display(Name = "Клиент")]
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "Не указана предоплата")]
        [Display(Name = "Предоплата")]
        public double Prepayment { get; set; }
        [Required(ErrorMessage = "Не указана рабочая марка")]
        [Display(Name = "Рабочая марка")]
        public string Workmark { get; set; }
        [Required]
        [Range(1, 10000, ErrorMessage = "Недопустимая цена")]
        [Display(Name = "Полная цена")]
        [DataType(DataType.Currency)]
        public double AllCost { get; set; }
        [Required]
        [Display(Name = "Гарантийный срок")]
        public string GuaranteePeriod { get; set; }
        public Employee Employee { get; set; }
        [Display(Name = "Работник")]
        public int EmployeeId { get; set; }
        public ICollection<ComponentsList> ComponentsLists { get; set; }
        public ICollection<ServicesList> ServicesLists { get; set; }
        public ComputerOrder()
        {
            ComponentsLists = new List<ComponentsList>();
            ServicesLists = new List<ServicesList>();
        }
    }
}
