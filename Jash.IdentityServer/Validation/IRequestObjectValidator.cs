


using System.Threading.Tasks;

namespace Jash.IdentityServer.Validation;

internal interface IRequestObjectValidator
{
    Task<AuthorizeRequestValidationResult> LoadRequestObjectAsync(ValidatedAuthorizeRequest request);
    Task<AuthorizeRequestValidationResult> ValidatePushedAuthorizationRequest(ValidatedAuthorizeRequest request);
    Task<AuthorizeRequestValidationResult> ValidateRequestObjectAsync(ValidatedAuthorizeRequest request);
}

