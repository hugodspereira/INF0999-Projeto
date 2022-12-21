using teste_projeto_final.ViewModel;
using System.Windows;
using CommunityToolkit.Mvvm.Messaging;

namespace teste_projeto_final
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ONG : Window
    {
        public ONG()
        {
            InitializeComponent();
            WeakReferenceMessenger.Default.Register<OpenWindowMessage>(this, (r, m) =>
            {
                var fw = new teste_projeto_final.ColetorWindow();
                fw.DataContext = m.Value;
                fw.ShowDialog();
            });
            DataContext = new ViewModel.ListaColetorViewModel();
        }
    }
}
