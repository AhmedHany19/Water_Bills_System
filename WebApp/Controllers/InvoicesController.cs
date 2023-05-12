using Domain.IRepositiory;
using Domain.Model;
using Infrastructure.Services;
using Infrastructure.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;

namespace WebApp.Controllers
{
    public class InvoicesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public InvoicesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Invoices()
        {
            return View(new InvoicesViewModel
            {
                Invoices= _unitOfWork.Invoices.GetAll(new[] { "Subscriber", "Subscription", "Real_Estate_Type" }),
                Invoice= new Invoice(),
                Subscriptions=_unitOfWork.Subscriptions.GetAll(),
                Subscribers=_unitOfWork.Subscribers.GetAll(),
                Real_Estate_Types=_unitOfWork.Real_Estate_Types.GetAll(),
            });
        }



        [HttpGet]
        public IActionResult GetSubscriptionById(string id)
        {
           
            var subscription = _unitOfWork.Subscriptions.Find(x=>x.Id==id, new[] { "Subscriber", "Real_Estate_Type" });
            if (subscription == null)       
                ViewData["Message"] = "empty";
            
            return View(new InvoicesViewModel
            {
                Invoices = _unitOfWork.Invoices.GetAll(new[] { "Subscriber", "Subscription", "Real_Estate_Type" }),
                Invoice = new Invoice(),
                Subscription= subscription,
                Subscriptions = _unitOfWork.Subscriptions.GetAll(),
                Subscribers = _unitOfWork.Subscribers.GetAll(),
                Real_Estate_Types = _unitOfWork.Real_Estate_Types.GetAll(),
            });       
        }


        [HttpGet]
        public IActionResult RegisterInvoice()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AboutInvoice()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Details(string Id)
        {
            if (Id==null || Id =="")
            {
                ViewData["Message"] = "empty";
                return View();
            }
            var invoice= _unitOfWork.Invoices.Find(x => x.Id == Id, new[] { "Subscriber", "Subscription", "Real_Estate_Type" });
            var subscribtion = _unitOfWork.Subscriptions.Find(x => x.Id == invoice.Subscribetion_Id, new[] { "Subscriber", "Real_Estate_Type" });
            if (invoice==null||subscribtion==null)
            {
                ViewData["Message"] = "empty";
                return View();
            }
            return View(new InvoicesViewModel
            {
                Invoices = _unitOfWork.Invoices.GetAll(new[] { "Subscriber", "Subscription", "Real_Estate_Type" }),
                Invoice = invoice,
                Subscription= subscribtion,
                Subscriptions = _unitOfWork.Subscriptions.GetAll(),
                Subscribers = _unitOfWork.Subscribers.GetAll(),
                Real_Estate_Types = _unitOfWork.Real_Estate_Types.GetAll(),
            });
        }


        [HttpPost]
        public IActionResult Create(string subscribtionId,InvoicesViewModel model)
        {

            if (model==null)
            {
                return NotFound();
            }

            var subscription = _unitOfWork.Subscriptions.Find(x => x.Id == subscribtionId, new[] { "Subscriber", "Real_Estate_Type" });
            var noOfUnit = subscription.No;
            model.Invoice.Subscribetion_Id=subscription.Id; 
            model.Invoice.Subscriber_Id=subscription.Subscriber_Id;
            model.Invoice.Real_State_Id=subscription.Real_State_Id;
            model.Invoice.Previous_Consumption_Amount = subscription.Last_Reading_Meter;
            model.Invoice.Amount_Consumption = InvoiceService.amountConsumptionCal(model.Invoice.Current_Consumption_Amount, model.Invoice.Previous_Consumption_Amount);
            model.Invoice.Date = DateTime.Now.Date;
            model.Invoice.Year = DateTime.Now.ToString("yy");       
            model.Invoice.Id = DateTime.Now.ToString("yy-MM-mmss");            
            model.Invoice.From = InvoiceService.from;
            model.Invoice.To = InvoiceService.to;
            model.Invoice.Service_Fee = Helper.Service_Fee;
            model.Invoice.Tax_Rate = Helper.Tax_Rate;
            model.Invoice.Consumption_Value= Decimal.Parse(InvoiceService.waterValue(model.Invoice.Amount_Consumption, noOfUnit).ToString());
            model.Invoice.Wastewater_Consumption_Value = InvoiceService.wastewaterConsumptionValue(model.Invoice.Consumption_Value, subscription.Is_There_Sanitation);
            model.Invoice.Total_Invoice = model.Invoice.Consumption_Value + model.Invoice.Wastewater_Consumption_Value;
            model.Invoice.Tax_Value = InvoiceService.taxValue(model.Invoice.Total_Invoice, model.Invoice.Tax_Rate);
            model.Invoice.Total_Bill = InvoiceService.totalBill(model.Invoice.Total_Invoice, model.Invoice.Tax_Value, model.Invoice.Service_Fee);
            subscription.Last_Reading_Meter = model.Invoice.Current_Consumption_Amount;
            _unitOfWork.Invoices.Add(model.Invoice);
            _unitOfWork.Complete();


            return View( new InvoicesViewModel
            {
                Invoices = _unitOfWork.Invoices.GetAll(new[] { "Subscriber", "Subscription", "Real_Estate_Type" }),
                Invoice = model.Invoice,
                Subscription = subscription,
                Subscriptions = _unitOfWork.Subscriptions.GetAll(),
                Subscribers = _unitOfWork.Subscribers.GetAll(),
                Real_Estate_Types = _unitOfWork.Real_Estate_Types.GetAll(),
            });
            

        }

        public IActionResult Delete(string Id)
        {
            if (Id==null || Id =="")
            {
                ViewData["Message"] = "empty";
                return View();
            }
            var invoice= _unitOfWork.Invoices.Find(x => x.Id == Id, new[] { "Subscriber", "Subscription", "Real_Estate_Type" });
            if (invoice==null)
            {
                ViewData["Message"] = "empty";
                return View();
            }
            return View(new InvoicesViewModel
            {
                Invoice = invoice

            }) ;
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmDelete(string Id)
        {
            if (Id == null || Id == "")
            {
                return NotFound();
            }
            var invoice = _unitOfWork.Invoices.GetById(Id);
            if (invoice == null)
            {
                return NotFound();
            }
            _unitOfWork.Invoices.Delete(invoice);
            _unitOfWork.Complete();
            return RedirectToAction("Invoices");
        }



    }
}
