using System.Runtime.Versioning;

namespace JSVaporizer;

[SupportedOSPlatform("browser")]
internal static partial class JSVapor
{
    public static class Window
    {
        public static string Alert(string text)
        {
            return WasmWindow.Alert(text);
        }

        public static class Location
        {
            public static string Href()
            {
                return WasmWindow.Location.Href();
            }
        }
    }

    public static class Console
    {
        public static void Log(string str)
        {
            WasmWindow.Console.Log(str);
        }

        public static void Dir(object obj)
        {
            WasmWindow.Console.Dir(obj);
        }
    }
}


