using System;
using System.Collections.Generic;
using System.Text;
using RazorLight;

namespace Spk.Common.Mailing.MailBuilder.Views.Components
{
    public class BaseRow
    {
        public virtual string Html { get; protected set; }

        public virtual MailStyles Styles { get; protected set; }

        public virtual async void GenerateHtmlStringFromTemplate()
        {
            if (string.IsNullOrEmpty(Html))
            {
                var engine = new EngineFactory().ForEmbeddedResources(this.GetType());
                Html = await engine.CompileRenderAsync(this.GetType().Name, this);
            }

            //Else, HTML must be custom and already set.
        }

        public virtual void SetStyles(MailStyles styles, bool force = false)
        {
            if (force || Styles == null)
            {
                Styles = styles;
            }
        }

    }
}
