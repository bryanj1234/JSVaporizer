using System.Runtime.InteropServices.JavaScript;
using System.Runtime.Versioning;

namespace JSVaporizer;

public static partial class TransformerInvoker
{
    [SupportedOSPlatform("browser")]
    [JSExport]
    internal static string Invoke(string xFormerName, string dtoJSON)
    {
        ITransformer xFormer = TransformerRegistry.Get(xFormerName);
        xFormer.SetDtoJSON(dtoJSON);
        string xFromRes = xFormer.Transform();
        return xFromRes;
    }
}