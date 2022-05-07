using System;
using System.Security.Cryptography;
using System.Text;

namespace Cineflix.Domain.Cryptography
{
    public  class CriptografiaService
    {
        public string CriptografaSenha(string Senha)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                return GeraHash(md5Hash, Senha);
            }
        }

        public bool VerificaSenha(string senhabanco, string Senha_MD5)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                var senha = CriptografaSenha(senhabanco);
                if (VerificarHash(md5Hash, Senha_MD5, senha))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private string GeraHash(MD5 md5Hash, string input)
        {
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }

        private bool VerificarHash(MD5 md5Hash, string input, string hash)
        {
            StringComparer compara = StringComparer.OrdinalIgnoreCase;

            if (0 == compara.Compare(input, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
