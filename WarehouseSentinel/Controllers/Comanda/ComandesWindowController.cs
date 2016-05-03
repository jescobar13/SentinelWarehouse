using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseSentinel.Models;

namespace WarehouseSentinel.Controllers
{
    public class ComandesWindowController
    {
        SentinelDBEntities context;

        public ComandesWindowController(SentinelDBEntities context)
        {
            this.context = context;
        }
    }
}
