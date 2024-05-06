using System;
using System.Windows.Forms;
using System.Globalization;
using System.Data;
using System.Numerics;
using System.Security.Cryptography;
using MathNet.Numerics.Distributions;
using Microsoft.Office.Interop.Excel;


namespace tp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeSecondDataGridView();
            cargarPorDefecto();
            calcularMedia();
            calcularProbabilidadPoisson();
            cargarLimites();
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
                int obrerosAusentes = calcularObrerosFaltantes(numeroAleatorio);


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

        //dgvSimulacion.Columns[1].Name = "RND Ausentes";
        //dgvSimulacion.Columns[2].Name = "Cantidad ausentes";
            
        private int calcularObrerosFaltantes(double numeroAleatorio)
        {
            int ausentes = 0;
            
            int filasInervalos = dgvProb.Rows.Count;
            for(int j = 0; j<filasInervalos; j++)
            {
                double limiteSuperior = double.Parse(dgvProb.Rows[j].Cells["Limite_Superior"].Value.ToString());
                if (numeroAleatorio < limiteSuperior)
                {
                    int cantidad = int.Parse(dgvProb.Rows[j].Cells["Obreros"].Value.ToString());
                    ausentes = cantidad;
                    break;
                }
                    
            }
            return ausentes;
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
                    MessageBox.Show("Complete la tabla de Ausentismo Por Dia antes de realizar la Simulacion","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            //Recalcular las columnas para los nuevos campos
            calcularMedia();
            calcularProbabilidadPoisson();
            cargarLimites();
            // Llamar a la función de simulación con los parámetros ingresados
            Simular(valorVenta, costosVariables, remuneraciones, diasSimulacion, desdeDia, cantidadDiasMostrar, cantidadObrerosNomina, valoresProb, total);
        }


        private void InitializeSecondDataGridView()
        {
            // Agrega cinco filas iniciales + 1 para los valores acumulados y el total
            for (int i = 0; i < 7; i++)
            {   
                if(i < 6)
                {
                    dgvProb.Rows.Add(i.ToString());

                }
                if (i == 6)
                {
                    dgvProb.Rows.Add("Total");
                }
                
               
            }

            // Impide que los usuarios agreguen filas
            dgvProb.AllowUserToAddRows = false;
        }

        //Ponemos por defecto los valores que vienen planteados en el enunciado (en rojo)
        public void cargarPorDefecto()
        {
            int filas = dgvProb.Rows.Count;
            int[] valoresDefecto = [36, 38, 19, 6, 1, 0];
            int acumulador = 0;
            for(int  i = 0; i < filas; i++)
            {
                if(i < 6)
                {
                    dgvProb.Rows[i].Cells["CantDias"].Value = valoresDefecto[i];
                    acumulador += valoresDefecto[i];
                }
                
                if (i == 6)
                {
                    dgvProb.Rows[i].Cells["CantDias"].Value = acumulador;
                }

            }
        }


        

        //Media
        private void calcularMedia()
        {
            int filas = dgvProb.RowCount;
            int acumulador = 0;
            
            for(int i = 0;i < filas;i++)
            {
                if (i < 6)
                {
                    if (dgvProb.Rows[i].Cells["CantDias"].Value != null)
                    {
                        int obreros = int.Parse(dgvProb.Rows[i].Cells["Obreros"].Value.ToString());
                        int dias = int.Parse(dgvProb.Rows[i].Cells["CantDias"].Value.ToString());
                        int producto = obreros * dias;
                        dgvProb.Rows[i].Cells["Media"].Value = producto;
                        acumulador += producto;

                    }
                }
                if(i == 6)
                {
                    int total = int.Parse(dgvProb.Rows[i].Cells["CantDias"].Value.ToString());
                    double media = Math.Round((double)acumulador / total, 2);
                    dgvProb.Rows[i].Cells["Media"].Value = media;
                }
                
            }
            

        }

       
        
        
        //Factorial para la formula de Poisson
        private long Factorial(int n)
        {
            if (n == 0)
                return 1;
            else
                return n * Factorial(n - 1);
        }


       


        //Probabilidad de poisson
        private void calcularProbabilidadPoisson()
        {
            int filas = dgvProb.Rows.Count;
            double acumulador = 0;
            int ultimaFila = 6;
            for(int i = 0; i < filas; i++)
            {
                if (i < 6)
                {
                    //Evento es el ausentismo de cada dia
                    int evento = int.Parse(dgvProb.Rows[i].Cells["Obreros"].Value.ToString());
                    double media = double.Parse(dgvProb.Rows[ultimaFila].Cells["Media"].Value.ToString());
                    
                    double lambda = media ;

                    // Calcular e^(-lambda)
                    double eLambda = Math.Pow(Math.E, -lambda);

                    // Calcular lambda^k
                    double lambdaK = Math.Pow(lambda, evento);

                    // Calcular k!
                    long factorialK = Factorial(evento);

                    double probabilidad = Math.Round((eLambda* lambdaK) / factorialK,4);

                    //Agrego en la tabla de distribucion de probabilidades la p()
                    dgvProb.Rows[i].Cells["Probabilidad"].Value = probabilidad;


                    acumulador += Math.Round(probabilidad,3);

                    

                }
                if(i == 6)
                {
                    if(acumulador >= 0.98)
                    {
                        acumulador = 1.00;
                        dgvProb.Rows[i].Cells["Probabilidad"].Value = acumulador;
                    }
                   
                }
            }

        }

        //Intervalos de probabilidad
        private void cargarLimites()
        {
            int filas = dgvProb.Rows.Count;
            double limiteInferior = 0.000;
            double limiteSuperior;

            for(int i = 0; i < filas; i++)
            {
                if(i == 0)
                {
                    dgvProb.Rows[i].Cells["Limite_Inferior"].Value = limiteInferior;
                    double siguienteProb = double.Parse(dgvProb.Rows[i].Cells["Probabilidad"].Value.ToString());
                    limiteSuperior = Math.Round(limiteInferior + siguienteProb,4);
                    dgvProb.Rows[i].Cells["Limite_Superior"].Value = limiteSuperior;

                }
                else
                {
                    if (i < 6)
                    {
                        limiteInferior = double.Parse(dgvProb.Rows[i - 1].Cells["Limite_Superior"].Value.ToString());
                        dgvProb.Rows[i].Cells["Limite_Inferior"].Value = limiteInferior;
                        double siguienteProb = double.Parse(dgvProb.Rows[i].Cells["Probabilidad"].Value.ToString());
                        limiteSuperior = Math.Round(limiteInferior + siguienteProb,4);
                        dgvProb.Rows[i].Cells["Limite_Superior"].Value = limiteSuperior;


                    }
                }
               

                
                
            }


        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }
    }
}
