namespace SzkolaTestowJednostkowych.Mocking
{
    public interface IEmailSender
    {
        void Send(string subject, string body, string to);
    }
}