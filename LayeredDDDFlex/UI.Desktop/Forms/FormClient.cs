using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Desktop.ApplicationController;

namespace UI.Desktop.Forms
{
    public partial class FormClient : Form
    {

        private readonly ClientController _clientController;

        public FormClient()
        {
            InitializeComponent();

            _clientController = new ClientController();
        }

        private void FormClient_Load(object sender, EventArgs e)
        {
            dgvClients.DataSource = _clientController.GetClientsAll(txtFilterClients.Text.Trim());
        }

        private void btnGetClients_Click(object sender, EventArgs e)
        {
            dgvClients.DataSource = _clientController.GetClientsAll(txtFilterClients.Text.Trim());
        }
    }
}
