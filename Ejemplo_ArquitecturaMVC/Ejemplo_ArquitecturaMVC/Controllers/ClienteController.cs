using Ejemplo_ArquitecturaMVC.Models.DAO;
using Ejemplo_ArquitecturaMVC.Views;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejemplo_ArquitecturaMVC.Controllers
{
    internal class ClienteController
    {
        // Asignar la vista
        readonly ClienteView vista;
        readonly ClienteDAO dao = new();

        public ClienteController(ClienteView vista)
        {
            this.vista = vista;
            vista.Load += new EventHandler(ClientList); // Load
            vista.txtFiltrarCliente.TextChanged += new EventHandler(ClientList);
        }

        private void ClientList(object? sender, EventArgs e)
        {
            vista.dgvCliente.DataSource = dao.Listar(vista.txtFiltrarCliente.Text.Trim());
        }
    }
}
