using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentWebApi.Models
{
    public class Mark
    {
        public string Subject { get; set; }
        public int Score { get; set; }

        public Mark(string subject, int score)
        {
            this.Subject = subject;
            this.Score = score;
        }
    }
}
