using Ejemplo_DAO_DTO_Singleton.UI;

namespace Ejemplo_DAO_DTO_Singleton
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void mnuItemClientes_Click_1(object sender, EventArgs e)
        {
            FormClientes form = FormClientes.Form;
            form.MdiParent = this;
            form.Show();
            form.BringToFront();
        }
    }
}