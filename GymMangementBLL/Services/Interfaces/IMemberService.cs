using GymMangementBLL.ViewModels;
using GymMangementBLL.ViewModels.MemberViewModels;
using GymMangementDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangementBLL.Services.Interfaces
{
    internal interface IMemberService
    {

        IEnumerable<MemberViewModel> GetAllMembers();
       
        bool CreateMember(CreateMemberViewModel createMemberViewModel);

        MemberViewModel? GetMemberDetails(int memberId);

        HealthRecordViewModel? GetMemberHealthRecordDetails(int memberId);
        MemberToUpdateViewModel? GetMemberToUpdate(int memberId);
        bool UpdateMemberDetails(int memberId, MemberToUpdateViewModel updatedMember);

    }
}
