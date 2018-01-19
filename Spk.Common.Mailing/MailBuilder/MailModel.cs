using System;
using System.Collections.Generic;
using System.Text;
using Spk.Common.Mailing.MailBuilder.Views.Components;

namespace Spk.Common.Mailing.MailBuilder
{
    public class MailModel
    {
        public MailStyles Styles { get; set; }

        // Visually Hidden Preheader Text
        public string Preheader { get; set; }

        public string HeaderTitle { get; set; }
        public List<BaseRow> Rows { get; set; } = new List<BaseRow>();
        public string PreFooterHtml { get; set; }
        public string FooterHtml { get; set; }

        public MailModel()
        {
            Styles = new MailStyles();
        }

        public MailModel(MailStyles styles)
        {
            Styles = styles;
        }



    }
}
