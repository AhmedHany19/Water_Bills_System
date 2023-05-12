using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Subscription
    {
        [Key]
        [MaxLength(10)]
        [Column(TypeName = "char")]
        public string Id { get; set; }
        public int No { get; set; }
        public bool Is_There_Sanitation{ get; set; }
        public int Last_Reading_Meter { get; set; }
        [MaxLength(100)]
        [Column(TypeName = "varchar")]
        public string? Comments { get; set; }

        // Navigation Properties
        public string Subscriber_Id { get; set; }
        [ForeignKey("Subscriber_Id")]
        public Subscriber? Subscriber { get; set; }
        public string Real_State_Id { get; set; }
        [ForeignKey("Real_State_Id")]
        public Real_Estate_Type? Real_Estate_Type { get; set; }
        public List<Invoice> Invoices { get; set; }


    }
}
