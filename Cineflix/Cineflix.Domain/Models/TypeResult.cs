using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cineflix.Domain.Models
{
    public class TypeResult<T>
    {
        public bool Sucesso { get; set; }
        public T Modelo { get; set; }
        public string Mensagem { get; set; }
    }
}
