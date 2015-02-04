
using System.Runtime.InteropServices;


namespace EmbeddedFirebird
{


    public class Configuration
    {
        public static void Init()
        {
            string dllDirectory;

            if (System.Web.Hosting.HostingEnvironment.IsHosted)
            {
                dllDirectory = System.Web.Hosting.HostingEnvironment.MapPath("~/bin");
            }
            else
            {
                dllDirectory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            }

            if (System.Environment.OSVersion.Platform != System.PlatformID.Unix)
            {
                if (System.IntPtr.Size * 8 == 32)
                    dllDirectory = System.IO.Path.Combine(dllDirectory, @"Libs/Firebird-2.5.3.26780-0_Win32_embed");
                else if (System.IntPtr.Size * 8 == 64)
                    dllDirectory = System.IO.Path.Combine(dllDirectory, @"Libs/Firebird-2.5.3.26780-0_x64_embed");
                else
                    throw new System.Exception("Unsupported processor bitness.");
            }

            bool callSuccessful = NativeMethods.SetDllDirectory(dllDirectory);
            if (!callSuccessful)
            {
                throw new System.Exception("Could not set DLL directory");
            }
        }
    }


    internal class NativeMethods
    {

        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern bool SetDllDirectory(string pathname);

    }
}
