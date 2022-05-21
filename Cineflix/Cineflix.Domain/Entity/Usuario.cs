namespace Cineflix.Domain
{
    public  class Usuario
    {
        public const short DOCUMENTO_MAX = 14;
        public const short SENHA_MAX = 40;
        public const short NOME_MAX = 60;
        public const short EMAIL_MAX = 60;

        public int Id { get; private set; }
        public string Documento { get; private set; }
        public string Nome { get; private set; }
        public string Senha { get; private set; }
        public string Email { get; set; }

        public void CriarUsuario(string documento, string senha, string email, string nome = null)
        {
            Documento = documento;
            Nome = nome;
            Senha = senha;
            Email = email;
        }
    }
}
