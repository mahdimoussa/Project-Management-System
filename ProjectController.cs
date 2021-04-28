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
	public class ProjectController : Controller
	{
		private readonly ApplicationDbContext db;
		public ProjectController(ApplicationDbContext dbContext)
		{
			db = dbContext;
		}
		// GET: ProjectController
		public ActionResult Index()
		{
			var projects = db.Projects.ToList();
			return View(projects);
		}

		// GET: ProjectController/Create
		public ActionResult Create()
		{
			return View();
		}


		// POST: ProjectController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(Project project)
		{
			try
			{
				if(project != null)
				{
					db.Projects.Add(project);
					db.SaveChanges();
					return RedirectToAction("Index");
				}
				else
				{
					throw new Exception("Project model is null");
				}
			}
			catch
			{
				return View();
			}
		}

		// GET: ProjectController/Edit/5
		public ActionResult Edit(int id)
		{
			Project project = new Project();
			try
			{
				project = db.Projects.Find(id);
				if (project == null)
				{
					throw new Exception("Model not found");
				}

			}
			catch (Exception e)
			{
			}
			return View(project);

		}

		// POST: ProjectController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(Project projectFromForm)
		{
			try
			{	
				db.Projects.Update(projectFromForm);
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

		public ActionResult Details(int id)
		{
			Project project = new Project();
			try
			{
				project = db.Projects
					.Where(m => m.ProjectId == id)
					.Include("Members")
					.FirstOrDefault();

			}catch(Exception e)
			{

			}
			return View(project);
		}

		// GET: ProjectController/Delete/5

		//public ActionResult Delete(int id)
		//{
		//	return View();
		//}

		// POST: ProjectController/Delete/5
		
		public ActionResult Delete(int id)
		{
			Project project = new Project();
			try
			{
				project = db.Projects.Find(id);
				if(project == null)
				{
					throw new Exception("Model not found");
				}
				db.Projects.Remove(project);
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}
	}
}
