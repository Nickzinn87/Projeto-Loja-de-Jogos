using Projeto2W1N.Models;
using Projeto2W1N.ViewModel;

namespace Projeto2W1N.View;

public partial class TelaPrincipal : ContentPage
{

    public TelaPrincipal()
    {
        InitializeComponent();
        BindingContext = new JogosViewModel();
        Usuario usuario = FakeDBSingleton.Instancia.UsuarioLogado;
        JogosViewModel jogosViewModel = new JogosViewModel();



        if (usuario != null)
        {
            testando.Text = $"Bem-vindo, {usuario.Nome}!";
            testando.Text = usuario.Admin ? "Função: Administrador" : "Função: Usuário";

            jogosViewModel.Checar();
        }
    }
}