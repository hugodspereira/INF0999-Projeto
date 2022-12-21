using System.Windows;
using CommunityToolkit.Mvvm.Messaging;
using teste_projeto_final.ViewModel;

namespace teste_projeto_final
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            WeakReferenceMessenger.Default.Register<CloseLoginWindowMessage>(this, (r, m) =>
            {
                this.Hide();
            });
            DataContext = new LoginWindowViewModel();
        }
    }
}