using System.Collections.ObjectModel;
using INF0999_Projeto.Model;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;
using System.IO;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace INF0999_Projeto.ViewModel
{
    public class AgendamentoViewModel : ObservableObject
    {
        private Model.Produtor _produtor;
        private Model.Lixo _lixoSelecionado;
        public ObservableCollection<Lixo> listaLixo { get; set; }
        public RelayCommand Novox { get; set; }
        public RelayCommand Agendarx { get; set; }
        public RelayCommand Deletarx { get; set; }
        public RelayCommand Editarx { get; set; }
        public RelayCommand Sairx { get; set; }
        JsonArray coletas = new JsonArray();
        JsonObject listaDeColetas = new JsonObject();
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
            if (this.Produtor != null)
            {
                JsonObject json = new JsonObject();
                while (listaLixo.Count > 0)
                {
                    json[listaLixo[0].Item] = listaLixo[0].Quantidade;
                    listaLixo.Remove(listaLixo[0]);
                }
                InsereColetaJson(json);
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
            LeJsonColeta();
        }
        private void InsereColetaJson(JsonObject json)
        {

            var novacoleta = new JsonObject();
            novacoleta["Nome"] = this.Produtor.Nome;
            novacoleta["Endereco"] = this.Produtor.Endereço;
            novacoleta["Telefone"] = this.Produtor.Telefone;
            novacoleta["Email"] = this.Produtor.Email;
            novacoleta["Lixos"] = json;
            this.coletas.Add(novacoleta);
            CriaJson();
        }
        public void CriaJson()
        {
            var output_filepath = "Dados/Coleta.json";
            listaDeColetas["Coletas"] = coletas;
            JsonSerializerOptions options = new JsonSerializerOptions();
            options.WriteIndented = true;
            using FileStream fs = new(output_filepath, FileMode.Create, FileAccess.Write);
            using StreamWriter sw = new(fs);
            sw.Write(listaDeColetas.ToJsonString(options));
            sw.Flush();
            sw.Close();
        }
        private void LeJsonColeta()
        {
            using (FileStream fs = File.OpenRead("Dados/Coleta.json"))
            {
                JsonDocument jsonDoc = JsonDocument.ParseAsync(fs).Result;
                JsonElement element = jsonDoc.RootElement;

                foreach (JsonProperty j in element.EnumerateObject())
                {
                    foreach (JsonElement i in j.Value.EnumerateArray())
                    {
                        var newperson = new JsonObject();
                        foreach (JsonProperty property in i.EnumerateObject())
                        {
                            if (property.Name.Equals("Lixos"))
                            {
                                JsonObject json = new JsonObject();
                                foreach (var item in property.Value.EnumerateObject())
                                {
                                    json[item.Name] = int.Parse(item.Value.ToString());
                                }
                                newperson["Lixos"] = json;
                            }
                            else
                            {
                                newperson[property.Name] = property.Value.ToString();
                            }
                        }
                        this.coletas.Add(newperson);
                    }
                }
            }
        }
    }
    public class OpenLixoWindowMessage : ValueChangedMessage<EditaLixoViewModel>
    {
        public OpenLixoWindowMessage(EditaLixoViewModel LixoViewModel) : base(LixoViewModel) { }
    }
    public class OpenAgendamentoWindowMessage : ValueChangedMessage<EditaProdutorViewModel>
    {
        public OpenAgendamentoWindowMessage(EditaProdutorViewModel ProdutorViewModel) : base(ProdutorViewModel) { }
    }
}