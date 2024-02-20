namespace FinalProgramacion2023.Windows
{
    partial class frmTrianguloAE
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            label1 = new Label();
            txtLadoA = new TextBox();
            label2 = new Label();
            txtLadoB = new TextBox();
            label3 = new Label();
            txtLadoC = new TextBox();
            btnOK = new Button();
            btnCancelar = new Button();
            label4 = new Label();
            cboRelleno = new ComboBox();
            groupBox1 = new GroupBox();
            rbtPuntos = new RadioButton();
            rbtRayas = new RadioButton();
            rbtLineal = new RadioButton();
            errorProvider1 = new ErrorProvider(components);
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 15);
            label1.Name = "label1";
            label1.Size = new Size(47, 15);
            label1.TabIndex = 0;
            label1.Text = "Lado A:";
            // 
            // txtLadoA
            // 
            txtLadoA.Location = new Point(89, 12);
            txtLadoA.Name = "txtLadoA";
            txtLadoA.Size = new Size(100, 23);
            txtLadoA.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(26, 44);
            label2.Name = "label2";
            label2.Size = new Size(46, 15);
            label2.TabIndex = 0;
            label2.Text = "Lado B;";
            // 
            // txtLadoB
            // 
            txtLadoB.Location = new Point(89, 41);
            txtLadoB.Name = "txtLadoB";
            txtLadoB.Size = new Size(100, 23);
            txtLadoB.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(26, 73);
            label3.Name = "label3";
            label3.Size = new Size(47, 15);
            label3.TabIndex = 0;
            label3.Text = "Lado C:";
            // 
            // txtLadoC
            // 
            txtLadoC.Location = new Point(89, 70);
            txtLadoC.Name = "txtLadoC";
            txtLadoC.Size = new Size(100, 23);
            txtLadoC.TabIndex = 1;
            // 
            // btnOK
            // 
            btnOK.Location = new Point(29, 219);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(75, 61);
            btnOK.TabIndex = 2;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(238, 219);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 61);
            btnCancelar.TabIndex = 2;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(29, 108);
            label4.Name = "label4";
            label4.Size = new Size(49, 15);
            label4.TabIndex = 3;
            label4.Text = "Relleno:";
            // 
            // cboRelleno
            // 
            cboRelleno.DropDownStyle = ComboBoxStyle.DropDownList;
            cboRelleno.FormattingEnabled = true;
            cboRelleno.Location = new Point(89, 105);
            cboRelleno.Name = "cboRelleno";
            cboRelleno.Size = new Size(121, 23);
            cboRelleno.TabIndex = 4;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rbtPuntos);
            groupBox1.Controls.Add(rbtRayas);
            groupBox1.Controls.Add(rbtLineal);
            groupBox1.Location = new Point(29, 134);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(284, 76);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = " Bordes ";
            // 
            // rbtPuntos
            // 
            rbtPuntos.AutoSize = true;
            rbtPuntos.Location = new Point(168, 29);
            rbtPuntos.Name = "rbtPuntos";
            rbtPuntos.Size = new Size(62, 19);
            rbtPuntos.TabIndex = 0;
            rbtPuntos.TabStop = true;
            rbtPuntos.Text = "Puntos";
            rbtPuntos.UseVisualStyleBackColor = true;
            // 
            // rbtRayas
            // 
            rbtRayas.AutoSize = true;
            rbtRayas.Location = new Point(89, 29);
            rbtRayas.Name = "rbtRayas";
            rbtRayas.Size = new Size(55, 19);
            rbtRayas.TabIndex = 0;
            rbtRayas.TabStop = true;
            rbtRayas.Text = "Rayas";
            rbtRayas.UseVisualStyleBackColor = true;
            // 
            // rbtLineal
            // 
            rbtLineal.AutoSize = true;
            rbtLineal.Location = new Point(15, 29);
            rbtLineal.Name = "rbtLineal";
            rbtLineal.Size = new Size(56, 19);
            rbtLineal.TabIndex = 0;
            rbtLineal.TabStop = true;
            rbtLineal.Text = "Lineal";
            rbtLineal.UseVisualStyleBackColor = true;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // frmTrianguloAE
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(351, 292);
            Controls.Add(groupBox1);
            Controls.Add(cboRelleno);
            Controls.Add(label4);
            Controls.Add(btnCancelar);
            Controls.Add(btnOK);
            Controls.Add(txtLadoC);
            Controls.Add(label3);
            Controls.Add(txtLadoB);
            Controls.Add(label2);
            Controls.Add(txtLadoA);
            Controls.Add(label1);
            Name = "frmTrianguloAE";
            Text = "frmTrianguloAE";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtLadoA;
        private Label label2;
        private TextBox txtLadoB;
        private Label label3;
        private TextBox txtLadoC;
        private Button btnOK;
        private Button btnCancelar;
        private Label label4;
        private ComboBox cboRelleno;
        private GroupBox groupBox1;
        private RadioButton rbtPuntos;
        private RadioButton rbtRayas;
        private RadioButton rbtLineal;
        private ErrorProvider errorProvider1;
    }
}