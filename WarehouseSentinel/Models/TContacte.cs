using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseSentinel.Models
{
    public class TContacte
    {
        private SentinelDBEntities context;

        public TContacte(SentinelDBEntities context)
        {
            this.context = context;
        }



        public List<contacte> getByClient(client c)
        {
            return (from tContactes in context.contacte
                    join tClient in context.client on tContactes.Client_CIF equals tClient.CIF
                    where tContactes.Client_CIF.Equals(c.CIF)
                    select tContactes).ToList();
        }
    }
}
