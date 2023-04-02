using PresentationApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace PresentationApplication.Data
{
    public class ItemRepository : Repository<Item>, IItemRepository
    {
        public ItemRepository(DbContext context) : base(context)
        {
        }
    }
}