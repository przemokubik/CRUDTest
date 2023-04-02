using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationApplication.Data
{
    public interface IUnitOfWork
    {
        IInvoiceRepository Invoices { get; }
        IItemRepository Items { get; }
        int SaveChanges();
        void Dispose();
    }
}
