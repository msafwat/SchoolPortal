using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Entities;
using SchoolPortal.Models;
using System.Text.RegularExpressions;
using System.Web.Caching;
using System.Runtime.Caching;
using SchoolPortal.Controllers;
using SchoolPortal.ControllersHandlers;
using BusinessLogicLayer.Messages;

namespace SchoolPortal.Areas.Questions.Controllers
{
    public class QuestionsController : BaseController
    {
        // GET: Questions/Questions
        //public async Task<ActionResult> Index()
        //{
        //    var questions = db.Questions.Include(q => q.QuestionLevel).Include(q => q.QuestionType);
        //    return View(await questions.ToListAsync());
        //}

        // GET: Questions/Questions/Details/5
        //public async Task<ActionResult> Details(long? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Question question = await db.Questions.FindAsync(id);
        //    if (question == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(question);
        //}
        
        // GET: Questions/Questions/Create
        public ActionResult Create()
        {
            ViewBag.IsArabic = IsArabic;

            ViewBag.QuestionTypeId = new SelectList(MemoryCache.Default.Get("QuestionTypelList") as List<QuestionType>, "Id", Session["culture"].ToString() == "ar-EG" ? "NameAr" : "NameEn");
            ViewBag.QuestionLevelId = new SelectList(MemoryCache.Default.Get("QuestionLevelList") as List<QuestionLevel>, "Id", Session["culture"].ToString() == "ar-EG" ? "NameAr" : "NameEn");

            return View();
        }

        // POST: Questions/Questions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Text,Explanation,QuestionLevelId,QuestionTypeId")] Question question)
        {
            if (ModelState.IsValid)
            {
                question.Text = HttpUtility.HtmlEncode(new Regex(@"script", RegexOptions.IgnoreCase).Replace(question.Text, " _script"));

                //db.Questions.Add(question);
                //await db.SaveChangesAsync();
                
                ResponseCodeMessage res = facade.AddQuestion(question);
                if(res.Code == ReponseCode.SUCCESS)
                {
                    //res.Message
                }

                return RedirectToAction("Index");
            }

            ViewBag.IsArabic = IsArabic;

            ViewBag.QuestionTypeId = new SelectList(MemoryCache.Default.Get("QuestionTypelList") as List<QuestionType>, "Id", Session["culture"].ToString() == "ar-Eg" ? "NameAr" : "NameEn");
            ViewBag.QuestionLevelId = new SelectList(MemoryCache.Default.Get("QuestionLevelList") as List<QuestionLevel>, "Id", Session["culture"].ToString() == "ar-Eg" ? "NameAr" : "NameEn");

            return View(question);
        }

        // GET: Questions/Questions/Edit/5
        //public async Task<ActionResult> Edit(long? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Question question = await db.Questions.FindAsync(id);
        //    if (question == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.QuestionLevelId = new SelectList(db.QuestionLevels, "Id", "Name", question.QuestionLevelId);
        //    ViewBag.QuestionTypeId = new SelectList(db.QuestionTypes, "Id", "Name", question.QuestionTypeId);
        //    return View(question);
        //}

        // POST: Questions/Questions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Edit([Bind(Include = "Id,Details,Explanation,QuestionLevelId,QuestionTypeId")] Question question)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(question).State = EntityState.Modified;
        //        await db.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.QuestionLevelId = new SelectList(db.QuestionLevels, "Id", "Name", question.QuestionLevelId);
        //    ViewBag.QuestionTypeId = new SelectList(db.QuestionTypes, "Id", "Name", question.QuestionTypeId);
        //    return View(question);
        //}

        // GET: Questions/Questions/Delete/5
        //public async Task<ActionResult> Delete(long? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Question question = await db.Questions.FindAsync(id);
        //    if (question == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(question);
        //}

        // POST: Questions/Questions/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> DeleteConfirmed(long id)
        //{
        //    Question question = await db.Questions.FindAsync(id);
        //    db.Questions.Remove(question);
        //    await db.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //}
    }
}
