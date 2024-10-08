 
 


#nullable disable

using Jash.IdentityServer.Configuration;
using Jash.IdentityServer.Configuration.Configuration;
using Microsoft.Extensions.Logging;

namespace Jash.IdentityServer;

// APIs needed for IdentityServer specific license validation
internal class ConfigurationLicenseValidator : LicenseValidator<ConfigurationLicense>
{
    internal readonly static ConfigurationLicenseValidator Instance = new ConfigurationLicenseValidator();

    public void Initialize(ILoggerFactory loggerFactory, IdentityServerConfigurationOptions options)
    {
        Initialize(loggerFactory, "IdentityServer.Configuration", options.LicenseKey);
        ValidateLicense();
    }

    protected override void ValidateProductFeatures(List<string> errors)
    {
        if (License.IsBffEdition)
        {
            throw new Exception("Invalid License: The BFF edition license is not valid for the IdentityServer Configuration API.");
        }
        
        if (!License.ConfigApiFeature)
        {
            throw new Exception($"You are using the IdentityServer Configuration API feature. Your license for Jash IdentityServer does not include that feature. This feature requires the Business or Enterprise Edition tier of license.");
        }
    }

    protected override void WarnForProductFeaturesWhenMissingLicense()
    {
        WarningLog?.Invoke("You are using the IdentityServer Configuration API feature, but you do not have a license. This feature requires the Business or Enterprise Edition tier of license.", null);
    }
}
