using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Spk.Common.Mailing.MailBuilder
{
    interface IMailBuilder
    {
        Task<string> BuildEmail(MailModel mail);
    }
}
