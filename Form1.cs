using System;
using System.Windows.Forms;
using System.Globalization;
using System.Data;
using System.Numerics;
using System.Security.Cryptography;

namespace tp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeSecondDataGridView();
            // Configurar DataGridView
            dgvSimulacion.ColumnCount = 10;
            dgvSimulacion.Columns[0].Name = "Día";
            dgvSimulacion.Columns[1].Name = "RND Ausentes";
            dgvSimulacion.Columns[2].Name = "Cantidad ausentes";
            dgvSimulacion.Columns[3].Name = "Cantidad obreros";
            dgvSimulacion.Columns[4].Name = "Produccion";
            dgvSimulacion.Columns[5].Name = "Ganancia Ventas";
            dgvSimulacion.Columns[6].Name = "Materia prima";
            dgvSimulacion.Columns[7].Name = "Mano de obra";
            dgvSimulacion.Columns[8].Name = "Ganancia Diaria";
            dgvSimulacion.Columns[9].Name = "Ganancia Acumulada";
        }

        private void Simular(double valorVenta, double costosVariables, double remuneraciones, int diasSimulacion, int desdeDia, int cantidadDiasMostrar, int cantidadObrerosNomina, List<int> valoresProb, int total)
        {

            // Limpiar DataGridView antes de agregar nuevos datos
            dgvSimulacion.Rows.Clear();

            double gananciaTotal = 0;
            // Realizar la simulación para cada día
            for (int dia = 1; dia <= diasSimulacion; dia++)
            {
                // Genera número aleatorio con 4 decimales
                Random rand = new Random();
                double numeroAleatorio = rand.NextDouble();
                numeroAleatorio = Math.Round(numeroAleatorio, 4);

                int totalObreros = cantidadObrerosNomina;

                // Calcular el número de obreros ausentes
                int obrerosAusentes = calcularObrerosAusentes(valoresProb, total, numeroAleatorio);


                // Calcular el número de obreros presentes
                int obrerosPresentes = totalObreros - obrerosAusentes;

                // Determinar si la planta está en funcionamiento
                bool plantaOperativa = true;
                if (obrerosPresentes < 20)
                {
                    plantaOperativa = false;
                }

                // Calcular ingresos y costos
                int ingresosDiarios = plantaOperativa ? (int)valorVenta : 0;
                int materiaPrima = plantaOperativa ? (int)costosVariables : 0;
                int costoManoObra;
                if(plantaOperativa)
                {
                    costoManoObra = (int)(remuneraciones * obrerosPresentes );
                }
                else
                {
                    costoManoObra = (int)(remuneraciones * (obrerosPresentes + obrerosAusentes));
                }
                
                double gananciaDiaria = ingresosDiarios - materiaPrima - costoManoObra;

                // Actualizar la ganancia total
                gananciaTotal += gananciaDiaria;

                // Agregar fila a DataGridView solo si el día es mayor o igual a desdeDia
                if (dia >= desdeDia && dgvSimulacion.Rows.Count <= cantidadDiasMostrar)
                {
                    dgvSimulacion.Rows.Add(dia, numeroAleatorio, obrerosAusentes, obrerosPresentes, plantaOperativa, ingresosDiarios, materiaPrima, costoManoObra, gananciaDiaria, gananciaTotal);
                }


            }

            // Mostrar la ganancia total al final de la simulación
            MessageBox.Show("La ganancia total durante " + diasSimulacion + " días es: $" + gananciaTotal);

            // Limpiar los cuadros de texto
            // LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            // Limpiar los cuadros de texto
            txtValorVenta.Clear();
            txtCostosVariables.Clear();
            txtRemuneraciones.Clear();
            txtDiasSimulacion.Clear();
            txtDesdeDia.Clear();
            txtCantidadDiasMostrar.Clear();
            txtCantidadObrerosNomina.Clear();
        }

        private bool CamposVacios()
        {
            // Verificar si alguno de los campos de texto está vacío
            return string.IsNullOrWhiteSpace(txtValorVenta.Text) ||
                   string.IsNullOrWhiteSpace(txtCostosVariables.Text) ||
                   string.IsNullOrWhiteSpace(txtRemuneraciones.Text) ||
                   string.IsNullOrWhiteSpace(txtDiasSimulacion.Text) ||
                   string.IsNullOrWhiteSpace(txtDesdeDia.Text) ||
                   string.IsNullOrWhiteSpace(txtCantidadDiasMostrar.Text) ||
                   string.IsNullOrWhiteSpace(txtCantidadObrerosNomina.Text);

        }
        private int calcularObrerosAusentes(List<int> valoresProb, int total, double numeroAleatorio)
        {

            double probabilidadAcumulada = 0;
            int obrerosAusentes = 0;
            for (int i = 0; i < valoresProb.Count; i++)
            {
                double probabilidad = Math.Round((double)valoresProb[i] / total, 4);
                probabilidadAcumulada += probabilidad;
                if (numeroAleatorio < probabilidadAcumulada)
                {
                    obrerosAusentes = i;

                    return i;
                }
            }
            return 0;
        }
        private void btnSimulacion_Click(object sender, EventArgs e)
        {
            // Verificar si algún campo está vacío
            if (CamposVacios())
            {
                MessageBox.Show("Por favor, complete todos los campos antes de continuar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Salir del método sin continuar la simulación
            }

            // Convertir los valores de los campos de texto a tipos numéricos
            double valorVenta = double.Parse(txtValorVenta.Text);
            double costosVariables = double.Parse(txtCostosVariables.Text);
            double remuneraciones = double.Parse(txtRemuneraciones.Text);
            int diasSimulacion = int.Parse(txtDiasSimulacion.Text);
            int desdeDia = int.Parse(txtDesdeDia.Text);
            int cantidadDiasMostrar = int.Parse(txtCantidadDiasMostrar.Text);
            int cantidadObrerosNomina = int.Parse(txtCantidadObrerosNomina.Text);

            List<int> valoresProb = new List<int>();
            int total = 0;
            foreach (DataGridViewRow row in dgvProb.Rows)
            {
                if (row.Cells["CantDias"].Value != null && int.TryParse(row.Cells["CantDias"].Value.ToString(), out int valor))
                {
                    valoresProb.Add(valor);
                    total += valor;
                }
                else
                {
                    valoresProb.Add(0);
                }
            }

            // Llamar a la función de simulación con los parámetros ingresados
            Simular(valorVenta, costosVariables, remuneraciones, diasSimulacion, desdeDia, cantidadDiasMostrar, cantidadObrerosNomina, valoresProb, total);
        }


        private void InitializeSecondDataGridView()
        {
            // Agrega cinco filas iniciales
            for (int i = 0; i < 6; i++)
            {
                dgvProb.Rows.Add(i.ToString());
            }

            // Impide que los usuarios agreguen filas
            dgvProb.AllowUserToAddRows = false;
        }

        private void txtRemuneraciones_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDesdeDia_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvSimulacion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dgvProb_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }
    }
}
