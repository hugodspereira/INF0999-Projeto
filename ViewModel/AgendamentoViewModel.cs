using System.Collections.ObjectModel;
using INF0999_Projeto.Model;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;

namespace INF0999_Projeto.ViewModel
{
    public class AgendamentoViewModel : ObservableObject
    {
        private Model.Produtor _produtor;
        private Model.Lixo _lixoSelecionado;
        public ObservableCollection<Lixo> listaLixo { get; set; }
        // public ObservableCollection<Produtor> listaProdutor { get; set; }
        public RelayCommand Novox { get; set; }
        public RelayCommand Agendarx { get; set; }
        public RelayCommand Deletarx { get; set; }
        public RelayCommand Editarx { get; set; }
        public RelayCommand Sairx { get; set; }
        private void NovoCMD()
        {
            var lixoViewModel = new EditaLixoViewModel();
            WeakReferenceMessenger.Default.Send(new OpenLixoWindowMessage(lixoViewModel));
            if (lixoViewModel.lixo != null)
            {
                this.listaLixo.Add(lixoViewModel.lixo);
                this.LixoSelecionado = lixoViewModel.lixo;
            }
        }
        private void AgendarCMD()
        {
            var agendamentoViewModel = new EditaProdutorViewModel();
            WeakReferenceMessenger.Default.Send(new OpenAgendamentoWindowMessage(agendamentoViewModel));
            this.Produtor = agendamentoViewModel.produtor;
            if (agendamentoViewModel != null)
            {
                // json method
            }
            while (listaLixo.Count > 0) {
                listaLixo.Remove(listaLixo[0]);
            }
            Agendarx.NotifyCanExecuteChanged();
        }
        private void EditarCMD()
        {
            var lixoViewModel = new EditaLixoViewModel();
            var cloneLixo = (Model.Lixo)this.LixoSelecionado.Clone();
            lixoViewModel.lixo = cloneLixo;
            WeakReferenceMessenger.Default.Send(new OpenLixoWindowMessage(lixoViewModel));
            if (lixoViewModel.lixo != null)
            {
                this.LixoSelecionado.Item = cloneLixo.Item;
                this.LixoSelecionado.Quantidade = cloneLixo.Quantidade;
            }
        }
        private void DeletarCMD()
        {
            this.listaLixo.Remove(this.LixoSelecionado);
            if (this.listaLixo.Count > 0)
                this.LixoSelecionado = this.listaLixo[0];
            else
                this.LixoSelecionado = null;
        }
        private void SairCMD()
        {
            System.Windows.Application.Current.Shutdown();
        }
        private bool CanAgendarCMD()
        {
            return this.listaLixo.Count > 0;
        }
        private bool CanDeletarCMD()
        {
            return this.LixoSelecionado != null;
        }
        private bool CanEditarCMD()
        {
            return this.LixoSelecionado != null;
        }
        public Lixo LixoSelecionado
        {
            get { return _lixoSelecionado; }
            set
            {
                SetProperty(ref _lixoSelecionado, value);
                Agendarx.NotifyCanExecuteChanged();
                Deletarx.NotifyCanExecuteChanged();
                Editarx.NotifyCanExecuteChanged();
            }
        }
        public Produtor Produtor
        {
            get { return _produtor; }
            set
            {
                SetProperty(ref _produtor, value);
            }
        }
        public AgendamentoViewModel()
        {
            Novox = new RelayCommand(NovoCMD);
            Agendarx = new RelayCommand(AgendarCMD, CanAgendarCMD);
            Deletarx = new RelayCommand(DeletarCMD, CanDeletarCMD);
            Editarx = new RelayCommand(EditarCMD, CanEditarCMD);
            Sairx = new RelayCommand(SairCMD);
            listaLixo = new ObservableCollection<Lixo>();
            Produtor = new Produtor();
            PreparaColetorCollection();
        }
        private void PreparaColetorCollection()
        {
            var Lixo1 = new Lixo
            {
                Item = "Garrafa PET",
                Quantidade = 10
            };
            this.listaLixo.Add(Lixo1);
            var Lixo2 = new Lixo
            {
                Item = "Alumínio",
                Quantidade = 30
            };
            this.listaLixo.Add(Lixo2);
            var Lixo3 = new Lixo
            {
                Item = "Papel A4",
                Quantidade = 1000
            };
            this.listaLixo.Add(Lixo3);
            LixoSelecionado = this.listaLixo[0];
        }
    }
    public class OpenLixoWindowMessage : ValueChangedMessage<EditaLixoViewModel>
    {
        public OpenLixoWindowMessage(EditaLixoViewModel LixoViewModel) : base(LixoViewModel) {}
    }
    public class OpenAgendamentoWindowMessage : ValueChangedMessage<EditaProdutorViewModel>
    {
        public OpenAgendamentoWindowMessage(EditaProdutorViewModel ProdutorViewModel) : base(ProdutorViewModel) {}
    }
}