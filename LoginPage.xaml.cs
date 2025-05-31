namespace ClaseNetMaui.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

    private void Clicked(object sender, EventArgs e)
    {
        if (sender is Button)
        {
            Button btn = (Button)sender;
            if (btn.Id == BtnLogin.Id)
            {
                if (string.IsNullOrEmpty(EUser.Text) || string.IsNullOrEmpty(EPassword.Text))
                {
                    DisplayAlert("Error", "Usuario o Contraseña vacios", "Ok");
                }
                else if (EUser.Text != "Jose" || EPassword.Text != "30")
                {
                    DisplayAlert("Error", "Usuario o Contraseña Invalidos", "Ok");
                }
                else
                {
                    App.Current!.MainPage = new AppShell();
                }
            }

        }
        else if (sender is ImageButton)
        {
            ImageButton btn = (ImageButton)sender;
            if (btn.Id == ImgBtnShowPassword.Id)
            {
                if (btn.Source.ToString().Contains("ic_visibility_off"))
                {
                    btn.Source = ImageSource.FromFile("ic_remove_red_eye");
                    EPassword.IsPassword = false;
                }
                else
                {
                    btn.Source = ImageSource.FromFile("ic_visibility_off");
                    EPassword.IsPassword = true;
                }
            }
        }


    }

}