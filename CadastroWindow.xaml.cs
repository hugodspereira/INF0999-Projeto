using System.Windows;
using CommunityToolkit.Mvvm.Messaging;
using teste_projeto_final.ViewModel;

namespace teste_projeto_final
{
    public partial class CadastroWindow : Window
    {
        public CadastroWindow()
        {
            InitializeComponent();
            WeakReferenceMessenger.Default.Register<CloseCadastroWindowMessage>(this, (r, m) =>
            {
                this.Hide();
            });
            DataContext = new CadastroWindowViewModel();
        }
    }
}