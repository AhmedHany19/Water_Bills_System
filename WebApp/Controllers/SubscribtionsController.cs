using Domain.IRepositiory;
using Domain.Model;
using Infrastructure.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;

namespace WebApp.Controllers
{
    public class SubscribtionsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public SubscribtionsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Subscribtions()
        {
            return View(new SubscribtionsViewModel
            {
                Subscriptions= _unitOfWork.Subscriptions.GetAll(new[] { "Subscriber", "Real_Estate_Type" }),
                Subscription=new Subscription(),
                Real_Estate_Types=_unitOfWork.Real_Estate_Types.GetAll(),
                Subscribers=_unitOfWork.Subscribers.GetAll(),
            });
        }

        public IActionResult Create()
        { 
          
            return View(new SubscribtionsViewModel
            {
                Real_Estate_Types = _unitOfWork.Real_Estate_Types.GetAll(),
                Subscribers = _unitOfWork.Subscribers.GetAll(),
                Subscription = new Subscription(),
                Subscriptions = _unitOfWork.Subscriptions.GetAll(new[] { "Subscriber", "Real_Estate_Type" })

            });

        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SubscribtionsViewModel model)
        {
            model.Subscription.Id = DateTime.Now.ToString("yy-MM-mmss");
            var sub = _unitOfWork.Subscriptions.Exists(x=>x.Id==model.Subscription.Id);
            if (sub)
            {
                ViewData["Message"] = "هذا الاشتراك مسجل بالفعل !!!";           
                return View(model);
            }
           
            _unitOfWork.Subscriptions.Add(model.Subscription);
            _unitOfWork.Complete();
           
            return RedirectToAction("Subscribtions");

        }



        [HttpGet]
        public IActionResult Edit(string id)
        {
            if (id == null || id == "")
            {
                return NotFound();
            }

            var subscription = _unitOfWork.Subscriptions.Find(x=>x.Id==id, new[] { "Subscriber", "Real_Estate_Type" });
             
            if (subscription == null)
            {
                return NotFound();
            }
            return View(new SubscribtionsViewModel
            {
                Real_Estate_Types = _unitOfWork.Real_Estate_Types.GetAll(),
                Subscribers = _unitOfWork.Subscribers.GetAll(),
                Subscription = subscription,
                Subscriptions = _unitOfWork.Subscriptions.GetAll(new[] { "Subscriber", "Real_Estate_Type" })
            });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, SubscribtionsViewModel model)
        {
            

            var subscription = _unitOfWork.Subscriptions.Find(x=>x.Id== id);
            if (subscription == null)
            {
                return NotFound();
            }

            if (id != model.Subscription.Id)
            {
                return NotFound();
            }

            subscription.No=model.Subscription.No;
            subscription.Comments=model.Subscription.Comments;
            subscription.Real_State_Id =model.Subscription.Real_State_Id;
            subscription.Subscriber_Id =model.Subscription.Subscriber_Id;
            subscription.Is_There_Sanitation =model.Subscription.Is_There_Sanitation;




            _unitOfWork.Subscriptions.Update(subscription);
            _unitOfWork.Complete();      
            return RedirectToAction("Subscribtions");
        }

        public IActionResult Delete(string id)
        {
            if (id == null || id == "")
            {
                return NotFound();
            }
            var subscription = _unitOfWork.Subscriptions.GetById(id);
            if (subscription == null)
            {
                return NotFound();
            }
            return View(new SubscribtionsViewModel
            {
                Real_Estate_Types = _unitOfWork.Real_Estate_Types.GetAll(),
                Subscribers = _unitOfWork.Subscribers.GetAll(),
                Subscription = subscription,
                Subscriptions = _unitOfWork.Subscriptions.GetAll(new[] { "Subscriber", "Real_Estate_Type" })
            });
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmDelete(string id)
        {
            if (id == null || id == "")
            {
                return NotFound();
            }
            var subscription = _unitOfWork.Subscriptions.GetById(id);
            if (subscription == null)
            {
                return NotFound();
            }
            _unitOfWork.Subscriptions.Delete(subscription);
            _unitOfWork.Complete();
            return RedirectToAction("Subscribtions");
        }






        //[HttpGet]
        //public IActionResult Search(string id)
        //{
        //    if (id == null || id == "")
        //    {
        //        ViewData["Message"] = "الرجاء ادخال الكود   !!!";
        //        return View();
        //    }

        //    var subscriptions = _unitOfWork.Subscriptions.FindAll(x=>x.Subscriber.Id==id, new[] { "Subscriber", "Real_Estate_Type" });
        //    if (subscriptions == null)
        //    {
        //        ViewData["Message"] = "لا يوجد مشترك بهذا الكود    !!!";
        //        return View();
        //    }
        //    return View("Subscribtions", new SubscribtionsViewModel
        //    {
        //        Real_Estate_Types = _unitOfWork.Real_Estate_Types.GetAll(),
        //        Subscribers = _unitOfWork.Subscribers.GetAll(),
        //        Subscription = new Subscription(),
        //        Subscriptions = subscriptions

        //    });
        //}
    }
}
