using Cineflix.Domain.Entity;
using Cineflix.Domain.Intercaces;
using SendGrid.Helpers.Mail;

namespace Cineflix.Domain.Models
{
    public class EmailCriacaoIngresso : IEmail
    {
        public EmailCriacaoIngresso(Ingresso ingresso)
        {
            Assunto = $"Seu Ingresso para {ingresso.Sessao.Filme.Nome}";
            Conteudo = MontaConteudo(ingresso);
            Destinatario = new EmailAddress(ingresso.Usuario.Email, ingresso.Usuario.Nome);
        }

        private string MontaConteudo(Ingresso ingresso)
        {
            return $"<h1>Olá {ingresso.Usuario.Nome}!</h1>" +
                $"<h2>Você acabou de adquirir ingresso Cineflix:</h2> <br />" +
                $"<strong>Filme: {ingresso.Sessao.Filme.Nome}</strong> <br />" +
                $"<strong>Data Sessão: {ingresso.Sessao.DataSessao}</strong> <br />" +
                $"<strong>Entrada: {ingresso.TipoEntrada}</strong> <br />" +
                $"<strong>Valor: {ingresso.Valor}</strong> <br />" +
                $"<strong>Data Compra: {ingresso.DataCompra}</strong> <br />" +
                $"<strong>Nome Usuário: {ingresso.Usuario.Nome}</strong> <br />" +
                $"<strong>Documento Usuário: {ingresso.Usuario.Documento}</strong>";
        }

        public string Assunto { get; set; }
        public string Conteudo { get; set; }
        public EmailAddress Destinatario { get; set; }
    }
}
