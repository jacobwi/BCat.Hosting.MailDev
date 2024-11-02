using Aspire.Hosting.ApplicationModel;

namespace Aspire.Hosting.MailDev;

public static class MailDevResourceBuilderExtensions
{
    public static IResourceBuilder<MailDevResource> AddMailDev(
        this IDistributedApplicationBuilder builder,
        string name,
        Action<MailDevBuilder>? configure = null)
    {
        var options = new MailDevBuilder();
        configure?.Invoke(options);

        var resource = new MailDevResource(name, options.Username, options.Password);
        
        return builder.AddResource(resource)
            .WithImage(MailDevContainerImageTags.Image)
            .WithImageRegistry(MailDevContainerImageTags.Registry)
            .WithImageTag(MailDevContainerImageTags.Tag)
            .WithHttpEndpoint(
                targetPort: MailDevResource.DefaultHttpPort,
                port: options.HttpPort,
                name: MailDevResource.HttpEndpointName)
            .WithEndpoint(
                targetPort: MailDevResource.DefaultSmtpPort,
                port: options.SmtpPort,
                name: MailDevResource.SmtpEndpointName)
            .ConfigureAuth(options);
    }

    private static IResourceBuilder<MailDevResource> ConfigureAuth(
        this IResourceBuilder<MailDevResource> builder,
        MailDevBuilder options)
    {
        if (string.IsNullOrEmpty(options.Username))
            return builder;

        builder = builder
            .WithEnvironment("MAILDEV_WEB_USER", options.Username)
            .WithArgs("--web-user", options.Username);

        if (!string.IsNullOrEmpty(options.Password))
        {
            builder = builder
                .WithEnvironment("MAILDEV_WEB_PASS", options.Password)
                .WithArgs("--web-pass", options.Password);
        }

        return builder;
    }
}