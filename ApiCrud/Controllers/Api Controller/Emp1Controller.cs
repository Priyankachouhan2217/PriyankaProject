using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;
using ApiCrud.Models;
using ApiCrud.vm;

namespace ApiCrud.Controllers.Api_Controller
{
    [System.Web.Http.Authorize]
    public class Emp1Controller : ApiController
    {
        private CurdApiEntities1 db = new CurdApiEntities1();

        //GET: api/Emp1
        [System.Web.Http.Authorize]
        public IQueryable<Emp1> GetEmp1()
        {
            return db.Emp1;
        }
        [System.Web.Http.AllowAnonymous]
        //// GET: api/Emp1/5
        [ResponseType(typeof(Emp1))]
        public IHttpActionResult GetEmp1(int id)
        
        
        {
            abc();
            Emp1 emp1 = db.Emp1.Find(id);
            Emp1ViewModel model  = new Emp1ViewModel();
            model.EmpId = emp1.EmpID;
             model.EmpCity = emp1.EmpCity;
            model.EmpName = emp1.EmpName;
            model.EmpSal = emp1.EmpSal;

            if (emp1 == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        // PUT: api/Emp1/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmp1( Emp1 emp1)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

          //  if (id != emp1.EmpID)
          //  {
          //      return BadRequest();
         //   }

            db.Entry(emp1).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Emp1Exists(emp1.EmpID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Emp1
        [ResponseType(typeof(Emp1))]
        [System.Web.Http.AllowAnonymous]
        public IHttpActionResult PostEmp1(Emp1ViewModel _emp1ViewModel)
        {
            Emp1 emp = new Emp1()
            {
                EmpID = 12,
                EmpName = _emp1ViewModel.EmpName,
                EmpSal = _emp1ViewModel.EmpSal,
                EmpCity = _emp1ViewModel.EmpCity,

            };

            db.Emp1.Add(emp);

            db.SaveChanges();
            EmpAdd add = new EmpAdd()
            {

                Empid = 12,
                StreetName = _emp1ViewModel.StreetName,
                City = _emp1ViewModel.City,
                State = _emp1ViewModel.state,
                Country = _emp1ViewModel.Country,
            };
            try
            {
                db.EmpAdds.Add(add);
                db.SaveChanges();
            }
            catch(Exception ex)
            {

            }



            //return ;

            return CreatedAtRoute("DefaultApi", new { id = emp.EmpID }, emp);
        }

        // DELETE: api/Emp1/5
        [ResponseType(typeof(Emp1))]
        [System.Web.Http.AllowAnonymous]
        public IHttpActionResult DeleteEmp1(int id)
        {
            EmpAdd empADD= db.EmpAdds.Where(x=> x.Empid==id).FirstOrDefault();
            if (empADD == null)
            {
                return NotFound();
            }

            db.EmpAdds.Remove(empADD);
            db.SaveChanges();
            
            Emp1 emp1 = db.Emp1.Find(id);
            if (emp1 == null)
            {
                return NotFound();
            }

            db.Emp1.Remove(emp1);
            db.SaveChanges();

            return Ok(emp1);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Emp1Exists(int id)
        {
            return db.Emp1.Count(e => e.EmpID == id) > 0;
        }


        //  [System.Web.Mvc.Authorize]
         [System.Web.Http.AllowAnonymous]
        public IHttpActionResult find()
        {

            List<Emp1> emp1 = db.Emp1.ToList();
            if (emp1.Count > 0)
            {
                emp1 = emp1.Where(x => x.EmpID % 2 == 0).ToList();
                return Json(emp1);
            }
            return Json(emp1);
        }

        [System.Web.Http.AllowAnonymous]
        public void abc()
        {
            var x = (from a in db.Emp1
                     join  c in db.EmpAdds on a.EmpID equals c.Empid
                     select new Emp1ViewModel
                     {
                    City=a.EmpCity,
                    Country=c.Country,
                    EmpCity=a.EmpCity,
                    EmpId=a.EmpID,
                    EmpName=a.EmpName,
                    EmpSal=a.EmpSal,
                 ///   Id= c.Id,
                    state=c.State,
                    StreetName=c.StreetName
                     }).ToList();
        }
   //     var results = from data in userData
              //        join growth in userGrowth
              //        on data.User equals growth.User into joined
               //       from j in joined.DefaultIfEmpty()
               //       select new
               //       {
                //          UserData = data,
                  //        UserGrowth = j
                  //    };
   






    }
}