using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ViewModel
{
    public class SubscribtionsViewModel
    {
        public Subscription Subscription { get; set; }
        public Subscriber  Subscriber { get; set; }
        public IEnumerable<Subscriber> Subscribers { get; set;}
        public IEnumerable<Subscription> Subscriptions { get; set; }
        public IEnumerable<Real_Estate_Type> Real_Estate_Types { get; set; }
    }

}
