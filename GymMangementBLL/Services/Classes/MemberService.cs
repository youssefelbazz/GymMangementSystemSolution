using GymMangementBLL.Services.Interfaces;
using GymMangementBLL.ViewModels;
using GymMangementBLL.ViewModels.MemberViewModels;
using GymMangementDAL.Entities;
using GymMangementDAL.Entities.Enums;
using GymMangementDAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangementBLL.Services.Classes
{
    internal class MemberService : IMemberService
    {
        private readonly IGenericRepository<Member> _memberRepository;
        private readonly IGenericRepository<MemberShip> _memberShipRepository;
        private readonly IPlanRepository _planRepository;
        private readonly IGenericRepository<GymMangementDAL.Entities.HealthRecord> _healthrecordRepository;

        // روح ف ال main عشان تسجل ال service دي في ال container
        public MemberService(IGenericRepository<Member> memberRepository, IGenericRepository<MemberShip> memberShipRepository,IPlanRepository planRepository,IGenericRepository<GymMangementDAL.Entities.HealthRecord> healthrecordRepository)
        {
            _memberRepository = memberRepository;
            _memberShipRepository = memberShipRepository;
            _planRepository = planRepository;
            _healthrecordRepository = healthrecordRepository;
        }

        public bool CreateMember(CreateMemberViewModel createMemberViewModel)
        {

            try
            {
                //check if the email already exists
                //check if the phone already exists
                //if one of them exists return false
                //if not create the member and return true and add it to the database

                var emailExists = _memberRepository.GetAll(m => m.Email == createMemberViewModel.Email).Any();
                var phoneExists = _memberRepository.GetAll(m => m.Phone == createMemberViewModel.Phone).Any();
                if (phoneExists || emailExists) return false;

                var member = new Member()
                {
                    Name = createMemberViewModel.Name,
                    Phone = createMemberViewModel.Phone,
                    Email = createMemberViewModel.Email,
                    Gender = createMemberViewModel.Gender,
                    DateOfBirth = createMemberViewModel.DateOfBirth,
                    Address = new Address()
                    {
                        BuildingNumber = createMemberViewModel.BuildingNumber,
                        Street = createMemberViewModel.Street,
                        City = createMemberViewModel.City
                    },
                    HealthRecord = new GymMangementDAL.Entities.HealthRecord()
                    {
                        BloodType = createMemberViewModel.HealthRecordViewModel.BloodType,
                        Height = createMemberViewModel.HealthRecordViewModel.Height,
                        Weight = createMemberViewModel.HealthRecordViewModel.Weight,
                        Note = createMemberViewModel.HealthRecordViewModel.Note
                    }
                };

                return _memberRepository.Add(member) > 0;
            }

            catch (Exception)
            {

                return false;
            }

        }

        public IEnumerable<MemberViewModel> GetAllMembers()
        {
            #region Manual mapping02
            var members = _memberRepository.GetAll();
            if (members == null || !members.Any()) return [];
            var memberViewModels = members.Select(member => new MemberViewModel
            {
                Id = member.Id,
                Name = member.Name,
                Email = member.Email,
                Phone = member.Phone,
                Photo = member.Photo,
                Gender = member.Gender.ToString()

            });
            return memberViewModels;
            #endregion
            #region Manual mapping
            //var memberViewModels = new List<MemberViewModel>();

            //foreach (var member in members)
            //{
            //    var memberViewModel = new MemberViewModel()
            //    {
            //        Id = member.Id,
            //        Name = member.Name,
            //        Email = member.Email,
            //        Phone = member.Phone,
            //        Photo = member.Photo,
            //        Gender = member.Gender.ToString()


            //    };

            //    memberViewModels.Add(memberViewModel);

            //}
            //return memberViewModels; 
            #endregion

        }

        public MemberViewModel? GetMemberDetails(int memberId)
        {

            var Member = _memberRepository.GetById(memberId);
            if (Member == null) return null;

            var memberViewModel = new MemberViewModel()
            {
            
                Name = Member.Name,
                Email = Member.Email,
                Phone = Member.Phone,
                Photo = Member.Photo,
                Gender= Member.Gender.ToString(),
                DateOfBirth = Member.DateOfBirth.ToString("yyyy-MM-dd"),
                Address = $"{Member.Address.BuildingNumber} - {Member.Address.Street} - {Member.Address.City}",


            };
            var activeMemberShip = _memberShipRepository.GetAll(ms => ms.MemberId == memberId&&ms.Status =="Active").FirstOrDefault();
            if (activeMemberShip is not null)
            {
                memberViewModel.MembershipStartDate = activeMemberShip.CreatedAt.ToShortDateString();
                memberViewModel.MembershipEndDate = activeMemberShip.EndDate.ToShortDateString();
                var plan = _planRepository.GetById(activeMemberShip.PlanId);
                memberViewModel.PlanName = plan?.Name;
            }

            return memberViewModel;
        }

        public HealthRecordViewModel? GetMemberHealthRecordDetails(int memberId)
        {
            var healthRecord = _healthrecordRepository.GetById(memberId);
            if (healthRecord == null) return null;
            return new ViewModels.HealthRecordViewModel()
            {
                Height = healthRecord.Height,
                Weight = healthRecord.Weight,
                BloodType = healthRecord.BloodType,
                Note = healthRecord.Note
            };




        }
    }
}