using System.Runtime.Versioning;

namespace JSVaporizer;

[SupportedOSPlatform("browser")]
internal static partial class JSVapor
{
    public static class JSVGenericFunctionPool
    {
        public static void RegisterJSVGenericFunction(string funcKey, JSVGenericFunction func)
        {
            WasmJSVGenericFuncPool.Add(funcKey, func);
        }

        public static void UnregisterJSVGenericFunction(string funcKey, JSVGenericFunction func)
        {
            WasmJSVGenericFuncPool.Remove(funcKey);
        }
    }
}


