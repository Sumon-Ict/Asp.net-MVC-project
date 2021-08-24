using AutoMapper;
using SocialNetwork.Common.Utilities;
using SocialNetwork.Training.BusinessObjects;
using SocialNetwork.Training.Exceptions;
using SocialNetwork.Training.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Training.Services
{
    public class MemberService : IMemberService
    {

        private readonly ITrainingUnitOfWork _trainingUnitOfWork;
        private readonly IMapper _mapper;
        private readonly IDateTimeUtility _dateTimeUtility;


        public MemberService(ITrainingUnitOfWork trainingUnitOfWork, 
            IMapper mapper,IDateTimeUtility dateTimeUtility)
        {
            _trainingUnitOfWork = trainingUnitOfWork;
            _mapper = mapper;
            _dateTimeUtility = dateTimeUtility;


        }
        public void CreateMember(Member member)
        {
            if (member == null)
                throw new InvalidParameterException("Member is not provided");

            if (IfNameAlreadyUsed(member.Name))
                throw new DuplicateNameException("this name is already used");
            if (IsInvalidDateOfBirth(member.DateOfBirth))
                throw new InvalidOperationException("member date time does not future date");


            _trainingUnitOfWork.Members.Add(_mapper.Map<Entities.Member>(member));
            _trainingUnitOfWork.Save();            

        }
        private bool IsInvalidDateOfBirth(DateTime dateofbirth) =>
            dateofbirth.Subtract(_dateTimeUtility.Now).TotalDays> 0;


        public void DeleteMember(int id)
        {
            _trainingUnitOfWork.Members.Remove(id);

            _trainingUnitOfWork.Save();

        }

        public Member GetMember(int id)
        {
            var member = _trainingUnitOfWork.Members.GetById(id);

            return _mapper.Map<Member>(member);

        }

        public (IList<Member> records, int total, int totalDisplay) GetMembers(int pageIndex, int pageSize, string searchText, string sortText)
        {
           
            var memberData = _trainingUnitOfWork.Members.GetDynamic(
                string.IsNullOrEmpty(searchText) ? null : x => x.Name.Contains(searchText),
                sortText, string.Empty, pageIndex, pageSize);


            var resultData = (from member in memberData.data
                              select _mapper.Map<Member>(member)).ToList();

            return (resultData, memberData.total, memberData.totalDisplay);

        }

        public void UpdateMember(Member member)
        {
            if (member == null)
                throw new InvalidParameterException("member is not provided for update");

            if (IfNameAlreadyUsed(member.Name, member.Id))
                throw new DuplicateNameException("this name alreadt used in anather member");

                    var  memberEntity = _trainingUnitOfWork.Members.GetById(member.Id);

            if (memberEntity != null)
            {
                _mapper.Map(member, memberEntity);

                _trainingUnitOfWork.Save();


            }
            else
                throw new InvalidOperationException("member could not found for update");

        }


        private bool IfNameAlreadyUsed(string name) =>
            _trainingUnitOfWork.Members.GetCount(x => x.Name == name) > 0;

        private bool IfNameAlreadyUsed(string name, int id) =>
            _trainingUnitOfWork.Members.GetCount(x => x.Name == name && x.Id != id) > 0;



    }
}
