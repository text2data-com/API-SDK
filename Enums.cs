using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace text2data.Api
{
    public enum DocumentResultStatus
    {
        OK = 1,
        AuthenticationFailure = 2,
        CreditExceeded = 3, //top up required
        ServiceBusy = 4,
        ValidationError = 5,
        GenericError = 6
    }

    public enum SerializeFormats
    {
        Json = 1,
        Xml = 2
    }
}
