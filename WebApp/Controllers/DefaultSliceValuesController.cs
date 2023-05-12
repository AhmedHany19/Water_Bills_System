using Domain.IRepositiory;
using Domain.Model;
using Infrastructure.Repositiory;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class DefaultSliceValuesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public DefaultSliceValuesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public IActionResult DefaultSliceValues()
        {
            return View(_unitOfWork.Default_Slice_Values.GetAll());
        }

        public IActionResult Create()
        {

            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Default_Slice_Value model)
        {

            _unitOfWork.Default_Slice_Values.Add(model);
            _unitOfWork.Complete();
            return RedirectToAction("DefaultSliceValues");

        }


        [HttpGet]
        public IActionResult Edit(string id)
        {
            if (id == null || id == "")
            {
                return NotFound();
            }
            var defaultSliceValue = _unitOfWork.Default_Slice_Values.GetById(id);
            if (defaultSliceValue == null)
            {
                return NotFound();
            }
            return View(defaultSliceValue);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string id, Default_Slice_Value model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }
            _unitOfWork.Default_Slice_Values.Update(model);
            _unitOfWork.Complete();

            return RedirectToAction("DefaultSliceValues");
        }

        public IActionResult Delete(string id)
        {
            if (id == null || id == "")
            {
                return NotFound();
            }
            var defaultSliceValue = _unitOfWork.Default_Slice_Values.GetById(id);
            if (defaultSliceValue == null)
            {
                return NotFound();
            }
            return View(defaultSliceValue);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmDelete(string id)
        {
            if (id == null || id == "")
            {
                return NotFound();
            }
            var defaultSliceValue = _unitOfWork.Default_Slice_Values.GetById(id);
            if (defaultSliceValue == null)
            {
                return NotFound();
            }
            _unitOfWork.Default_Slice_Values.Delete(defaultSliceValue);
            _unitOfWork.Complete();
            return RedirectToAction("DefaultSliceValues");
        }
    }
}
