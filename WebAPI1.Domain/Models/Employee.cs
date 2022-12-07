using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WebAPI1.Domain.Models
{
    public class Employee
    {
        [Required]
        [Display(Name = "Id")]
        public int EmployeeId { get; set; }
        [Required(ErrorMessage = "Не указано имя сотрудника")]
        [Display(Name = "Имя сотрудника")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Не указана должность")]
        [Display(Name = "Должность")]
        public string JobTitle { get; set; }
        public ICollection<ComputerOrder> ComputerOrders { get; set; }

        public Employee()
        {
            ComputerOrders = new List<ComputerOrder>();
        }

        public Employee(string name, string jobTitle)
        {
            Name = name;
            JobTitle = jobTitle;
        }
    }
}
