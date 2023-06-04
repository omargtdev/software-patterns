using Ejemplo_ArquitecturaMVC.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejemplo_ArquitecturaMVC.Views
{
    public partial class ClienteView : Form
    {

        public ClienteView()
        {
            InitializeComponent();
            ClienteController controller = new(this);
        }
    }
}
