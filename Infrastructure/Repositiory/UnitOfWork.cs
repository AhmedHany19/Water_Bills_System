using Domain.IRepositiory;
using Domain.Model;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositiory
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IBaseRepositiory<Invoice> Invoices {get; private set;}
        public IBaseRepositiory<Default_Slice_Value> Default_Slice_Values { get; private set; }
        public IBaseRepositiory<Real_Estate_Type> Real_Estate_Types { get; private set; }
        public IBaseRepositiory<Subscriber> Subscribers { get; private set; }
        public IBaseRepositiory<Subscription> Subscriptions { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Invoices = new BaseRepositiory<Invoice>(_context);
            Subscribers= new BaseRepositiory<Subscriber>(_context);
            Subscriptions= new BaseRepositiory<Subscription>(_context);
            Real_Estate_Types= new BaseRepositiory<Real_Estate_Type>(_context);
            Default_Slice_Values= new BaseRepositiory<Default_Slice_Value>(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();

        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
