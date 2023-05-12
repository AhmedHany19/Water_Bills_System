using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Invoice
    {
        [Key]
        [MaxLength(10)]
        [Column(TypeName = "char")]
        public string Id { get; set; }
        [MaxLength(2)]
        [Column(TypeName = "char")]
        public string? Year { get; set; }
        public DateTime Date { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public int Previous_Consumption_Amount { get; set; }
        public int Current_Consumption_Amount { get; set; }
        public int Amount_Consumption { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Service_Fee { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Tax_Rate { get; set; }

        public bool Is_There_Sanitation { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Consumption_Value { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Wastewater_Consumption_Value { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Total_Invoice { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Tax_Value { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Total_Bill { get; set; }

        [MaxLength(100)]
        [Column(TypeName = "varchar")]
        public string? Comments { get; set; }


        // Navigation Properties'

        public string Subscriber_Id { get; set; }
        [ForeignKey("Subscriber_Id")]
        public Subscriber? Subscriber { get; set; }
        [MaxLength(10)]
        public string Subscribetion_Id { get; set; }
        [ForeignKey("Subscribetion_Id")]
        public Subscription? Subscription { get; set; }
        public string Real_State_Id { get; set; }
        [ForeignKey("Real_State_Id")]
        public Real_Estate_Type? Real_Estate_Type { get; set; }

    }
}
