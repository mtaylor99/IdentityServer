using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Api.Core.Services.UriProvider;

internal class HttpContextUriProvider : IUriProvider
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly LinkGenerator _linkGenerator;

    public HttpContextUriProvider(IHttpContextAccessor httpContextAccessor, LinkGenerator linkGenerator)
    {
        _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        _linkGenerator = linkGenerator ?? throw new ArgumentNullException(nameof(linkGenerator));
    }

    public Uri GetBaseUri()
    {
        if (_httpContextAccessor?.HttpContext == null)
            throw new InvalidOperationException("Must be called in the context of a HTTP request.");

        var request = _httpContextAccessor.HttpContext.Request;

        var uriBuilder = new UriBuilder(
            request.Scheme,
            request.Host.Host,
            request.Host.Port ?? (request.IsHttps ? 443 : 80));

        return uriBuilder.Uri;
    }

    public Uri GetRelativeUriForAction(string actionName, string controllerName, object routeValues = null)
    {
        if (_httpContextAccessor?.HttpContext == null)
            throw new InvalidOperationException("Must be called in the context of a HTTP request.");

        var relativeUri = _linkGenerator.GetPathByAction(
                              _httpContextAccessor.HttpContext,
                              actionName,
                              controllerName,
                              routeValues,
                              options: new LinkOptions { LowercaseUrls = true })
                          ?? throw new InvalidOperationException(
                              $"Unable to construct URI for {controllerName}/{actionName}");

        return new Uri(relativeUri, UriKind.Relative);
    }

    public Uri GetAbsoluteUriForAction(string actionName, string controllerName, object routeValues = null)
    {
        var baseUri = GetBaseUri();
        var relativeUri = GetRelativeUriForAction(actionName, controllerName, routeValues);

        return new Uri(baseUri, relativeUri);
    }
}