using Projeto2W1N.Models;
using Projeto2W1N.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Projeto2W1N.ViewModel
{
    public class JogosViewModel : BaseViewModel
    {
        JogosService jogosService = new JogosService();
        HistoricoService historicoService = new HistoricoService();
        private FakeDBSingleton dbSingleton = FakeDBSingleton.Instancia;

        private string _nome;
        public string Nome
        {
            get { return _nome; }
            set
            {
                _nome = value;
                OnPropertyChanged();
            }
        }

        private string _preco;
        public string Preco
        {
            get { return _preco; }
            set
            {
                _preco = value;
                OnPropertyChanged();
            }
        }
        private string _desc;
        public string Desc
        {
            get { return _desc; }
            set
            {
                _desc = value;
                OnPropertyChanged();
            }
        }

        private bool _Admin;
        public bool Admin
        {
            get { return _Admin; }
            set
            {
                _Admin = value;
                OnPropertyChanged();
            }
        }

        private bool _Cliente;
        public bool Cliente
        {
            get { return _Cliente; }
            set
            {
                _Cliente = value;
                OnPropertyChanged();
            }
        }

        private List<Jogos> _jogosList;
        public List<Jogos> ListaJogos
        {
            get { return _jogosList; }
            set
            {
                _jogosList = value;
                OnPropertyChanged();
            }
        }
        public ICommand CadastrarCommand { get; set; }

        void Cadastrar()
        {

            Jogos jogos = new Jogos();

            jogos.Nome = Nome;
            //jogos.Imagem = Imagem;
            jogos.Preco = Preco;
            jogos.Desc = Desc;


            jogosService.Adicionar(jogos);

            Listar();

            App.Current.MainPage.DisplayAlert("Sucesso", "Jogo cadastrado com sucesso!", "OK");
        }

        public ICommand AdicionarCommand { get; set; }

                public async Task Adicionar(Jogos registro)
                {
                    Usuario usuarioLogado = dbSingleton.UsuarioLogado;
                    if (registro == null)
                        return;

                    bool decisao = await Shell.Current.DisplayAlert(
                        "Confirmação de exclusão",
                        $"Deseja realmente comprar este jogo '{registro.Nome}'?",
                        "Sim", "Não");

                    if (decisao)
                    {
                        Historico historico = new Historico();
                        historico.NomeJogo = registro.Nome;
                        historico.CPF = usuarioLogado.CPF;
                        historico.NomeUsuario = usuarioLogado.Nome;

                        historicoService.Adicionar(historico);
                        Listar();
                        await Shell.Current.DisplayAlert("Sucesso", "Jogo adicionado com sucesso!", "OK");
                    }
                }


        public ICommand DeletarCommand { get; set; }

        async Task Deletar(Jogos registro)
        {
            if (registro == null)
                return;

            bool decisao = await Shell.Current.DisplayAlert(
                "Confirmação de exclusão",
                $"Deseja realmente excluir o jogo '{registro.Nome}'?",
                "Sim", "Não");

            if (decisao)
            {
                jogosService.Excluir(registro);
                Listar();
                await Shell.Current.DisplayAlert("Sucesso", "Jogo excluído com sucesso!", "OK");
            }
        }

        public ICommand ConsultarCommand { get; set; }
        public void Consultar()
        {
            Jogos jogos = jogosService.ConsultarNome(_nome);

            Nome = jogos.Nome;
            //Imagem = jogos.Imagem;
            Preco = jogos.Preco;
            Desc = jogos.Desc;
        }

        public ICommand VoltarCommand { get; set; }
        void VoltarComm()
        {
            Voltar();
        }

        

        public ICommand ListagemCommand { get; set; }

        public void Listar()
        {
            ListaJogos = jogosService.ConsultarTodos();
        }

        public ICommand ChecagemCommand { get; set; }

        public void Checar()
        {
            Usuario usuario = FakeDBSingleton.Instancia.UsuarioLogado;

            if (usuario.Admin == true)
            {
                Admin = true;
                Cliente = false;
            }
            else
            {
                Admin = false;
                Cliente = true;
            }
        }

        public JogosViewModel()
        {
            CadastrarCommand = new Command(Cadastrar);
            ConsultarCommand = new Command(Consultar);
            VoltarCommand = new Command(VoltarComm);
            ListagemCommand = new Command(Listar);
            ChecagemCommand = new Command(Checar);
            DeletarCommand = new Command<Jogos>(async (registro) => await Deletar(registro));
            AdicionarCommand = new Command<Jogos>(async (registro) => await Adicionar(registro));


            Checar();
            Listar();
        }

    }
}
