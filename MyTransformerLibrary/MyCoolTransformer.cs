using JSVaporizer;
using System;
using System.Runtime.InteropServices.JavaScript;
using System.Runtime.Versioning;
using System.Text.Json;
using System.Text.Json.Serialization;
using static JSVaporizer.JSVapor;
using static JSVaporizer.JSVapor.JSVGenericFunctionPool;

[JsonSerializable(typeof(MyCoolTransformerDto))]
internal partial class MyCoolTransformerDtoContext : JsonSerializerContext { }
public class MyCoolTransformerDto : TransformerDto
{
    public string? MyTextInputValue { get; set; }
    public string? MyTextareaValue { get; set; }
    public int? MySelectValue { get; set; }
    public bool? MyCheckbox_1_Checked { get; set; }
    public bool? MyCheckbox_2_Checked { get; set; }
    public bool? MyRadio_1_Selected { get; set; }
    public bool? MyRadio_2_Selected { get; set; }
}

public class MyCoolTransformer : Transformer
{
    public override MyCoolTransformerDto? JsonToDto(string? dtoJSON)
    {
        return dtoJSON == null ? null : JsonSerializer.Deserialize(dtoJSON, MyCoolTransformerDtoContext.Default.MyCoolTransformerDto);
    }

    [SupportedOSPlatform("browser")]
    public override string Transform()
    {
        MyCoolTransformerDto? dto = JsonToDto(DtoJSON);
        if (dto == null)
        {
            throw new JSVException("dto is null");
        }

        Element? myTextInput = Document.GetElementById("myTextInput");
        if (myTextInput != null)
        {
            myTextInput.SetProperty("value", dto.MyTextInputValue??"");
        }

        Element? myTextarea = Document.GetElementById("myTextarea");
        if (myTextarea != null)
        {
            myTextarea.SetProperty("value", dto.MyTextareaValue ?? "");
        }

        Element? mySelect = Document.GetElementById("mySelect");
        if (mySelect != null)
        {
            mySelect.SetProperty("value", dto.MySelectValue??2);
        }

        Element? myCheckbox_1 = Document.GetElementById("myCheckbox_1");
        if (myCheckbox_1 != null)
        {
            myCheckbox_1.SetProperty("checked", dto.MyCheckbox_1_Checked??false);
        }

        Element? myCheckbox_2 = Document.GetElementById("myCheckbox_2");
        if (myCheckbox_2 != null)
        {
            myCheckbox_2.SetProperty("checked", dto.MyCheckbox_2_Checked??false);
        }

        Element? myRadio_1 = Document.GetElementById("myRadio_1");
        if (myRadio_1 != null)
        {
            myRadio_1.SetProperty("checked", dto.MyRadio_1_Selected ?? false);
        }

        Element? myRadio_2 = Document.GetElementById("myRadio_2");
        if (myRadio_2 != null)
        {
            myRadio_2.SetProperty("checked", dto.MyRadio_2_Selected ?? false);
        }

        // Set click handler for hitController
        Element? hitController = Document.GetElementById("hitController");
        if (hitController != null)
        {
            hitController.AddEventListener("click", "myButtonClick", hitControllerClickHandler());
        }

        return "You successfully invoked MyCoolTransformer.Transform().";
    }

    [SupportedOSPlatform("browser")]
    private EventHandlerCalledFromJS hitControllerClickHandler()
    {
        // Register success & error callbacks for AjaxPOST().
        JSVGenericFunction success = (object[] args) =>
        {
            Window.Alert("The success callback: " + args[0].ToString());
            return null;
        };
        JSVGenericFunction error = (object[] args) =>
        {
            Window.Alert("The error callback: " + args[0].ToString());
            return null;
        };
        RegisterJSVGenericFunction("theSuccessCallback", success);
        RegisterJSVGenericFunction("theErrorCallback", error);

        EventHandlerCalledFromJS clickHandler = (JSObject elem, string eventType, JSObject evnt) =>
        {
            MyCoolTransformerDto changedDto = GetResultDto();
            string dtoJSON = JsonSerializer.Serialize(changedDto, MyCoolTransformerDtoContext.Default.MyCoolTransformerDto);

            string url = "/MyCoolController/MyRequestHandler";
            JSFunctionPool.CallFunc("AjaxPOST", [url, dtoJSON, "theSuccessCallback", "theErrorCallback"]);
            
            return (int)JSVEventHandlerBehavior.NoDefault_NoPropagate;
        };

        return clickHandler;
    }

    [SupportedOSPlatform("browser")]
    private MyCoolTransformerDto GetResultDto()
    {
        MyCoolTransformerDto dto = new();

        try
        {
            object? MyTextInputValue = Document.GetElementById("myTextInput")?.GetProperty("value").Value;
            object? MyTextareaValue = Document.GetElementById("myTextarea")?.GetProperty("value").Value;
            object? MySelectValue = Document.GetElementById("mySelect")?.GetProperty("value").Value;
            object? MyCheckbox_1_Checked = Document.GetElementById("myCheckbox_1")?.GetProperty("checked").Value;
            object? MyCheckbox_2_Checked = Document.GetElementById("myCheckbox_2")?.GetProperty("checked").Value;
            object? MyRadio_1_Selected = Document.GetElementById("myRadio_1")?.GetProperty("checked").Value;
            object? MyRadio_2_Selected = Document.GetElementById("myRadio_2")?.GetProperty("checked").Value;

            dto.MyTextInputValue = MyTextInputValue?.ToString();
            dto.MyTextareaValue = MyTextareaValue?.ToString();

            int sv;
            bool parsed = Int32.TryParse(MySelectValue?.ToString(), out sv);
            dto.MySelectValue = parsed ? sv : -1;

            dto.MyCheckbox_1_Checked = (bool)(MyCheckbox_1_Checked??false);
            dto.MyCheckbox_2_Checked = (bool)(MyCheckbox_2_Checked ?? false);
            dto.MyRadio_1_Selected = (bool)(MyRadio_1_Selected ?? false);
            dto.MyRadio_2_Selected = (bool)(MyRadio_2_Selected ?? false);

            return dto;
        }
        catch (Exception ex)
        {
            throw new JSVException(ex.Message);
        }

    }

}