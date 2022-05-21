using SendGrid.Helpers.Mail;

namespace Cineflix.Domain.Intercaces
{
    public interface IEmail
    {
        public string Assunto { get; set; }
        public string Conteudo { get; set; }
        public EmailAddress Destinatario { get; set; }
    }
}
