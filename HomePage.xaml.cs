using teste_projeto_final.ViewModel;
using System.Windows;
using CommunityToolkit.Mvvm.Messaging;

namespace teste_projeto_final
{
    public partial class HomePage : Window
    {
        public HomePage()
        {
            InitializeComponent();
            WeakReferenceMessenger.Default.Register<CadastroWindowMessage>(this, (r, m) =>
            {
                var fw = new teste_projeto_final.CadastroWindow();
                fw.DataContext = m.Value;
                fw.ShowDialog();
            });
            WeakReferenceMessenger.Default.Register<LoginWindowMessage>(this, (r, m) =>
            {
                var fw = new teste_projeto_final.LoginWindow();
                fw.DataContext = m.Value;
                fw.ShowDialog();
            });
            DataContext = new ViewModel.ListaProdutorViewModel();
        }
    }
}
