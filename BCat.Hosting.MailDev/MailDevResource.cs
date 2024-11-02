using Aspire.Hosting.ApplicationModel;

namespace Aspire.Hosting.MailDev;

public class MailDevResource(string name, string? username = null, string? password = null)
    : ContainerResource(name), IResourceWithConnectionString
{
    internal const string SmtpEndpointName = "smtp";
    internal const string HttpEndpointName = "http";
    internal const int DefaultHttpPort = 1080;
    internal const int DefaultSmtpPort = 1025;
    
    private EndpointReference? _smtpReference;

    private EndpointReference SmtpEndpoint =>
        _smtpReference ??= new EndpointReference(this, SmtpEndpointName);

    public ReferenceExpression ConnectionStringExpression =>
        ReferenceExpression.Create($"smtp://{SmtpEndpoint.Property(EndpointProperty.Host)}:{SmtpEndpoint.Property(EndpointProperty.Port)}");

    public string? Username { get; } = username;
    public string? Password { get; } = password;
}