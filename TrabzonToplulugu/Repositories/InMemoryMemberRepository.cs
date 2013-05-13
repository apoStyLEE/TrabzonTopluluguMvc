using System.Collections.Generic;
using System.Linq;
using TrabzonToplulugu.Models;

namespace TrabzonToplulugu.Repositories
{
    public static class InMemoryMemberRepository
    {
        private static Dictionary<int, Member> _members = new Dictionary<int, Member>();

        public static void FillExampleData()
        {
            _members[1] = new Member
                              {
                                  Id = 1,
                                  Name = "Abdullah",
                                  Surname = "Uğraşkan",
                                  Email = "ugraskan@gmail.com",
                                  Password = "123456"
                              };

            _members[2] = new Member
                              {
                                  Id = 2,
                                  Name = "Emre",
                                  Surname = "Tekelioğlu",
                                  Email = "emre@domain.com",
                                  Password = "123456"
                              };

            _members[3] = new Member
                              {
                                  Id = 3,
                                  Name = "Halit",
                                  Surname = "Alptekin",
                                  Email = "halit@domain.com",
                                  Password = "123456"
                              };

            _members[4] = new Member
                              {
                                  Id = 4,
                                  Name = "Halil İbrahim",
                                  Surname = "Nuroğlu",
                                  Email = "halil@ibo.com",
                                  Password = "123456"
                              };

            _members[5] = new Member
                            {
                                Id = 5,
                                Name = "Mehmet Ali",
                                Surname = "Gözaydın",
                                Email = "mehmet@domain.com",
                                Password = "123456"
                            };
        }


        public static Member GetMemberWithId(int id)
        {
            return _members[id];
        }

        public static Member CreateMember(Member member)
        {
            var max = _members.Max(c => c.Key) + 1;
            member.Id = max;
            var newMember = _members[max] = member;
            return newMember;
        }

        public static Member UpdateMember(int id, string name, string surname, string email, string password)
        {
            var updatedMember = _members[id] = new Member
                                                   {
                                                       Name = name,
                                                       Surname = surname,
                                                       Email = email,
                                                       Password = password
                                                   };

            return updatedMember;
        }

        public static IEnumerable<Member> GetAllMembers()
        {
            return _members.Select(m => m.Value);
        }

        public static void Delete(int id)
        {
            _members.Remove(id);
        }
    }
}