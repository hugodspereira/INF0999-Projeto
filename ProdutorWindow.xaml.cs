using teste_projeto_final.ViewModel;
using System.Windows;
using CommunityToolkit.Mvvm.Messaging;

namespace teste_projeto_final
{
    public partial class ProdutorWindow : Window
    {
        public ProdutorWindow()
        {
            InitializeComponent();
            WeakReferenceMessenger.Default.Register<OpenLixoWindowMessage>(this, (r, m) =>
            {
                var fw = new teste_projeto_final.LixoWindow();
                fw.DataContext = m.Value;
                fw.ShowDialog();
            });
            DataContext = new ViewModel.AgendamentoViewModel();
        }
    }
}