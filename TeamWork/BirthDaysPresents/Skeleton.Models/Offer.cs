using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Skeleton.Models
{
    public class Offer
    {
        public int Id { get; set; }

        public string CreatorId { get; set; }

        public virtual ApplicationUser Creator { get; set; }

        public string CelebratorId { get; set; }
      
        public virtual ApplicationUser Celebrator { get; set; }

        public int Year { get; set; }

        public bool IsActive { get; set; }

        public virtual ICollection<Presentt> Presents { get; set; }

        public virtual ICollection<Vote> Votes { get; set; }
        
        public Offer()
        {
            this.Presents = new HashSet<Presentt>();
            this.Votes = new HashSet<Vote>();
        }
    }
}