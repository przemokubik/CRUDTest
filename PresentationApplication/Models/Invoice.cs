using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PresentationApplication.Models
{
    public class Invoice
    {
        public int InvoiceID { get; set; }
        public string Number { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}