using System.Runtime.Versioning;

namespace JSVaporizer;

[SupportedOSPlatform("browser")]
internal static partial class JSVapor
{
    public static class JSFunctionPool
    {
        public static object? CallFunc(string funcKey, object[] args)
        {
            return WasmJSFunctionPool.CallJSFunction(funcKey, args);
        }
    }
}


