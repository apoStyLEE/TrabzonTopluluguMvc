using System.Collections.Generic;
using System.Web.Mvc;
using TrabzonToplulugu.Extensions;
using TrabzonToplulugu.Models;
using TrabzonToplulugu.Models.FormModel;
using TrabzonToplulugu.Repositories;

namespace TrabzonToplulugu.Controllers
{

    
    public class MemberController : ApiBaseController
    {
               
        public ActionResult Index()
        {
            var allMembers = InMemoryMemberRepository.GetAllMembers();
            return View(allMembers.ToMemberViewModel());
        }

        public ActionResult Get(int id)
        {
            var member = InMemoryMemberRepository.GetMemberWithId(id);
            return View(member.ToMemberViewModel());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(MemberFormModel form)
        {
            if (!ModelState.IsValid)
            {
                return View(form);
            }

            var member = new Member
                             {
                                 Name = form.Name,
                                 Surname = form.Surname,
                                 Email = form.Email,
                                 Password = form.Password
                             };

            var newMember = InMemoryMemberRepository.CreateMember(member);

            return RedirectToAction("Get", "Member", new { newMember.Id });
        }

        public ActionResult Update(int id)
        {
            var member = InMemoryMemberRepository.GetMemberWithId(id);

            var memberFormModel = new MemberFormModel
                                      {
                                          Name = member.Name,
                                          Surname = member.Surname,
                                          Email = member.Email
                                      };

            return View(memberFormModel);
        }

        [HttpPost]
        public ActionResult Update(int id, MemberFormModel form)
        {

            if (!ModelState.IsValid)
            {
                return View(form);
            }

            InMemoryMemberRepository.UpdateMember(id, form.Name, form.Surname, form.Email, form.Password);


            return RedirectToAction("Get", "Member", new { id });
        }


        public ActionResult Delete(int id)
        {
            InMemoryMemberRepository.Delete(id);
            return RedirectToAction("Index", "Member");
        }
    }
}