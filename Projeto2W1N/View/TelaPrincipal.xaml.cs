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
            if (usuario.Admin == true)
            {
                testando.Text = $"Bem-vindo ao sistema, {usuario.Nome}!";
            }
            else
            {
                testando.Text = $"Bem-vindo a nossa loja de jogos, {usuario.Nome}!";
            }

            jogosViewModel.Checar();
        }
    }
}