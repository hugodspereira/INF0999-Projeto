using INF0999_Projeto.ViewModel;
using System.Windows;
using CommunityToolkit.Mvvm.Messaging;

namespace INF0999_Projeto
{
    public partial class ProdutorWindow : Window
    {
        public ProdutorWindow()
        {
            InitializeComponent();
            WeakReferenceMessenger.Default.Register<OpenLixoWindowMessage>(this, (r, m) =>
            {
                var fw = new INF0999_Projeto.LixoWindow();
                fw.DataContext = m.Value;
                fw.ShowDialog();
            });
            WeakReferenceMessenger.Default.Register<OpenAgendamentoWindowMessage>(this, (r, m) =>
            {
                var fw = new INF0999_Projeto.AgendamentoWindow();
                fw.DataContext = m.Value;
                fw.ShowDialog();
            });
            DataContext = new ViewModel.AgendamentoViewModel();
        }
    }
}