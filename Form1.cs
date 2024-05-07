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
            cargarPorDefecto();
            calcularTotalDias();
            calcularProbabilidad();
            calcularProbabilidadAcumulada();


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
            Random rand = new Random();

            // Limpiar DataGridView antes de agregar nuevos datos
            dgvSimulacion.Rows.Clear();

            double gananciaTotal = 0;
            // Realizar la simulaci�n para cada d�a
            for (int dia = 1; dia <= diasSimulacion; dia += 2)
            {
                int totalObreros = cantidadObrerosNomina;

                for (int i = 0; i < 2; i++)
                {
                    //FILA i 
                    // Genera n�mero aleatorio con 4 decimales
                    double[] numeroAleatorio = new double[2];
                    int[] obrerosAusentes = new int[2];
                    int[] obrerosPresentes = new int[2];
                    bool plantaOperativa = true;
                    int[] ingresosDiarios = new int[2];
                    int[] materiaPrima = new int[2];
                    int[] costoManoObra = new int[2];
                    double[] gananciaDiaria = new double[2];

                    numeroAleatorio[i] = rand.NextDouble();
                    numeroAleatorio[i] = Math.Round(numeroAleatorio[i], 4);



                    // Calcular el n�mero de obreros ausentes
                    //int obrerosAusentes = calcularObrerosAusentes(valoresProb, total,  numeroAleatorio);
                    obrerosAusentes[i] = calcularObrerosFaltantes(numeroAleatorio[i]);

                    // Calcular el n�mero de obreros presentes
                    obrerosPresentes[i] = totalObreros - obrerosAusentes[i];

                    // Determinar si la planta est� en funcionamiento
                    if (obrerosPresentes[i] < 20)
                    {
                        plantaOperativa = false;
                    }

                    // Calcular ingresos y costos
                    ingresosDiarios[i] = plantaOperativa ? (int)valorVenta : 0;
                    materiaPrima[i] = plantaOperativa ? (int)costosVariables : 0;
                    if (plantaOperativa)
                    {
                        costoManoObra[i] = (int)(remuneraciones * obrerosPresentes[i]);
                    }
                    else
                    {
                        costoManoObra[i] = (int)(remuneraciones * totalObreros);
                    }

                    gananciaDiaria[i] = ingresosDiarios[i] - materiaPrima[i] - costoManoObra[i];

                    // Actualizar la ganancia total
                    gananciaTotal += gananciaDiaria[i];

                    // Agregar fila a DataGridView solo si el d�a es mayor o igual a desdeDia
                    if (((dia + i) >= desdeDia && (dia + i) <= cantidadDiasMostrar) || (dia + i) == diasSimulacion)
                    {
                        dgvSimulacion.Rows.Add(dia + i, numeroAleatorio[i], obrerosAusentes[i], obrerosPresentes[i], plantaOperativa, ingresosDiarios[i], materiaPrima[i], costoManoObra[i], gananciaDiaria[i], gananciaTotal);
                    }
                }


            }

            // Mostrar la ganancia total al final de la simulaci�n
            MessageBox.Show("La ganancia total durante " + diasSimulacion + " dias es: $" + gananciaTotal);

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
            // Verificar si alguno de los campos de texto est� vac�o
            return string.IsNullOrWhiteSpace(txtValorVenta.Text) ||
                   string.IsNullOrWhiteSpace(txtCostosVariables.Text) ||
                   string.IsNullOrWhiteSpace(txtRemuneraciones.Text) ||
                   string.IsNullOrWhiteSpace(txtDiasSimulacion.Text) ||
                   string.IsNullOrWhiteSpace(txtDesdeDia.Text) ||
                   string.IsNullOrWhiteSpace(txtCantidadDiasMostrar.Text) ||
                   string.IsNullOrWhiteSpace(txtCantidadObrerosNomina.Text);

        }

        //dgvSimulacion.Columns[1].Name = "RND Ausentes";
        //dgvSimulacion.Columns[2].Name = "Cantidad ausentes";

        private int calcularObrerosFaltantes(double numeroAleatorio)
        {
            int ausentes = 0;

            int filasInervalos = dgvProb.Rows.Count;
            for (int j = 0; j < filasInervalos; j++)
            {
                if (dgvProb.Rows[j].Cells["Probabilidad_Acumulada"].Value != null)
                {
                    double probAcumulada = double.Parse(dgvProb.Rows[j].Cells["Probabilidad_Acumulada"].Value.ToString());
                    if (numeroAleatorio < probAcumulada)
                    {
                        int cantidad = int.Parse(dgvProb.Rows[j].Cells["Obreros"].Value.ToString());
                        ausentes = cantidad;
                        break;
                    }
                }
                else
                {
                    ausentes = 0;
                    break;
                }
            }
            return ausentes;
        }

        private void calcularProbabilidadAcumulada()
        {
            int filas = dgvProb.RowCount;
            //double precision = 0.001;
            double acumulador = 0.000;
            for (int i = 0; i < (filas - 1); i++)
            {
                double probabilidadIndividual = double.Parse(dgvProb.Rows[i].Cells["Probabilidad"].Value.ToString());
                    double prob = Math.Round(((acumulador + probabilidadIndividual)), 4);
                    acumulador = prob;
                    dgvProb.Rows[i].Cells["Probabilidad_Acumulada"].Value = acumulador;
                //else
                //{
                //double prob = ((acumulador + probabilidadIndividual));
                //acumulador = prob;
                //dgvProb.Rows[i].Cells["Probabilidad_Acumulada"].Value = acumulador;
                //}

            }
            dgvProb.Rows[filas - 1].Cells["Probabilidad_Acumulada"].Value = Math.Round(acumulador,1);


        }

        private void calcularTotalDias()
        {
            int filas = dgvProb.RowCount;
            int acumulador = 0;
            for (int i = 0; i < filas - 1; i++)
            {
                int fo = int.Parse(dgvProb.Rows[i].Cells["CantDias"].Value.ToString());
                acumulador += fo;

            }
            dgvProb.Rows[filas-1].Cells["CantDias"].Value = acumulador;

        }

        private void calcularProbabilidad()
        {
            int filas = dgvProb.Rows.Count;
            int total = int.Parse(dgvProb.Rows[filas-1].Cells["CantDias"].Value.ToString());

            for (int i = 0; i < filas - 1; i++)
            {
                int dias = int.Parse(dgvProb.Rows[i].Cells["CantDias"].Value.ToString());
                double probabilidad = Math.Round((double)dias / total, 4);
                dgvProb.Rows[i].Cells["Probabilidad"].Value = probabilidad;


            }


        }


        //esta funcion usaba las probabilidades con valores no muy precisos, hice una que los extrae directamente de la tabla
        //es mas confiable extraer los valores directos que calcular las p(), ademas de que en la tabla estan calculados con poisson
        private int calcularObrerosAusentes(List<int> valoresProb, int total, double numeroAleatorio)
        {

            double probabilidadAcumulada = 0;
            int obrerosAusentes = 0;
            for (int i = 0; i < valoresProb.Count; i++)
            {
                double probabilidad = Math.Round((double)valoresProb[i] / total, 5);
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
            // Verificar si alg�n campo est� vac�o
            if (CamposVacios())
            {
                MessageBox.Show("Por favor, complete todos los campos antes de continuar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Salir del m�todo sin continuar la simulaci�n
            }

            // Convertir los valores de los campos de texto a tipos num�ricos
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
                    MessageBox.Show("Complete la tabla de Ausentismo Por Dia antes de realizar la Simulacion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            //Cargar valores de serie
            calcularProbabilidad();
            calcularProbabilidadAcumulada();



            // Llamar a la funci�n de simulaci�n con los par�metros ingresados
            Simular(valorVenta, costosVariables, remuneraciones, diasSimulacion, desdeDia, cantidadDiasMostrar, cantidadObrerosNomina, valoresProb, total);
        }


        private void InitializeSecondDataGridView()
        {
            int filas = 6;
            // Agrega cinco filas iniciales + 1 para los valores acumulados y el total
            for (int i = 0; i < filas; i++)
            {
                dgvProb.Rows.Add(i.ToString());
                dgvProb.Rows[i].ReadOnly = true;
            }
            dgvProb.Rows.Add("Total");
            dgvProb.Rows[filas].ReadOnly = true;
            // Impide que los usuarios agreguen filas
            dgvProb.AllowUserToAddRows = false;
        }

        //Ponemos por defecto los valores que vienen planteados en el enunciado (en rojo)
        public void cargarPorDefecto()
        {
            int filas = dgvProb.Rows.Count;
            int[] valoresDefecto = [36, 38, 19, 6, 1, 0];
            for (int i = 0; i < (filas - 1); i++)
            {
                dgvProb.Rows[i].Cells["CantDias"].Value = valoresDefecto[i];

            }
        }

        //Funcion para la accion ante la carga de nuevos valores en las cantidad de dias de muestra
        private void dgvProb_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string nuevo = Microsoft.VisualBasic.Interaction.InputBox("Ingrese la cantidad de Dias para el ausentismo", "Dias: ");

            //Valida que lo ingresado sea un numero y no se modifique la fila del total
            if (int.TryParse(nuevo, out _) && e.RowIndex != dgvProb.Rows.Count)
            {
                dgvProb.Rows[e.RowIndex].Cells[1].Value = nuevo;
                //Calcula las probabilidades y los totales nuevamente
                calcularTotalDias();
                calcularProbabilidad();
                calcularProbabilidadAcumulada();
            }
        }


        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }
    }
}
