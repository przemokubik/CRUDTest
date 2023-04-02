using PresentationApplication.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace PresentationApplication.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            Invoices = new InvoiceRepository(_context);
            Items = new ItemRepository(_context);
        }

        public IItemRepository Items { get; private set; }
        public IInvoiceRepository Invoices { get; private set; }

        public int SaveChanges()
        {
            try
            {
                return _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Database error: cant't save. " + ex.Message);
                return 0;
            }
        }



        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }
    }
}