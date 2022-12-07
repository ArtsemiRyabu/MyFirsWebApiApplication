using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAPI1.Domain.Models
{
    public class ServicesList
    {
        [Required]
        public int ServicesListId { get; set; }
        [Required]
        public int ComputerServiceId { get; set; }
        [Required]
        public int ComputerOrderId { get; set; }
        public ComputerService ComputerService { get; set; }
        public ComputerOrder ComputerOrder { get; set; }
    }
}


