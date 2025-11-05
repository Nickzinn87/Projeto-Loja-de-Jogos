using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto2W1N.Models
{
    public sealed class FakeDBSingleton
    {
        static FakeDBSingleton _instancia;

        public static FakeDBSingleton Instancia
        {
            get
            {
                return _instancia ??
                    (_instancia = new FakeDBSingleton());
            }
        }
        public Usuario UsuarioLogado { get; set; }
    }
}
