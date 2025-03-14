using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace RazorPagesJSVaporizer.Controllers
{
    public class IndexModel : PageModel
    {
        public string XformerDtoJSON = "";

        public IndexModel(ILogger<IndexModel> logger)
        {
            
        }

        public void OnGet()
        {
            MyCoolTransformerDto xformerDto = new MyCoolTransformerDto();

            xformerDto.MyTextInputValue = "THIS IS A TEST...";
            xformerDto.MyTextareaValue = "... of the emergency broadcast system.";
            xformerDto.MySelectValue = 2;

            xformerDto.MyCheckbox_1_Checked = false;
            xformerDto.MyCheckbox_2_Checked = true;

            xformerDto.MyRadio_1_Selected = false;
            xformerDto.MyRadio_2_Selected = true;

            XformerDtoJSON = JsonSerializer.Serialize(xformerDto);

        }
    }
}
