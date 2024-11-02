namespace Aspire.Hosting.MailDev;

public class MailDevBuilder
{
    public int? HttpPort { get; set; }
    public int? SmtpPort { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }

    public MailDevBuilder WithPorts(int? httpPort = null, int? smtpPort = null)
    {
        HttpPort = httpPort;
        SmtpPort = smtpPort;
        return this;
    }

    public MailDevBuilder WithAuth(string username, string password)
    {
        Username = username;
        Password = password;
        return this;
    }
}