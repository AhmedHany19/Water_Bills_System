using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepositiory
{
    public interface IUnitOfWork :IDisposable
    {
        IBaseRepositiory<Invoice> Invoices { get; }
        IBaseRepositiory<Default_Slice_Value> Default_Slice_Values { get; }
        IBaseRepositiory<Real_Estate_Type> Real_Estate_Types { get; }
        IBaseRepositiory<Subscriber> Subscribers { get; }
        IBaseRepositiory<Subscription> Subscriptions { get; }
        int Complete();
        Task<int> CompleteAsync();
    }
}
