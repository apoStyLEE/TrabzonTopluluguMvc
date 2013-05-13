using System.Collections.Generic;
using System.Linq;
using TrabzonToplulugu.Models;
using TrabzonToplulugu.Models.ViewModel;

namespace TrabzonToplulugu.Extensions
{
    public static class MemberViewModelExtensions
    {
        public static MemberViewModel ToMemberViewModel(this Member member)
        {
            var memberViewModel = new MemberViewModel
            {
                Id = member.Id,
                DisplayName = member.Name + " " + member.Surname
            };
            return memberViewModel;
        }

        public static IEnumerable<MemberViewModel> ToMemberViewModel(this IEnumerable<Member> members)
        {
            return members.Select(m => m.ToMemberViewModel());
        }

    }
}