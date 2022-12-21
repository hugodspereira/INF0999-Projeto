using System.Windows;
using CommunityToolkit.Mvvm.Messaging;
using teste_projeto_final.ViewModel;

namespace teste_projeto_final
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