
namespace tp3
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtDiasSimulacion = new TextBox();
            txtRemuneraciones = new TextBox();
            txtCostosVariables = new TextBox();
            txtValorVenta = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            btnSimulacion = new Button();
            dgvSimulacion = new DataGridView();
            txtDesdeDia = new TextBox();
            txtCantidadDiasMostrar = new TextBox();
            label6 = new Label();
            label5 = new Label();
            dgvProb = new DataGridView();
            Obreros = new DataGridViewTextBoxColumn();
            CantDias = new DataGridViewTextBoxColumn();
            Media = new DataGridViewTextBoxColumn();
            Probabilidad = new DataGridViewTextBoxColumn();
            Limite_Inferior = new DataGridViewTextBoxColumn();
            Limite_Superior = new DataGridViewTextBoxColumn();
            CantObreros = new Label();
            txtCantidadObrerosNomina = new TextBox();
            btnLimpiar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvSimulacion).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvProb).BeginInit();
            SuspendLayout();
            // 
            // txtDiasSimulacion
            // 
            txtDiasSimulacion.Location = new Point(203, 60);
            txtDiasSimulacion.Name = "txtDiasSimulacion";
            txtDiasSimulacion.Size = new Size(85, 23);
            txtDiasSimulacion.TabIndex = 2;
            // 
            // txtRemuneraciones
            // 
            txtRemuneraciones.Location = new Point(203, 84);
            txtRemuneraciones.Name = "txtRemuneraciones";
            txtRemuneraciones.Size = new Size(85, 23);
            txtRemuneraciones.TabIndex = 3;
            // 
            // txtCostosVariables
            // 
            txtCostosVariables.Location = new Point(203, 108);
            txtCostosVariables.Name = "txtCostosVariables";
            txtCostosVariables.Size = new Size(85, 23);
            txtCostosVariables.TabIndex = 4;
            // 
            // txtValorVenta
            // 
            txtValorVenta.Location = new Point(203, 135);
            txtValorVenta.Name = "txtValorVenta";
            txtValorVenta.Size = new Size(85, 23);
            txtValorVenta.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 62);
            label1.Name = "label1";
            label1.Size = new Size(130, 15);
            label1.TabIndex = 4;
            label1.Text = "Cantidad dias a simular";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(25, 138);
            label2.Name = "label2";
            label2.Size = new Size(81, 15);
            label2.TabIndex = 5;
            label2.Text = "Valor de venta";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(25, 110);
            label3.Name = "label3";
            label3.Size = new Size(92, 15);
            label3.TabIndex = 6;
            label3.Text = "Costos variables";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(27, 86);
            label4.Name = "label4";
            label4.Size = new Size(95, 15);
            label4.TabIndex = 7;
            label4.Text = "Remuneraciones";
            // 
            // btnSimulacion
            // 
            btnSimulacion.Location = new Point(30, 240);
            btnSimulacion.Name = "btnSimulacion";
            btnSimulacion.Size = new Size(258, 49);
            btnSimulacion.TabIndex = 8;
            btnSimulacion.Text = "Iniciar Simulacion";
            btnSimulacion.UseVisualStyleBackColor = true;
            btnSimulacion.Click += btnSimulacion_Click;
            // 
            // dgvSimulacion
            // 
            dgvSimulacion.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSimulacion.Location = new Point(348, 240);
            dgvSimulacion.Name = "dgvSimulacion";
            dgvSimulacion.RowHeadersWidth = 51;
            dgvSimulacion.Size = new Size(1132, 443);
            dgvSimulacion.TabIndex = 9;
            // 
            // txtDesdeDia
            // 
            txtDesdeDia.Location = new Point(203, 164);
            txtDesdeDia.Name = "txtDesdeDia";
            txtDesdeDia.Size = new Size(85, 23);
            txtDesdeDia.TabIndex = 6;
            // 
            // txtCantidadDiasMostrar
            // 
            txtCantidadDiasMostrar.Location = new Point(203, 193);
            txtCantidadDiasMostrar.Name = "txtCantidadDiasMostrar";
            txtCantidadDiasMostrar.Size = new Size(85, 23);
            txtCantidadDiasMostrar.TabIndex = 7;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(25, 195);
            label6.Name = "label6";
            label6.Size = new Size(62, 15);
            label6.TabIndex = 13;
            label6.Text = "Dias Hasta";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(25, 166);
            label5.Name = "label5";
            label5.Size = new Size(59, 15);
            label5.TabIndex = 14;
            label5.Text = "Dia Desde";
            // 
            // dgvProb
            // 
            dgvProb.AllowUserToAddRows = false;
            dgvProb.AllowUserToDeleteRows = false;
            dgvProb.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProb.Columns.AddRange(new DataGridViewColumn[] { Obreros, CantDias, Media, Probabilidad, Limite_Inferior, Limite_Superior });
            dgvProb.Location = new Point(348, 26);
            dgvProb.Margin = new Padding(3, 2, 3, 2);
            dgvProb.Name = "dgvProb";
            dgvProb.RowHeadersWidth = 51;
            dgvProb.Size = new Size(714, 209);
            dgvProb.TabIndex = 15;
            // 
            // Obreros
            // 
            Obreros.HeaderText = "Ausentes";
            Obreros.MinimumWidth = 6;
            Obreros.Name = "Obreros";
            Obreros.ReadOnly = true;
            Obreros.Width = 125;
            // 
            // CantDias
            // 
            CantDias.HeaderText = "Cantidad de dias";
            CantDias.MinimumWidth = 6;
            CantDias.Name = "CantDias";
            CantDias.Width = 125;
            // 
            // Media
            // 
            Media.HeaderText = "Media";
            Media.Name = "Media";
            Media.ReadOnly = true;
            // 
            // Probabilidad
            // 
            Probabilidad.HeaderText = "Probabilidad";
            Probabilidad.Name = "Probabilidad";
            Probabilidad.ReadOnly = true;
            // 
            // Limite_Inferior
            // 
            Limite_Inferior.HeaderText = "Limite_Inferior";
            Limite_Inferior.Name = "Limite_Inferior";
            Limite_Inferior.ReadOnly = true;
            // 
            // Limite_Superior
            // 
            Limite_Superior.HeaderText = "Limite_Superior";
            Limite_Superior.Name = "Limite_Superior";
            Limite_Superior.ReadOnly = true;
            // 
            // CantObreros
            // 
            CantObreros.AutoSize = true;
            CantObreros.Location = new Point(25, 33);
            CantObreros.Name = "CantObreros";
            CantObreros.Size = new Size(114, 15);
            CantObreros.TabIndex = 17;
            CantObreros.Text = "Cantidad de obreros";
            // 
            // txtCantidadObrerosNomina
            // 
            txtCantidadObrerosNomina.Location = new Point(203, 31);
            txtCantidadObrerosNomina.Name = "txtCantidadObrerosNomina";
            txtCantidadObrerosNomina.Size = new Size(85, 23);
            txtCantidadObrerosNomina.TabIndex = 1;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(30, 295);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(258, 49);
            btnLimpiar.TabIndex = 9;
            btnLimpiar.Text = "Limpiar Campos";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1505, 695);
            Controls.Add(btnLimpiar);
            Controls.Add(CantObreros);
            Controls.Add(txtCantidadObrerosNomina);
            Controls.Add(dgvProb);
            Controls.Add(label5);
            Controls.Add(label6);
            Controls.Add(txtCantidadDiasMostrar);
            Controls.Add(txtDesdeDia);
            Controls.Add(dgvSimulacion);
            Controls.Add(btnSimulacion);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtValorVenta);
            Controls.Add(txtCostosVariables);
            Controls.Add(txtRemuneraciones);
            Controls.Add(txtDiasSimulacion);
            Name = "Form1";
            Text = "Montecarlo Ausentismo";
            ((System.ComponentModel.ISupportInitialize)dgvSimulacion).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvProb).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private TextBox txtDiasSimulacion;
        private TextBox txtRemuneraciones;
        private TextBox txtCostosVariables;
        private TextBox txtValorVenta;
        private Label label1;
        private Label label2; 
        private Label label3; 
        private Label label4;
        private Button btnSimulacion;
        private DataGridView dgvSimulacion;
        private TextBox txtDesdeDia;
        private TextBox txtCantidadDiasMostrar;
        private Label label6;
        private Label label5;
        private DataGridView dgvProb;
        private Label CantObreros;
        private TextBox txtCantidadObrerosNomina;
        private Button btnLimpiar;
        private DataGridViewTextBoxColumn Obreros;
        private DataGridViewTextBoxColumn CantDias;
        private DataGridViewTextBoxColumn Media;
        private DataGridViewTextBoxColumn Probabilidad;
        private DataGridViewTextBoxColumn Limite_Inferior;
        private DataGridViewTextBoxColumn Limite_Superior;
    }
}
