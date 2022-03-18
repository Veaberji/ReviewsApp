using Azure.Extensions.AspNetCore.Configuration.Secrets;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;

namespace ReviewsApp.Core.DependencyInjection
{
    public static class AzureKeyVaultConfiguration
    {
        public static WebApplicationBuilder ConfigureAzureKeyVault(
            this WebApplicationBuilder builder)
        {
            builder.Host.ConfigureAppConfiguration(config =>
            {
                var builtConfiguration = config.Build();

                string vaultUrl = builtConfiguration["KeyVaultConfig:VaultURL"];
                string tenantId = builtConfiguration["KeyVaultConfig:TenantId"];
                string clientId = builtConfiguration["KeyVaultConfig:ClientId"];
                string clientSecret = builtConfiguration["KeyVaultConfig:ClientSecretId"];

                var credentials = new ClientSecretCredential(tenantId, clientId, clientSecret);
                var client = new SecretClient(new Uri(vaultUrl), credentials);
                config.AddAzureKeyVault(client, new AzureKeyVaultConfigurationOptions());
            });

            return builder;
        }
    }
}
