using PresentationApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PresentationApplication.DAL
{
    public class InvoiceViewModel
    {
        public Invoice Invoice { get; set; }
        public Item Item { get; set; }
    }
}