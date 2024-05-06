
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
            CantObreros = new Label();
            txtCantidadObrerosNomina = new TextBox();
            btnLimpiar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvSimulacion).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvProb).BeginInit();
            SuspendLayout();
            // 
            // txtDiasSimulacion
            // 
            txtDiasSimulacion.Location = new Point(203, 284);
            txtDiasSimulacion.Name = "txtDiasSimulacion";
            txtDiasSimulacion.Size = new Size(85, 23);
            txtDiasSimulacion.TabIndex = 0;
            // 
            // txtRemuneraciones
            // 
            txtRemuneraciones.Location = new Point(203, 308);
            txtRemuneraciones.Name = "txtRemuneraciones";
            txtRemuneraciones.Size = new Size(85, 23);
            txtRemuneraciones.TabIndex = 1;
            txtRemuneraciones.TextChanged += txtRemuneraciones_TextChanged;
            // 
            // txtCostosVariables
            // 
            txtCostosVariables.Location = new Point(203, 332);
            txtCostosVariables.Name = "txtCostosVariables";
            txtCostosVariables.Size = new Size(85, 23);
            txtCostosVariables.TabIndex = 2;
            // 
            // txtValorVenta
            // 
            txtValorVenta.Location = new Point(203, 359);
            txtValorVenta.Name = "txtValorVenta";
            txtValorVenta.Size = new Size(85, 23);
            txtValorVenta.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 286);
            label1.Name = "label1";
            label1.Size = new Size(130, 15);
            label1.TabIndex = 4;
            label1.Text = "Cantidad dias a simular";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(25, 362);
            label2.Name = "label2";
            label2.Size = new Size(81, 15);
            label2.TabIndex = 5;
            label2.Text = "Valor de venta";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(25, 334);
            label3.Name = "label3";
            label3.Size = new Size(92, 15);
            label3.TabIndex = 6;
            label3.Text = "Costos variables";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(27, 310);
            label4.Name = "label4";
            label4.Size = new Size(95, 15);
            label4.TabIndex = 7;
            label4.Text = "Remuneraciones";
            // 
            // btnSimulacion
            // 
            btnSimulacion.Location = new Point(316, 25);
            btnSimulacion.Name = "btnSimulacion";
            btnSimulacion.Size = new Size(144, 112);
            btnSimulacion.TabIndex = 8;
            btnSimulacion.Text = "Iniciar Simulacion";
            btnSimulacion.UseVisualStyleBackColor = true;
            btnSimulacion.Click += btnSimulacion_Click;
            // 
            // dgvSimulacion
            // 
            dgvSimulacion.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSimulacion.Location = new Point(303, 157);
            dgvSimulacion.Name = "dgvSimulacion";
            dgvSimulacion.RowHeadersWidth = 51;
            dgvSimulacion.Size = new Size(1132, 443);
            dgvSimulacion.TabIndex = 9;
            dgvSimulacion.CellContentClick += dgvSimulacion_CellContentClick;
            // 
            // txtDesdeDia
            // 
            txtDesdeDia.Location = new Point(203, 388);
            txtDesdeDia.Name = "txtDesdeDia";
            txtDesdeDia.Size = new Size(85, 23);
            txtDesdeDia.TabIndex = 10;
            txtDesdeDia.TextChanged += txtDesdeDia_TextChanged;
            // 
            // txtCantidadDiasMostrar
            // 
            txtCantidadDiasMostrar.Location = new Point(203, 417);
            txtCantidadDiasMostrar.Name = "txtCantidadDiasMostrar";
            txtCantidadDiasMostrar.Size = new Size(85, 23);
            txtCantidadDiasMostrar.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(25, 419);
            label6.Name = "label6";
            label6.Size = new Size(62, 15);
            label6.TabIndex = 13;
            label6.Text = "Dias Hasta";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(25, 390);
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
            dgvProb.Columns.AddRange(new DataGridViewColumn[] { Obreros, CantDias });
            dgvProb.Location = new Point(27, 25);
            dgvProb.Margin = new Padding(3, 2, 3, 2);
            dgvProb.Name = "dgvProb";
            dgvProb.RowHeadersWidth = 51;
            dgvProb.Size = new Size(261, 192);
            dgvProb.TabIndex = 15;
            dgvProb.CellContentClick += dgvProb_CellContentClick;
            // 
            // Obreros
            // 
            Obreros.HeaderText = "Numero de obreros";
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
            // CantObreros
            // 
            CantObreros.AutoSize = true;
            CantObreros.Location = new Point(25, 257);
            CantObreros.Name = "CantObreros";
            CantObreros.Size = new Size(114, 15);
            CantObreros.TabIndex = 17;
            CantObreros.Text = "Cantidad de obreros";
            // 
            // txtCantidadObrerosNomina
            // 
            txtCantidadObrerosNomina.Location = new Point(203, 255);
            txtCantidadObrerosNomina.Name = "txtCantidadObrerosNomina";
            txtCantidadObrerosNomina.Size = new Size(85, 23);
            txtCantidadObrerosNomina.TabIndex = 16;
            txtCantidadObrerosNomina.TextChanged += textBox1_TextChanged;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(30, 458);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(258, 49);
            btnLimpiar.TabIndex = 18;
            btnLimpiar.Text = "Limpiar Campos";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1505, 652);
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
            Text = "Form1";
            Load += Form1_Load;
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
        private DataGridViewTextBoxColumn Obreros;
        private DataGridViewTextBoxColumn CantDias;
        private Label CantObreros;
        private TextBox txtCantidadObrerosNomina;
        private Button btnLimpiar;
    }
}
