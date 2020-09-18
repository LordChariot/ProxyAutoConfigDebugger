using System;
using System.Drawing;

namespace ProxyAutoConfigDebugger
{
    public class ResolveState
    {
        public ResolveState(string hostName)
        {
            if (string.IsNullOrWhiteSpace(hostName))
                throw new ArgumentNullException(nameof(hostName));
            _hostName = hostName;
        }

        readonly string _hostName;

        public Resolvetype Result { get; set; } = Resolvetype.Pending;

        public string HostName => _hostName;

    }

    //used for FindAndReplace_Form
    internal static class FindAndReplace_Classes
    {
        public static Color HalfMix(this Color one, Color two)
        {
            return Color.FromArgb(
                (one.A + two.A) >> 1,
                (one.R + two.R) >> 1,
                (one.G + two.G) >> 1,
                (one.B + two.B) >> 1);
        }
        public static int InRange(this int x, int lo, int hi)
        {
            return x < lo ? lo : (x > hi ? hi : x);
        }
        public static bool IsInRange(this int x, int lo, int hi)
        {
            return x >= lo && x <= hi;
        }
    }
}
