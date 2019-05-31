using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Allowance.Models
{
    public interface IDateTime
    {
        DateTime Now { get; }
    }

    public class SystemDateTime : IDateTime
    {
        public DateTime Now
        {
            get { return DateTime.Now; }
        }
    }
}
