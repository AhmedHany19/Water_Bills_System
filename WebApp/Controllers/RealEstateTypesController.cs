using Domain.IRepositiory;
using Domain.Model;
using Infrastructure.Repositiory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Controllers
{
    public class RealEstateTypesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public RealEstateTypesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public IActionResult RealEstateType()
        {
            return View(_unitOfWork.Real_Estate_Types.GetAll());
        }

        public IActionResult Create()
        {

            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Real_Estate_Type model)
        {          
                _unitOfWork.Real_Estate_Types.Add(model);
                _unitOfWork.Complete();
                return RedirectToAction("RealEstateType");
            
        }

        [HttpGet]
        public  IActionResult Edit(string id)
        {
            if (id == null || id =="")
            {
                return NotFound();
            }
            var realEstate = _unitOfWork.Real_Estate_Types.GetById(id);
            if (realEstate == null)
            {
                return NotFound();
            }
            return View(realEstate);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string id, Real_Estate_Type model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }
          
             _unitOfWork.Real_Estate_Types.Update(model);
             _unitOfWork.Complete();
                
             return RedirectToAction("RealEstateType");
           

        }


        public IActionResult Delete(string id)
        {
            if (id == null || id == "")
            {
                return NotFound();
            }
            var realEstate = _unitOfWork.Real_Estate_Types.GetById(id);
            if (realEstate == null)
            {
                return NotFound();
            }
            return View(realEstate);
        }


        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmDelete(string id)
        {
            if (id == null || id == "")
            {
                return NotFound();
            }
            var realEstate = _unitOfWork.Real_Estate_Types.GetById(id);
            if (realEstate == null)
            {
                return NotFound();
            }
            _unitOfWork.Real_Estate_Types.Delete(realEstate);
            _unitOfWork.Complete();
            return RedirectToAction("RealEstateType");
        }

        //private bool RealStateTypesExists(string code)
        //{
        //    var result = _unitOfWork.Real_Estate_Types.Find(x => x.Code == code);
        //    if (result==null)
        //    {
        //        return false;
        //    }
        //    return true;
        //}


    }
}
