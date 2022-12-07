using pim_desktop.Components;
using pim_desktop.Enums;
using pim_desktop.Model;
using pim_desktop.Repository.ApoliceRepository;
using pim_desktop.Repository.AutomovelRepository;
using pim_desktop.Repository.ClienteRepository;
using pim_desktop.Repository.FuncionarioRepository;
using pim_desktop.Repository.PlanoRepository;
using pim_desktop.Validators;
using pim_desktop.Views.Modals;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pim_desktop.Views
{
    public partial class RealizarVenda : Form
    {
        ApolicesModel apolicesModel = new ApolicesModel();
        ApoliceRepository apoliceRepository = new ApoliceRepository();
        ClienteRepository clienteRepository = new ClienteRepository();
        PlanoRepository planoRepository = new PlanoRepository();
        AutomovelRepository automovelRepository = new AutomovelRepository();
        FuncionarioRepository funcionarioRepository = new FuncionarioRepository();
        List<FuncionarioListModel> funcionarioListModels = new List<FuncionarioListModel>();
        List<PlanoListModel> planoListModels = new List<PlanoListModel>();
        List<AutomovelListModel> automovelListModels = new List<AutomovelListModel>();

        public RealizarVenda()
        {
            InitializeComponent();
            InitFormulario();
        }

        private async void searchById_Click(object sender, EventArgs e)
        {
            var listTemp = await clienteRepository.GetAllClientes();
            automovelDropdown.Items.Clear();
            if (Validadores.TextValidator(clienteInput.Text))
            {
                var clientePf = listTemp.Find((e) => e.Nome.ToLower() == clienteInput.Text.ToLower() && e.TipoCliente == TipoCliente.Pessoa_Fisica);
                var clientePj = listTemp.Find((e) => e.RazaoSocial.ToLower() == clienteInput.Text.ToLower());
                var automoveis = await automovelRepository.GetAllAutomoveis();
                automovelListModels.Clear();

                if (clientePf != null)
                {
                   var autos = automoveis.Where((e) => e.IdCliente == clientePf.Id).ToList();
                    autos.ForEach((e) => automovelListModels.Add(new AutomovelListModel(e.Id, e.Modelo)));
                    foreach (var a in automovelListModels)
                        automovelDropdown.Items.Add(a.Name);
                    ChangeStatus(true);
                }
                else if (clientePj != null)
                {
                    var autos = automoveis.Where((e) => e.IdCliente == clientePj.Id).ToList();
                    autos.ForEach((e) => automovelListModels.Add(new AutomovelListModel(e.Id, e.Modelo)));
                    foreach (var a in automovelListModels)
                        automovelDropdown.Items.Add(a.Name);
                    ChangeStatus(true);
                }
                else
                {
                    ChangeStatus(false);
                    Clear();
                    new CreateResponseModal("NENHUM CLIENTE\nENCONTRADO!").Show();
                }
                    
            }
            else
                new CreateResponseModal("INSIRA UM NOME VÁLIDO").Show();
        }

        private async void submitBtn_Click(object sender, EventArgs e)
        {
            var listTemp = await clienteRepository.GetAllClientes();
            if (ValidarForm())
            {
                var plan = planoListModels.Find((e) => e.Name == planoDropdown.Text);
                var funcionario = funcionarioListModels.Find((e) => e.Name == vendedorDropdown.Text);
                var automovel = automovelListModels.Find((e) => e.Name == automovelDropdown.Text);
                
                var clientepf = listTemp.Find((e) => e.Nome.ToLower() == clienteInput.Text.ToLower());
                var clientepj = listTemp.Find((e) => e.RazaoSocial.ToLower() == clienteInput.Text.ToLower());
                if(clientepf != null)
                    apolicesModel.IdCliente = clientepf.Id;
                else if (clientepj != null)
                    apolicesModel.IdCliente = clientepj.Id;
                apolicesModel.FormaPagamento = (FormaPagamento)fPagDropdown.SelectedIndex;
                if (plan != null)
                    apolicesModel.IdPlano = plan.Id;
                if (funcionario != null)
                    apolicesModel.IdFuncionario = funcionario.Id;
                if (automovel != null)
                    apolicesModel.IdAutomovel = (int)automovel.Id;
                apoliceRepository.PostApolice(apolicesModel);
                AutomovelModel automodel = await automovelRepository.GetAutomovelById(apolicesModel.IdAutomovel);
                automodel.Status = Status.Ativo;
                automovelRepository.ChangeStatusAutomovel(automodel);
                Clear();

            }

        }

        void ChangeStatus(bool status)
        {
            planoDropdown.Enabled = status;
            automovelDropdown.Enabled = status;
            fPagDropdown.Enabled = status;
            vendedorDropdown.Enabled = status;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            ChangeStatus(false);
            Clear();
        }

        private bool ValidarForm()
        {
            bool formValido;

            if (!Validadores.TextValidator(clienteInput.Text))
            {
                new CreateResponseModal("INSIRA UM CLIENTE VÁLIDO!").Show();
                formValido = false;
            }
            else if (!Validadores.ComboxValidator(automovelDropdown))
            {
                new CreateResponseModal("INSIRA UM AUTOMOVEL VÁLIDO!").Show();
                formValido = false;
            }
            else if (!Validadores.ComboxValidator(planoDropdown))
            {
                new CreateResponseModal("INSIRA UM PLANO VÁLIDO!").Show();
                formValido = false;
            }
            else if (!Validadores.ComboxValidator(vendedorDropdown))
            {
                new CreateResponseModal("INSIRA UM FUNCIONARIO VÁLIDO!").Show();
                formValido = false;
            }
            else if(!Validadores.ComboxValidator(vendedorDropdown))
            {
                new CreateResponseModal("INSIRA UMA FORMA DE\nPAGAMENTO VÁLIDO!").Show();
                formValido = false;
            }
              
            else
                formValido = true;

            return formValido;
        }


        private void Clear()
        {
            clienteInput.Text = "";
            automovelDropdown.SelectedIndex = -1;
            automovelDropdown.Items.Clear();
            fPagDropdown.SelectedIndex = -1;
            planoDropdown.SelectedIndex = -1;
            vendedorDropdown.SelectedIndex = -1;
            automovelListModels.Clear();
        }

        private async void InitFormulario()
        {
            
            var listTempPlanos = await planoRepository.GetAllPlanos();
            var listTempFuncionarios = await funcionarioRepository.GetAllFuncionarios();
            listTempPlanos.ForEach((e) => planoListModels.Add(new PlanoListModel(e.Id, e.NomePlano)));
            listTempFuncionarios.ForEach((e) => funcionarioListModels.Add(new FuncionarioListModel(e.Id, e.Nome)));
            foreach (var p in planoListModels)
                planoDropdown.Items.Add(p.Name);
            foreach (var v in funcionarioListModels)
                vendedorDropdown.Items.Add(v.Name);
            fPagDropdown.DataSource = Enum.GetValues(typeof(FormaPagamento));
            fPagDropdown.SelectedIndex = -1;
            vendedorDropdown.SelectedIndex = -1;
            planoDropdown.SelectedIndex = -1;
            ChangeStatus(false);
        }

        #region ViewsNa
        private void reloadButton_Click(object sender, EventArgs e)
        {
            Clear();

        }

        private void editBtn_Click(object sender, EventArgs e)
        {
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
        }
        #endregion
    }
}
