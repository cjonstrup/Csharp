using System;
using System.Collections.Generic;

namespace TimeLocker
{
    public class Storage
    {
        public DateTime Date { get; set; }
        public List<Job> Items { get; set; }
        public string MachineName { get; set; }
    }
}