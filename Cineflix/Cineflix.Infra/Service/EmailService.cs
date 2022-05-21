using Cineflix.Domain.Intercaces;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace Cineflix.Infra.Service
{
    public class EmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> EnviaEmail(IEmail email)
        {
            var apiKey = _configuration.GetSection("API_KEY_SENDGRID").Value;
            var client = new SendGridClient(apiKey);
            var remetente = new EmailAddress("dev.integra.testes@gmail.com", "Dev Testes");
            
            var msg = MailHelper.CreateSingleEmail(remetente, email.Destinatario,
                email.Assunto, email.SubAssunto,email.Conteudo);

            var response = await client.SendEmailAsync(msg);
            
            if(!response.IsSuccessStatusCode)
                return false;

            return true;
        }
    }
}
