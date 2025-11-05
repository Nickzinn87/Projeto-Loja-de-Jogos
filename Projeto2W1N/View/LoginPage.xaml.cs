using Projeto2W1N.ViewModel;

namespace Projeto2W1N.View;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
        BindingContext = new UsuarioViewModel();
    }

    private void btnLogin_Clicked(object sender, EventArgs e)
    {
    
    }

    private void btnCadastrar_Clicked(object sender, EventArgs e)
    {

    }
}