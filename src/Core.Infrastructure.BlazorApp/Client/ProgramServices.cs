using Microsoft.JSInterop;
using System.Xml.Linq;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.Rest;

namespace Core.Infrastructure.BlazorApp.Client
{
    public class ProgramServices
    {
        private readonly IJSRuntime _jsRuntime;
        private readonly IAccessTokenProvider _tokenProvider;


		public ProgramServices(IJSRuntime jsRuntime, IAccessTokenProvider tokenProvider) { 
            _jsRuntime = jsRuntime;
            _tokenProvider = tokenProvider; 
        }
        public  async Task<bool> Confirm(string message)
        {
            return await _jsRuntime.InvokeAsync<bool>("confirm", message);
        }
    }
}
