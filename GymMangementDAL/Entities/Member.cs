using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangementDAL.Entities
{
    internal class Member:GymUser
    {

        //join date == created at 
        public string? Photo { get; set; }

    }
}
