using PluralSightBook.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace PluralSightBook.Infrastructure.Services
{
    public class DebugEmailSender: ISendEmail
    {
        public void SendEmail(string message)
        {
           Debug.Print("Sending Email: " + message);
        }
    }
}
