namespace Cineflix.Domain
{
    public  class Usuario
    {
        public int Id { get; private set; }
        public string Documento { get; private set; }
        public string Nome { get;  private set; }
        public string Senha { get; private set; }

        public void CriarUsuario(string documento, string senha, string nome = null)
        {
            Documento = documento;
            Nome = nome;
            Senha = senha;
        }
    }
}
