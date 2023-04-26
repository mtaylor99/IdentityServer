﻿using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

namespace SinglePageApplication.Handlers
{
    public class ApiAuthorizationMessageHandler : AuthorizationMessageHandler
    {
        public ApiAuthorizationMessageHandler(IAccessTokenProvider provider, NavigationManager navigation) : base(
            provider, navigation)
        {
            ConfigureHandler(new List<string>
            {
                "https://localhost:5003"
            }, new List<string>
            {
                "https://localhost:5003/api"
            });
        }
    }
}