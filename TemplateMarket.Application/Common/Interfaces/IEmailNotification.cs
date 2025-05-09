using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMarket.Application.Common.Interfaces;

public interface IEmailNotification
{
    Task SendNotificationAsync(string to, string subject, string Type, string body);
}
