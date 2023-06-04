using Ejemplo_DAO_DTO_Singleton.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejemplo_DAO_DTO_Singleton.UI
{
    public partial class FormClientes : Form
    {

        // SINGLETON
        private static FormClientes? _Form;
        public static FormClientes Form
        {
            // If _Form es null, entonces crea una nueva instancia
            get => _Form ??= new();
        }

        private FormClientes()
        {
            InitializeComponent();
        }

        private void MostrarRegistros(string filtro)    
        {
            ClienteDAO dao = new();
            dgvClientes.DataSource = dao.Listar(filtro);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            MostrarRegistros(txtBuscar.Text.Trim());
        }

        private void FormClientes_Load(object sender, EventArgs e)
        {
            MostrarRegistros("");
        }

        private void FormClientes_FormClosed(object sender, FormClosedEventArgs e)
        {
            _Form = null;
        }
    }
}
