using SocialNetwork.Admin.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Admin.Services
{
    public interface IMemberService
    {
        (IList<Member> records, int total, int totalDisplay) GetMembers(
            int pageIndex, int pageSize, string searchText, string sortText);
        void Add(Member member);
        void Delete(int id);
        Member GetMemberById(int id);
        void Edit(Member member);
    }
}
