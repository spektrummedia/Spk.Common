using System;
using System.Globalization;
using System.Threading;

namespace Spk.Common.Helpers.Localization
{
    public class CultureScope : IDisposable
    {
        private readonly CultureInfo _initialMain;
        private readonly CultureInfo _initialUi;

        public CultureScope()
        {
            _initialMain = CultureInfo.CurrentCulture;
            _initialUi = CultureInfo.CurrentUICulture;
        }
        
        public CultureScope(CultureInfo culture, CultureScopeMode mode = CultureScopeMode.Both) : this()
        {
            Apply(mode, culture);
        }

        public CultureScope(string cultureName, CultureScopeMode mode = CultureScopeMode.Both) : this()
        {
            Apply(mode, new CultureInfo(cultureName));
        }


        private static void Apply(CultureScopeMode mode, CultureInfo culture)
        {
            if (mode.HasFlag(CultureScopeMode.Main))
            {
#if NETSTANDARD2_0
                CultureInfo.CurrentCulture = culture;
#elif NET45
                Thread.CurrentThread.CurrentCulture = culture;
#endif
            }
            if (mode.HasFlag(CultureScopeMode.Ui))
            {
#if NETSTANDARD2_0
                CultureInfo.CurrentUICulture = culture;
#elif NET45
                Thread.CurrentThread.CurrentUICulture = culture;
#endif
            }
        }

        public void Dispose()
        {
#if NETSTANDARD2_0
            CultureInfo.CurrentCulture = _initialMain;
            CultureInfo.CurrentUICulture = _initialUi;
#elif NET45
            Thread.CurrentThread.CurrentCulture = _initialMain;
            Thread.CurrentThread.CurrentUICulture = _initialUi;
#endif
        }
    }

    [Flags]
    public enum CultureScopeMode
    {
        Main = 1,
        Ui = 2,
        Both = 3
    }
}
