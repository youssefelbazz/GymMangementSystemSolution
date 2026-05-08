using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangementBLL.ViewModels
{
    internal class HealthRecordViewModel
    {
        [Required(ErrorMessage = "Height is required")]
        [Range(0.1 ,300,ErrorMessage ="Height must be between 0.1 and 300 cm")]
        public decimal Height { get; set; }

        [Required(ErrorMessage = "Weight is required")]
        [Range(0.1 ,500,ErrorMessage ="Weight must be between 0.1 and 500 kg")]
        public decimal Weight { get; set; }

        [Required(ErrorMessage = "Blood Type is required")]
        [StringLength(3, ErrorMessage = "Blood Type must be 3 characters or less")]
        public string  BloodType { get; set; }

        public string?  Note { get; set; }
    }
}
