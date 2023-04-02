using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PresentationApplication.Models
{
    public class Item
    {
        public int ItemID { get; set; }
        public string Name { get; set; }
        public int InvoiceID { get; set; }
        public virtual Invoice Invoice { get; set; }
    }
}