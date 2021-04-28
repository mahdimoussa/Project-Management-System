using IdsProjectManagementSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdsProjectManagementSystem.Controllers
{
	public class MemberController : Controller
	{
		private readonly ApplicationDbContext db;
		public MemberController(ApplicationDbContext dbContext)
		{
			db = dbContext;
		}
		// GET: MemberController
		public ActionResult Index(int projectId)
		{
			var members = new List<Member>();
			try
			{
				members = db.Members.Where(m => m.FK_ProjectId == null).ToList();

			}
			catch (Exception e)
			{

			}
			ViewBag.projectId = projectId;

			return PartialView(members);

		}

		// GET: MemberController/Details/5
		public ActionResult Details(int id)
		{
			db.SaveChanges();
			return View();
		}


		public ActionResult Create(int memberId, int projectId)
		{
			Member member = new Member();
			try
			{
				member = db.Members.Find(memberId);
				member.FK_ProjectId = projectId;
				db.Members.Update(member);
				db.SaveChanges();
			}
			catch (Exception e)
			{

			}
			return RedirectToAction("Details", "Project", new { id = projectId });
		}


		// GET: MemberController/Edit/5
		public ActionResult Edit(int id)
		{
			Member member = new Member();
			try
			{
				member = db.Members.Find(id);
			}catch(Exception e)
			{

			}
			return View(member);
		}
		

		// POST: MemberController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(Member member)
		{
			try
			{
				db.Entry(member).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Edit");
			}
			catch(Exception e)
			{
				return View();
			}
		}

		// GET: MemberController/Delete/5
		public ActionResult Delete(int id, int projectId)
		{
			try
			{
				Member member = db.Members.Find(id);
				if (member == null)
				{
					throw new Exception("Model not found");
				}
				member.FK_ProjectId = null;
				db.Members.Update(member);
				db.SaveChanges();
			}
			catch(Exception e)
			{

			}

			return RedirectToAction("Details", "Project", new { id = projectId });
		}
		

	}
}
