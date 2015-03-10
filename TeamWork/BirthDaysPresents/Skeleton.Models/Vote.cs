﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeleton.Models
{
    public class Vote
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int OfferId { get; set; }
        
        public virtual Offer Offer { get; set; }

        public int PresentId { get; set; }

        public virtual Presentt Present { get; set; }
    }
}