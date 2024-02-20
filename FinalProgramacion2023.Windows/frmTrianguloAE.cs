using FinalProgramacion2023.Entidades;

namespace FinalProgramacion2023.Windows
{
    public partial class frmTrianguloAE : Form
    {
        public frmTrianguloAE()
        {
            InitializeComponent();
        }
        private Triangulo triangulo;

        public Triangulo GetTriangulo()
        { return triangulo; }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CargarDatosComboColorRelleno();
            if (triangulo != null)
            {
                txtLadoA.Text = triangulo.Lado1.ToString();
                txtLadoB.Text = triangulo.Lado2.ToString();
                txtLadoC.Text = triangulo.Lado3.ToString();
                cboRelleno.SelectedItem = triangulo.ColorRelleno;
                if (triangulo.TipoDeBorde == TipoDeBorde.Lineal)
                {
                    rbtLineal.Checked = true;
                }
                else if (triangulo.TipoDeBorde == TipoDeBorde.Rayas)
                {
                    rbtRayas.Checked = true;
                }
                else
                {
                    rbtPuntos.Checked = true;
                }
            }
        }
        private void CargarDatosComboColorRelleno()
        {
            var listaColores = Enum.GetValues(typeof(ColorRelleno)).Cast<ColorRelleno>().ToList();
            cboRelleno.DataSource = listaColores;
            cboRelleno.SelectedIndex = 0;
        }
        public void SetTriangulo(Triangulo triangulo)
        {
            this.triangulo = triangulo;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (triangulo == null)
                {
                    triangulo = new Triangulo();
                }

                triangulo.SetLado1(int.Parse(txtLadoA.Text));
                triangulo.SetLado2(int.Parse(txtLadoB.Text));
                triangulo.SetLado3(int.Parse(txtLadoC.Text));
                triangulo.ColorRelleno = (ColorRelleno)cboRelleno.SelectedItem;

                if (rbtLineal.Checked)
                {
                    triangulo.TipoDeBorde = TipoDeBorde.Lineal;
                }
                else if (rbtRayas.Checked)
                {
                    triangulo.TipoDeBorde = TipoDeBorde.Rayas;
                }
                else
                {
                    triangulo.TipoDeBorde = TipoDeBorde.Puntos;
                }
                DialogResult = DialogResult.OK;
            }
        }
        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
           

            if (!int.TryParse(txtLadoA.Text, out int lado1) || lado1 <= 0)
            {
                valido = false;
                errorProvider1.SetError(txtLadoA, "Número no válido");
            }

            if (!int.TryParse(txtLadoB.Text, out int lado2) || lado2 <= 0)
            {
                valido = false;
                errorProvider1.SetError(txtLadoB, "Número no válido");
            }

            if (!int.TryParse(txtLadoC.Text, out int lado3) || lado3 <= 0)
            {
                valido = false;
                errorProvider1.SetError(txtLadoC, "Número no válido");
            }
            return valido;
        }
    }
}
