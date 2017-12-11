using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SweetDream.Infrastructure.Excepetion
{
    [DataContract(Name = "Error")]
    public class ErrorMiddleware
    {
        [DataMember]
        public DateTime TimeStamp { get; set; }
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public string StackTrace { get; set; }
        [DataMember]
        public ErrorMiddleware InnerException { get; set; }
        [DataMember]
        public string Type { get; set; }

        public ErrorMiddleware()
        {
            TimeStamp = DateTime.Now;
        }

        public ErrorMiddleware(string message)
            : this()
        {
            Message = message.Replace(Environment.NewLine, string.Empty);
        }

        public ErrorMiddleware(System.Exception ex)
            : this(ex.Message)
        {
            StackTrace = ex.StackTrace;
            Type = ex.GetType().Name;
            if (ex.InnerException != null)
            {
                this.InnerException = new ErrorMiddleware(ex.InnerException);
            }
            Message = ex.Message;
        }

        public override string ToString()
        {
            return Type + " - " + Message + " " + StackTrace;
        }
    }
}
