using INF0999_Projeto.ViewModel;
using System.Windows;
using CommunityToolkit.Mvvm.Messaging;

namespace INF0999_Projeto
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Cooperativa : Window
    {
        public Cooperativa()
        {
            InitializeComponent();
            WeakReferenceMessenger.Default.Register<OpenWindowMessage>(this, (r, m) =>
            {
                var fw = new INF0999_Projeto.ColetorWindow();
                fw.DataContext = m.Value;
                fw.ShowDialog();
            });
            DataContext = new ViewModel.ListaColetorViewModel();
        }
    }
}
