using SocialNetwork.Admin.BusinessObject;
using SocialNetwork.Admin.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Admin.Services
{
    public class MemberService : IMemberService
    {
        private readonly IAdminUnitOfWork _adminUnitOfWork;
        public MemberService(IAdminUnitOfWork adminUnitOfWork)
        {
            _adminUnitOfWork = adminUnitOfWork;
        }
        public void Add(Member member)
        {
            if (member == null)
                throw new InvalidOperationException("member not provided");
            else
            {
                try
                {
                    _adminUnitOfWork.Members.Add(new Entities.Member
                    {
                        Name = member.Name,
                        DateOfBirth = member.DateOfBirth,
                        Address = member.Address                        
                    });
                    _adminUnitOfWork.Save();
                }
                catch
                {
                    throw new Exception("member not added to db");
                }
            }
        }

        public void Delete(int id)
        {
            try
            {
                _adminUnitOfWork.Members.Remove(id);
                _adminUnitOfWork.Save();
            }
            catch
            {
                throw new Exception("Member not removed");
            }
        }

        public void Edit(Member member)
        {
            if (member == null)
                throw new InvalidOperationException("member not provided");
            else
            {
                var memberEntity = _adminUnitOfWork.Members.GetById(member.Id);
                if (memberEntity != null)                {
                    try
                    {
                        memberEntity.Name = member.Name;
                        memberEntity.DateOfBirth = member.DateOfBirth;
                        memberEntity.Address = member.Address;
                        _adminUnitOfWork.Save();
                    }
                    catch
                    {
                        throw new Exception("Not changed member");
                    }
                }
                else
                {
                    throw new InvalidOperationException("Couldn't find member");
                }
            }
        }

        public Member GetMemberById(int id)
        {
            var memberEntity = _adminUnitOfWork.Members.GetById(id);
            return new Member
            {
                Id = memberEntity.Id,
                Name = memberEntity.Name,
                DateOfBirth = memberEntity.DateOfBirth,
                Address = memberEntity.Address
            };
        }

        public (IList<Member> records, int total, int totalDisplay) GetMembers(int pageIndex, int pageSize, string searchText, string sortText)
        {
            var memberData = _adminUnitOfWork.Members.GetDynamic(
                string.IsNullOrWhiteSpace(searchText) ? null : x => x.Name.Contains(searchText), sortText,
                "", pageIndex, pageSize);
            var resultData = (from member in memberData.data
                              select new Member
                              {
                                  Id = member.Id,
                                  Name = member.Name,
                                  DateOfBirth = member.DateOfBirth,
                                  Address = member.Address
                              }).ToList();
            return (resultData, memberData.total, memberData.totalDisplay);
        }
    }
}
