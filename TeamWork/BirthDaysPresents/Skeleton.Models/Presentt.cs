using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeleton.Models
{
    public class Presentt
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Offer> Votes { get; set; }

        public Presentt()
        {
            this.Votes = new HashSet<Offer>();
        }
    }
}
