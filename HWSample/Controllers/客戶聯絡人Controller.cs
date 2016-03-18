using HWSample.ActionFilters;
using HWSample.Models;
using HWSample.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace HWSample.Controllers
{
    [ActionTime]
    public class 客戶聯絡人Controller : Controller
    {
        //private 客戶資料Entities entity = new 客戶資料Entities();
        private 客戶聯絡人Repository repository = RepositoryHelper.Get客戶聯絡人Repository();

        public ActionResult Index(string keyword)
        {
            var data = repository.All().AsQueryable();

            if (!String.IsNullOrEmpty(keyword))
            {
                //data = data.Where(p => p.職稱.Contains(keyword));
                data = repository.FindBy職稱(keyword);
            }

            IEnumerable<ContactIndexViewModel> vm = data.Select(ConvertToVM);

            return View(vm);
        }

        [HttpPost]
        public ActionResult Index(IList<ContactViewModel> model)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in model)
                {
                    var contact = repository.Find(item.Id);
                    contact.職稱 = item.Title;
                    contact.手機 = item.CellPhone;
                    contact.電話 = item.Phone;
                }

                repository.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }

            return View(repository.All());
        }

        // GET: 客戶聯絡人/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶聯絡人 客戶聯絡人 = repository.Find(id.Value);
            if (客戶聯絡人 == null)
            {
                return HttpNotFound();
            }
            return View(客戶聯絡人);
        }

        // GET: 客戶聯絡人/Create
        public ActionResult Create()
        {
            var db = (客戶資料Entities)repository.UnitOfWork.Context;
            ViewBag.客戶Id = new SelectList(db.客戶資料, "Id", "客戶名稱");
            return View();
        }

        // POST: 客戶聯絡人/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,客戶Id,職稱,姓名,Email,手機,電話,IsDeleted")] 客戶聯絡人 客戶聯絡人)
        {
            var db = (客戶資料Entities)repository.UnitOfWork.Context;
            if (ModelState.IsValid)
            {
                repository.Add(客戶聯絡人);
                repository.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }

            ViewBag.客戶Id = new SelectList(db.客戶資料, "Id", "客戶名稱", 客戶聯絡人.客戶Id);
            return View(客戶聯絡人);
        }

        // GET: 客戶聯絡人/Edit/5
        public ActionResult Edit(int? id)
        {
            var db = (客戶資料Entities)repository.UnitOfWork.Context;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶聯絡人 客戶聯絡人 = repository.Find(id.Value);
            if (客戶聯絡人 == null)
            {
                return HttpNotFound();
            }
            ViewBag.客戶Id = new SelectList(db.客戶資料, "Id", "客戶名稱", 客戶聯絡人.客戶Id);
            return View(客戶聯絡人);
        }

        // POST: 客戶聯絡人/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,客戶Id,職稱,姓名,Email,手機,電話,IsDeleted")] 客戶聯絡人 客戶聯絡人)
        {
            var db = (客戶資料Entities)repository.UnitOfWork.Context;
            if (ModelState.IsValid)
            {
                db.Entry(客戶聯絡人).State = EntityState.Modified;
                repository.UnitOfWork.Commit();
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.客戶Id = new SelectList(db.客戶資料, "Id", "客戶名稱", 客戶聯絡人.客戶Id);
            return View(客戶聯絡人);
        }

        // GET: 客戶聯絡人/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶聯絡人 客戶聯絡人 = repository.Find(id.Value);
            if (客戶聯絡人 == null)
            {
                return HttpNotFound();
            }
            return View(客戶聯絡人);
        }

        // POST: 客戶聯絡人/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //客戶聯絡人 客戶聯絡人 = db.客戶聯絡人.Find(id);
            客戶聯絡人 客戶聯絡人 = repository.Find(id);
            客戶聯絡人.IsDeleted = true;
            repository.UnitOfWork.Commit();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                var db = (客戶資料Entities)repository.UnitOfWork.Context;
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private ContactIndexViewModel ConvertToVM(客戶聯絡人 entity)
        {
            ContactIndexViewModel dao = new ContactIndexViewModel
            {
                Id = entity.Id,
                CustomerId = entity.客戶Id,
                Title = entity.職稱,
                Email = entity.Email,
                CellPhone = entity.手機,
                Phone = entity.電話,
                Customer = entity.客戶資料
            };
            return dao;
        }
    }
}