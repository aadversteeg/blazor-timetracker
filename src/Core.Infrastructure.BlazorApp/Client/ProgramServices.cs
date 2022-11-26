using Microsoft.JSInterop;
using System.Xml.Linq;

namespace Core.Infrastructure.BlazorApp.Client
{
    public class ProgramServices
    {
        private readonly IJSRuntime _jsRuntime;

        public ProgramServices(IJSRuntime jsRuntime) { 
            _jsRuntime = jsRuntime;
        }
        public  async Task<bool> Confirm(string message)
        {
            return await _jsRuntime.InvokeAsync<bool>("confirm", message);
        }

    }
}
