using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentsWebApi.Models
{
    public class Mark
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public int Value { get; set; }
        
        public Mark(int id, string subject, int value)
        {
            this.Id = id;
            this.Subject = subject;
            this.Value = value;
        }
    }
}
