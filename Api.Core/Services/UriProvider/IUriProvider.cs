namespace Api.Core.Services.UriProvider;

internal interface IUriProvider
{
    Uri GetBaseUri();
    Uri GetRelativeUriForAction(string actionName, string controllerName, object routeValues = null);
    Uri GetAbsoluteUriForAction(string actionName, string controllerName, object routeValues = null);
}