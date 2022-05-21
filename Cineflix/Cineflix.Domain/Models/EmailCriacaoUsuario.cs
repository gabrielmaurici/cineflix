using Cineflix.Domain.Intercaces;
using SendGrid.Helpers.Mail;

namespace Cineflix.Domain.Models
{
    public class EmailCriacaoUsuario : IEmail
    {
        public EmailCriacaoUsuario(string email, string nome)
        {
            Assunto = "Bem Vindo ao Cineflix";
            Conteudo = MontaConteudo(nome);
            Destinatario = new EmailAddress(email, nome);
        }

        private string MontaConteudo(string nome)
        {
            return $"<h4>Bem vindo <strong>{nome}!</strong></h4>" +
                $"<p>Agora você pode comprar ingressos online ;)</p>";
        }

        public string Assunto { get; set; }
        public string Conteudo { get; set; }
        public EmailAddress Destinatario { get; set; }
    }
}
