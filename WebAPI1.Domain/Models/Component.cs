using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System;

namespace WebAPI1.Domain.Models
{
    public class Component
    {
        [Required]
        [Display(Name = "Id")]
        public int ComponentId { get; set; }
        [Required(ErrorMessage = "Не указана марка")]
        [Display(Name = "Марка")]
        public string Mark { get; set; }
        [Required(ErrorMessage = "Не указана фирма")]
        [Display(Name = "Фирма")]
        public string Firm { get; set; }
        [Required(ErrorMessage = "Не указана страна")]
        [Display(Name = "Страна")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Не указана дата")]
        [Display(Name = "Дата производства")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateComponent { get; set; }
        [Required(ErrorMessage = "Не указаны характеристики")]
        [Display(Name = "Характеристики")]
        public string Charcterist { get; set; }
        [Required(ErrorMessage = "Не указан гарантийный период")]
        [Display(Name = "Гарантия")]
        public string GuaranteePeriod { get; set; }
        [Required(ErrorMessage = "Не указано описание")]
        [Display(Name = "Описание")]
        public string Description { get; set; }
        [Range(1, 10000, ErrorMessage = "Недопустимая цена")]
        [Display(Name = "Цена")]
        [DataType(DataType.Currency)]
        public double Cost { get; set; }
        public TypeComponent TypeComponent { get; set; }
        [Display(Name = "Тип компонента")]
        public int TypeComponentId { get; set; }
        public ICollection<ComponentsList> СomponentsLists { get; set; }
        public Component()
        {
            СomponentsLists = new List<ComponentsList>();
        }
    }
}
