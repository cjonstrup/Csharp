using System;

namespace TimeLocker
{
    public class Log : BaseService
    {
        public DateTime Start { get; set; }
        public DateTime Slut { get; set; }

        public TimeSpan Total
        {
            get
            {
                return Slut.Subtract(Start);
            }
        }


        public string Note { get; set; }
    }
}