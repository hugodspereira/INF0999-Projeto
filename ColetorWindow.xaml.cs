using System.Windows;
using CommunityToolkit.Mvvm.Messaging;
using INF0999_Projeto.ViewModel;

namespace INF0999_Projeto
{
    public partial class ColetorWindow : Window
    {
        public ColetorWindow()
        {
            InitializeComponent();
            WeakReferenceMessenger.Default.Register<CloseWindowMessage>(this, (r, m) =>
            {
                this.Hide();
            });
            DataContext = new EditaColetorViewModel();
        }
    }
}