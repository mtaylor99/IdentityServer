using Api.Core.Models.Error;
using Microsoft.AspNetCore.Mvc;

namespace Api.Helpers;

public static class ValidationResponseFormatter
{
    public static IActionResult FormatValidationErrors(ActionContext context)
    {
        var errors = context.ModelState.Where(x => !string.IsNullOrWhiteSpace(x.Value.Errors.FirstOrDefault()?.ErrorMessage)).Select(x =>
            new PropertyError { PropertyName = CamelCase(x.Key), ErrorMessage = x.Value.Errors.FirstOrDefault()?.ErrorMessage }
        );

        var reponse = new TransactionErrorResponse
        {
            PropertyErrors = errors
        };

        return new BadRequestObjectResult(reponse);
    }

    private static string CamelCase(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            return input;
        }

        return string.Join(".", input.Split('.').Select(x => $"{char.ToLower(x[0])}{x[1..]}"));
    }
}