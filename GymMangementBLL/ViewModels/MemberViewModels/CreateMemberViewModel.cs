using GymMangementDAL.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangementBLL.ViewModels.MemberViewModels
{
    internal class CreateMemberViewModel
    {
        [Required(ErrorMessage="Name is required")]
        [StringLength(50,MinimumLength =2,ErrorMessage = "Name Must Be Between 2 and 50 characters")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Name can only contain letters and spaces")]
        public string Name { get; set; } = null!;


        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage ="Invalid Email Format")]
        [DataType(DataType.EmailAddress)]//UI Hint
        [StringLength(100,MinimumLength =5,ErrorMessage = "Email Must Be Between 5 and 100 characters")]
        public string Email { get; set; }



        [Required(ErrorMessage="Phone is required")]
        [Phone(ErrorMessage ="Invalid Phone Number")]
        [RegularExpression(@"^(010|011|012|015)\d{8}$", ErrorMessage = "Phone can only be Egyptian numbers")]
        [DataType(DataType.PhoneNumber)]
        public string  Phone { get; set; }


        [DataType(DataType.Date)]
        [Required(ErrorMessage="Date of Birth is required")]
        public DateOnly DateOfBirth { get; set; }


        [Required(ErrorMessage= "Gender is required")]
        public Gender Gender { get; set; }



        [Required(ErrorMessage= "BuildingNumber is required")]
        [Range(1, 9000, ErrorMessage = "BuildingNumber must be a positive number")]
        public int BuildingNumber { get; set; }

        [Required(ErrorMessage = "Street is required")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Street must be between 2 and 30 characters")]
        public string Street { get; set; } = null!;


        [Required(ErrorMessage= "City is required")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "City must be between 2 and 30 characters")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "City can only contain letters and spaces")]
        public string City { get; set; } = null!;

        [Required(ErrorMessage= "Health Record is required")]
        public HealthRecordViewModel HealthRecordViewModel { get; set; } = null!;



    }
}
