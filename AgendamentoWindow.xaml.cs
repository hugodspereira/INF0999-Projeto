using System.Windows;
using CommunityToolkit.Mvvm.Messaging;
using INF0999_Projeto.ViewModel;

namespace INF0999_Projeto
{
    public partial class AgendamentoWindow : Window
    {
        public AgendamentoWindow()
        {
            InitializeComponent();
            WeakReferenceMessenger.Default.Register<CloseAgendamentoWindowMessage>(this, (r, m) =>
            {
                this.Hide();
            });
            DataContext = new EditaProdutorViewModel();
        }
    }
}