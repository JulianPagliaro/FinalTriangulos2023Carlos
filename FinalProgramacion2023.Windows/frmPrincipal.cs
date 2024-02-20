using FinalProgramacion2023.Datos;
using FinalProgramacion2023.Entidades;

namespace FinalProgramacion2023.Windows
{
    public partial class frmPrincipal : Form
    {
        private RepositorioDeTriangulos repo;
        private List<Triangulo> lista;
        int valorFiltro;
        bool filterOn = false;
        public frmPrincipal()
        {
            InitializeComponent();
            repo = new RepositorioDeTriangulos();
            ActualizarCantidadDeRegistros();
            txtCantidad.Text = repo.GetCantidad().ToString();
        }
        public int ContarTriangulosMostrados()
        {
            return dgvDatos.Rows.Count;
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            frmTrianguloAE Form = new frmTrianguloAE() { Text = "Agregar Triángulo" };
            DialogResult dr = Form.ShowDialog(this);
            if (dr == DialogResult.Cancel) { return; }
            Triangulo triangulo = Form.GetTriangulo();

            if (!repo.Existe(triangulo))
            {
                repo.Agregar(triangulo);
                ActualizarCantidadDeRegistros();
                DataGridViewRow l = ConstruirFila();
                SetearFila(l, triangulo);
                AgregarFila(l);

                MessageBox.Show("Fila agregada con éxito", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (triangulo.Lado1 + triangulo.Lado2 <= triangulo.Lado3 || triangulo.Lado1 + triangulo.Lado3 <= triangulo.Lado2 || triangulo.Lado2 + triangulo.Lado3 <= triangulo.Lado1)
                    MessageBox.Show("El objeto ingresado no es un tríangulo", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Registro existente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AgregarFila(DataGridViewRow l)
        {
            dgvDatos.Rows.Add(l);
        }
        private void SetearFila(DataGridViewRow l, Triangulo triangulo)
        {
            l.Cells[colLadoA.Index].Value = triangulo.GetLado1();
            l.Cells[colLadoB.Index].Value = triangulo.GetLado2();
            l.Cells[colLadoC.Index].Value = triangulo.GetLado3();
            l.Cells[colColores.Index].Value = triangulo.ColorRelleno;
            l.Cells[colTipoDeTriangulo.Index].Value = triangulo.GetTriangleType();
            l.Cells[colBorde.Index].Value = triangulo.TipoDeBorde;
            l.Cells[colArea.Index].Value = triangulo.GetArea().ToString(".000");
            l.Cells[colPerimetro.Index].Value = triangulo.GetPerimetro().ToString(".000");
            l.Tag = triangulo;
        }
        private DataGridViewRow ConstruirFila()
        {
            var l = new DataGridViewRow();
            l.CreateCells(dgvDatos);
            return l;
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            if (repo.GetCantidad() > 0)
            {
                RecargarGrilla();
            }
        }
        private void RecargarGrilla()
        {
            valorFiltro = 0;
            filterOn = false;
            tsbFiltrar.BackColor = SystemColors.Control;
            lista = repo.GetLista();
            MostrarDatosEnGrilla();
            ActualizarCantidadDeRegistros();
        }
        private void MostrarDatosEnGrilla()
        {
            dgvDatos.Rows.Clear();
            foreach (var tria in lista)
            {
                DataGridViewRow l = ConstruirFila();
                SetearFila(l, tria);
                AgregarFila(l);
            }
        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            DialogResult dr = MessageBox.Show("Desea eliminar la fila seleccionada?", "Confirmar eliminación", MessageBoxButtons.YesNo,
               MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No) { return; }
            else
            {
                var l = dgvDatos.SelectedRows[0];
                QuitarFila(l);
                var triaBorrar = (Triangulo)l.Tag;
                repo.Borrar(triaBorrar);
                ActualizarCantidadDeRegistros();
                MessageBox.Show("Fila eliminada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void ActualizarCantidadDeRegistros()
        {
            if (valorFiltro > 0)
            {
                txtCantidad.Text = repo.GetCantidad(valorFiltro).ToString();
            }
            else
            {
                txtCantidad.Text = repo.GetCantidad().ToString();
            }
        }
        private void QuitarFila(DataGridViewRow l)
        {
            dgvDatos.Rows.Remove(l);
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }

            var FilaSeleccionada = dgvDatos.SelectedRows[0];
            Triangulo triangulo = (Triangulo)FilaSeleccionada.Tag;
            Triangulo trianguloCopia = (Triangulo)triangulo.Clone();
            frmTrianguloAE frm = new frmTrianguloAE() { Text = "Editar triangulo" };
            frm.SetTriangulo(triangulo);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            triangulo = frm.GetTriangulo();
            if (!repo.Existe(triangulo))
            {
                repo.Editar(trianguloCopia, triangulo);
                SetearFila(FilaSeleccionada, triangulo);
                MessageBox.Show("Fila editada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                SetearFila(FilaSeleccionada, trianguloCopia);
                MessageBox.Show("Registro existente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbFiltrar_Click(object sender, EventArgs e)
        {
            if (!filterOn)
            {
                var entradaValorFiltro = Microsoft.VisualBasic.Interaction.InputBox("Ingrese un valor para filtrar por color \n \n 1 = Rojo \n 2 = Azul \n 3 = Verde",
            "Filtrar por Color:",
            "0", 200, 200);
                if (!int.TryParse(entradaValorFiltro, out valorFiltro))
                {
                    return;
                }
                if (valorFiltro <= 0)
                {
                    return;
                }
                lista = repo.Filtrar(valorFiltro);
                tsbFiltrar.BackColor = Color.LightBlue;
                filterOn = true;
                MostrarDatosEnGrilla();
                ActualizarContador();
            }
            else
            {
                MessageBox.Show("Filtro aplicado! \n Debe actualizar la grilla",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void ActualizarContador()
        {
            txtCantidad.Text = ContarTriangulosMostrados().ToString();
        }

        private void tsbActualizar_Click(object sender, EventArgs e)
        {
            RecargarGrilla();
        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
        

