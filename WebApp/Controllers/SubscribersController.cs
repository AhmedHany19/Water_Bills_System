using Domain.IRepositiory;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;
namespace WebApp.Controllers
{
    public class SubscribersController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public SubscribersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Subscribers()
        {

            return View(_unitOfWork.Subscribers.GetAll(new[] { "Subscriptions","Invoices" } ));
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Subscriber model)
        {
            if (SubscriberIdExists(model.Id))
            {
                ViewData["Message"] = "هذا الكود مسجل بالفعل , يجب عليك ادخال كود لم يستعمل من قبل !!!";
                return View(model);
            }        
            _unitOfWork.Subscribers.Add(model);
            _unitOfWork.Complete();
            return RedirectToAction("Subscribers");

        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            if (id == null || id == "")
            {

                return NotFound();
            }

            var subscriber = _unitOfWork.Subscribers.GetById(id);
            if (subscriber == null)
            {
                return NotFound();
            }
            return View(subscriber);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string id, Subscriber model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }            
            _unitOfWork.Subscribers.Update(model);
            _unitOfWork.Complete();

            return RedirectToAction("Subscribers");
        }

        public IActionResult Delete(string id)
        {
            if (id == null || id == "")
            {
                return NotFound();
            }
            var subscriber = _unitOfWork.Subscribers.GetById(id);
            if (subscriber == null)
            {
                return NotFound();
            }
            return View(subscriber);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmDelete(string id)
        {
            if (id == null || id == "")
            {
                return NotFound();
            }
            var subscriber = _unitOfWork.Subscribers.GetById(id);
            if (subscriber == null)
            {
                return NotFound();
            }
            _unitOfWork.Subscribers.Delete(subscriber);
            _unitOfWork.Complete();
            return RedirectToAction("Subscribers");
        }


        private bool SubscriberIdExists(string id)
        {
            return _unitOfWork.Subscribers.Exists(x => x.Id == id);
        }
        //private bool SubscriberNameExists(string name)
        //{
        //    return _unitOfWork.Subscribers.Exists(x => x.Name == name);
        //}




        //[HttpGet]
        //public IActionResult Search(string id)
        //{
        //    if (id == null || id == "")
        //    {
        //        ViewData["Message"] = "الرجاء ادخال الكود   !!!";
        //    }

        //    var subscribers = _unitOfWork.Subscribers.FindAll(x => x.Id == id, new[] { "Subscriptions", "Invoices" });
        //    if (subscribers == null)
        //    {
        //        ViewData["Message"] = "لا يوجد مشترك بهذا الكود    !!!";
        //    }
        //    return View("Subscribers", subscribers);
        //}

    }
}
