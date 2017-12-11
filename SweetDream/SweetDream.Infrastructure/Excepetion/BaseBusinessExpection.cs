using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetDream.Infrastructure.Excepetion
{
    [Serializable]
    public class BaseBusinessException : Exception
    {

        public BaseBusinessException()
        {
        }

        public BaseBusinessException(string message)
            : base(message)
        {
        }

        public BaseBusinessException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
