using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Models
{
    public class Warehouse
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is Required")]
        [MaxLength(60, ErrorMessage = "Name can be no more than 60 characters ")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is Required")]
        [MaxLength(100, ErrorMessage = "Description can be no more than 100 characters ")]
        public string Description { get; set; }

        [Required(ErrorMessage = "State is Required")]
        public bool State { get; set; }
    }
}
