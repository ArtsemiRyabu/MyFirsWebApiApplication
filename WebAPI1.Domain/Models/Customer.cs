using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WebAPI1.Domain.Models
{
    public class Customer
    {
        [Required]
        [Display(Name = "Id")]
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "Не указано имя клиента")]
        [Display(Name = "Имя клиента")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Не указан адрес клиента")]
        [Display(Name = "Адрес клиента")]
        public string Address { get; set; }
        [Display(Name = "Телефон")]
        [Phone (ErrorMessage = "Неверно введены  данные телефона")]
        public string Phone { get; set; }
        [Range(1, 50, ErrorMessage = "Недопустимая скидка")]
        public double Sale { get; set; }
        public ICollection<ComputerOrder> ComputerOrders { get; set; }
        public Customer()
        {
            ComputerOrders = new List<ComputerOrder>();
        }
    }
}
