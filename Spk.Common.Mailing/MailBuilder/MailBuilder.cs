using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RazorLight;
using Spk.Common.Mailing.MailBuilder;

namespace Spk.Common.Mailing.MailBuilder
{
    public class MailBuilder : IMailBuilder
    {
        public Task<string> BuildEmail(MailModel mail)
        {
            foreach (var mailRow in mail.Rows)
            {
                mailRow.SetStyles(mail.Styles, false);
                mailRow.GenerateHtmlStringFromTemplate();
            }


            var e = new RazorLightEngineBuilder()
                .UseEmbeddedResourcesProject(typeof(MailModel))
                .Build();

            return e.CompileRenderAsync("Views.Mail", mail);
        }
    }
}
