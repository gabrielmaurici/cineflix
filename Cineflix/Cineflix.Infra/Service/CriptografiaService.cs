using System.Security.Cryptography;
using System.Text;

namespace Cineflix.Domain.Cryptography
{
    public class CriptografiaService
    {
        public string CriptografaSenha(string senha)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(senha));

                StringBuilder sBuilder = new StringBuilder();

                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }

                return sBuilder.ToString();
            }
        }
    }
}
