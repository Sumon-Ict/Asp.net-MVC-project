using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Admin.BusinessObject
{
    public class Photo
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public string PhotoFileNam { get; set; }
        public string MemberName { get; set; }
    }
}
