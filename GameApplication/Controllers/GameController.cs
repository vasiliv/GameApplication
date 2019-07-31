using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GameApplication.DAL;
using GameApplication.Models;

namespace GameApplication.Controllers
{
    public class GameController : Controller
    {
        //private GameContext db = new GameContext();
        private UnitOfWork unitOfWork = new UnitOfWork();
        // GET: Game
        public ActionResult Index()
        {
            var games = unitOfWork.GameRepository.Get();
            //return View(db.Games.ToList());            
            return View(games.ToList());
        }

        // GET: Game/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Game game = db.Games.Find(id);
            Game game = unitOfWork.GameRepository.GetByID(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // GET: Game/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Game/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Game game)
        {
            if (ModelState.IsValid)
            {
                //db.Games.Add(game);
                //db.SaveChanges();
                unitOfWork.GameRepository.Update(game);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(game);
        }

        // GET: Game/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Game game = db.Games.Find(id);
            Game game = unitOfWork.GameRepository.GetByID(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // POST: Game/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Game game)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(game).State = EntityState.Modified;
                //db.SaveChanges();
                unitOfWork.GameRepository.Update(game);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(game);
        }

        // GET: Game/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Game game = db.Games.Find(id);
            Game game = unitOfWork.GameRepository.GetByID(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // POST: Game/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Game game = db.Games.Find(id);
            //db.Games.Remove(game);
            //db.SaveChanges();
            Game game = unitOfWork.GameRepository.GetByID(id);
            unitOfWork.GameRepository.Delete(id);
            unitOfWork.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
                unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
