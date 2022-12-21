using System.Windows;
using CommunityToolkit.Mvvm.Messaging;
using teste_projeto_final.ViewModel;

namespace teste_projeto_final
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