using PCLExt.FileStorage.Folders;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto2W1N.Services
{
    public class DBService
    {
        public SQLiteConnection GetConexao()
        {
            //Precisamos acessar a pasta
            //onde o arquivo do banco esta salvo
            //fica na pasta raiz, da instalação
            //do aplicativo

            //Acessar a pasta raiz
            var folder =
                new LocalRootFolder();

            //Após recuperar a pasta, iremos
            //manipular o arquivo em si

            //Iremos validar a existencia do arquivo
            //se ja existir utilizamos ele
            //se não existir sera criado
            //neste momento ja definimos o nome do bd
            var file =
                folder.CreateFile("2W1NDB",
                    PCLExt.FileStorage.
                        CreationCollisionOption.
                            OpenIfExists);

            //agora podemos abrir a conexão com o BD
            return
                new SQLiteConnection(file.Path);
        }
    }
}
