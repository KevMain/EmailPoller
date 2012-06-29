using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business
{
    public interface IEmail
    {
        string EmailAddressTo { get; }
        string EmailAddressFrom { get; }
        string Subject { get; }
        string Body { get; }
    }
}
