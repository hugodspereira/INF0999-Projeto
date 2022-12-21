using System.Windows;
using CommunityToolkit.Mvvm.Messaging;
using INF0999_Projeto.ViewModel;

namespace INF0999_Projeto
{
    public partial class LixoWindow : Window
    {
        public LixoWindow()
        {
            InitializeComponent();
            WeakReferenceMessenger.Default.Register<CloseLixoWindowMessage>(this, (r, m) =>
            {
                this.Hide();
            });
            DataContext = new EditaLixoViewModel();
        }
    }
}