using pim_desktop.Components;
using pim_desktop.Enums;
using pim_desktop.Model;
using pim_desktop.Repository.AutomovelRepository;
using pim_desktop.Repository.ClienteRepository;
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
    public partial class CrudAutomovel : Form
    {
        public FormularioStatus FormularioStatus { get; set; }
        AutomovelModel automovelModel = new AutomovelModel();
        AutomovelRepository automovelRepository = new AutomovelRepository();
        ClienteRepository clienteRepository = new ClienteRepository();
        List<ClienteListModel> clienteListModel = new List<ClienteListModel>();

        public CrudAutomovel()
        {
            InitializeComponent();
            InitFormulario();
        }

        private void reloadButton_Click(object sender, EventArgs e)
        {
            Clear();
            GetList();

        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            this.FormularioStatus = FormularioStatus.Atualizacao;
            ChangeStatus();

        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            new DeleteModal(automovelRepository.DeletarAutomovel).Show();
            GetList();

        }

        private async void searchById_Click(object sender, EventArgs e)
        {
            if (Validadores.NumberValidator(idBox.Text))
            {
                automovelModel = await automovelRepository.GetAutomovelById(int.Parse(idBox.Text));
                var cliente = clienteListModel.Find((e) => e.Id == automovelModel.IdCliente);
                if (cliente != null)
                    clienteDropdown.SelectedItem = cliente.Name;
                modeloInput.Text = automovelModel.Modelo;
                marcaInput.Text = automovelModel.Marca;
                anoModeloInput.Text = automovelModel.AnoModelo;
                corInput.Text = automovelModel.Cor;
                renavamInput.Text = automovelModel.Renavam;
                numeroMotorInput.Text = automovelModel.NumeroMotor;
                placaInput.Text = automovelModel.Placa;
                crlvInput.Text = automovelModel.Crlv;
            }
            else
            {
                new CreateResponseModal("INSIRA UM ID VÁLIDO").Show();
            }

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (ValidarForm())
            {
                var cliente = clienteListModel.Find((e) => e.Name == clienteDropdown.Text);
                if (cliente != null)
                    automovelModel.IdCliente = cliente.Id;
                automovelModel.Modelo = modeloInput.Text;
                automovelModel.Marca = marcaInput.Text;
                automovelModel.AnoModelo = anoModeloInput.Text;
                automovelModel.Cor = corInput.Text;
                automovelModel.Renavam = renavamInput.Text;
                automovelModel.NumeroMotor = numeroMotorInput.Text;
                automovelModel.Placa = placaInput.Text;
                automovelModel.Crlv = crlvInput.Text;
                if (this.FormularioStatus == FormularioStatus.Atualizacao)
                {
                    idBox.Enabled = true;
                    this.FormularioStatus = FormularioStatus.Cadastro;
                   automovelRepository.AlterarDadosAutomovel(automovelModel);
                    Clear();
                    ChangeStatus();
                }
                else if (this.FormularioStatus == FormularioStatus.Cadastro)
                {
                    automovelRepository.PostAutomovel(automovelModel);
                    Clear();
                    ChangeStatus();
                }
            }


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.FormularioStatus = FormularioStatus.Cadastro;
            Clear();
            ChangeStatus();

        }

        private bool ValidarForm()
        {
            bool formValido;
            if (!Validadores.TextValidator(modeloInput.Text))
            {
                new CreateResponseModal("INSIRA UM MODELO VÁLIDO!").Show();
                formValido = false;
            }
            else if (!Validadores.ComboxValidator(clienteDropdown))
            {
                new CreateResponseModal("INSIRA UM CLIENTE VÁLIDO!").Show();
                formValido = false;
            }
            else if (!Validadores.TextValidator(marcaInput.Text))
            {
                new CreateResponseModal("INSIRA UMA MARCA VÁLIDA!").Show();
                formValido = false;
            }
            else if (!Validadores.NumberValidator(anoModeloInput.Text) && anoModeloInput.Text.Length == 4)
            {
                new CreateResponseModal("INSIRA UM ANO VÁLIDO!").Show();
                formValido = false;
            }
            else if (!Validadores.TextValidator(corInput.Text))
            {
                new CreateResponseModal("INSIRA UMA COR VÁLIDA!").Show();
                formValido = false;
            }
            else if (!Validadores.TextValidator(renavamInput.Text))
            {
                new CreateResponseModal("INSIRA UM RENAVAM VÁLIDO!").Show();
                formValido = false;
            }
            else if (!Validadores.TextValidator(placaInput.Text) && placaInput.Text.Length == 7)
            {
                new CreateResponseModal("INSIRA UMA PLACA VÁLIDA!").Show();
                formValido = false;
            }
            else if (!Validadores.TextValidator(crlvInput.Text))
            {
                new CreateResponseModal("INSIRA UM CRLV VÁLIDO!").Show();
                formValido = false;
            }
            else
                formValido = true;

            return formValido;
        }

        private void ChangeStatus()
        {
            if (this.FormularioStatus == FormularioStatus.Atualizacao)
            {
                idBox.Enabled = true;
                searchById.Visible = true;
                clienteDropdown.Enabled = false;
                modeloInput.Enabled = false;
                marcaInput.Enabled = false;
                anoModeloInput.Enabled = false;

            }
            else if (this.FormularioStatus == FormularioStatus.Cadastro)
            {
                idBox.Enabled = false;
                searchById.Visible = false;
                clienteDropdown.Enabled = true;
                modeloInput.Enabled = true;
                marcaInput.Enabled = true;
                anoModeloInput.Enabled = true;
                
            }
        }

        private void Clear()
        {
            idBox.Text = "";
            clienteDropdown.SelectedItem = -1;
            modeloInput.Text = "";
            marcaInput.Text = "";
            anoModeloInput.Text = "";
            corInput.Text = "";
            renavamInput.Text = "";
            numeroMotorInput.Text = "";
            placaInput.Text = "";
            crlvInput.Text = "";
        }
        private async void InitFormulario()
        {

            var listTemp = await clienteRepository.GetAllClientes();
            var clientePj = new List<ClienteListModel>();
            var clientePf = new List<ClienteListModel>();
            listTemp.ForEach((e) => clientePf.Add(new ClienteListModel(e.Id, e.Nome)));
            listTemp.ForEach((e) => clientePj.Add(new ClienteListModel(e.Id, e.RazaoSocial)));
            clienteListModel.AddRange(clientePf);
            clienteListModel.AddRange(clientePj);
            this.FormularioStatus = FormularioStatus.Cadastro;
            GetList();
            foreach (var item in clienteListModel)
                if(item.Name != null && item.Name != " " && item.Name != "" && item.Name.Length != 0 && item.Name != "string")
                clienteDropdown.Items.Add(item.Name);
            clienteDropdown.SelectedIndex = -1;
            automovelList.Font = new Font("Segoe UI", 12);
            ChangeStatus();
        }

        private async void GetList()
        {
            var myGrid = new DataGridCustom();
            myGrid.EmptyResultText = "SEM DADOS PARA MOSTRAR";
            myGrid.Dock = DockStyle.Fill;
            myGrid.DataSource = new List<string>();
            try
            {
                var lst = await automovelRepository.GetAllAutomoveis();
                if (lst.Count == 0)
                automovelList.Controls.Add(myGrid);
                else
                    automovelList.DataSource = lst;
            }
            catch (Exception e)
            {
                new CreateResponseModal("ERRO: \n" + e.Message).Show();
            }
        }





        #region ViewsNa
        private void label8_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
