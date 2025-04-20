using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Power
{
    public static class Inactividad
    {
        [DllImport("user32.dll")]
        private static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);

        private struct LASTINPUTINFO
        {
            public uint cbSize;
            public uint dwTime;
        }

        public static TimeSpan ObtenerTiempoInactividad()
        {
            LASTINPUTINFO lastInputInfo = new LASTINPUTINFO();
            lastInputInfo.cbSize = (uint)Marshal.SizeOf(lastInputInfo);

            if (GetLastInputInfo(ref lastInputInfo))
            {
                uint lastInputTime = lastInputInfo.dwTime;
                uint currentTime = (uint)Environment.TickCount;
                uint elapsedTime = currentTime - lastInputTime;

                return TimeSpan.FromMilliseconds(elapsedTime);
            }

            return TimeSpan.Zero;
        }
    }
}
