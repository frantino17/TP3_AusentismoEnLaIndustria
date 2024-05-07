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
            // Realizar la simulación para cada día
            for (int dia = 1; dia <= diasSimulacion; dia+=2)
            {
                int totalObreros = cantidadObrerosNomina;

                if (dia % 2 == 1)
                {
                    //FILA 1 
                    // Genera número aleatorio con 4 decimales

                    double numeroAleatorio1 = rand.NextDouble();
                    numeroAleatorio1 = Math.Round(numeroAleatorio1, 4);

                   

                    // Calcular el número de obreros ausentes
                    //int obrerosAusentes = calcularObrerosAusentes(valoresProb, total,  numeroAleatorio);
                    int obrerosAusentes1 = calcularObrerosFaltantes(numeroAleatorio1);

                    // Calcular el número de obreros presentes
                    int obrerosPresentes1 = totalObreros - obrerosAusentes1;

                    // Determinar si la planta está en funcionamiento
                    bool plantaOperativa1 = true;
                    if (obrerosPresentes1 < 20)
                    {
                        plantaOperativa1 = false;
                    }

                    // Calcular ingresos y costos
                    int ingresosDiarios1 = plantaOperativa1 ? (int)valorVenta : 0;
                    int materiaPrima1 = plantaOperativa1 ? (int)costosVariables : 0;
                    int costoManoObra1;
                    if (plantaOperativa1)
                    {
                        costoManoObra1 = (int)(remuneraciones * obrerosPresentes1);
                    }
                    else
                    {
                        costoManoObra1 = (int)(remuneraciones * (obrerosPresentes1 + obrerosAusentes1));
                    }

                    double gananciaDiaria1 = ingresosDiarios1 - materiaPrima1 - costoManoObra1;

                    // Actualizar la ganancia total
                    gananciaTotal += gananciaDiaria1;

                    // Agregar fila a DataGridView solo si el día es mayor o igual a desdeDia
                    if (dia >= desdeDia && dia <= cantidadDiasMostrar)
                    {
                        dgvSimulacion.Rows.Add(dia, numeroAleatorio1, obrerosAusentes1, obrerosPresentes1, plantaOperativa1, ingresosDiarios1, materiaPrima1, costoManoObra1, gananciaDiaria1, gananciaTotal);
                    }
                    if (dia == diasSimulacion)
                    {
                        dgvSimulacion.Rows.Add(dia, numeroAleatorio1, obrerosAusentes1, obrerosPresentes1, plantaOperativa1, ingresosDiarios1, materiaPrima1, costoManoObra1, gananciaDiaria1, gananciaTotal);
                    }

                    //FILA 2
                   
                    // Genera número aleatorio con 4 decimales

                    double numeroAleatorio2 = rand.NextDouble();
                    numeroAleatorio2 = Math.Round(numeroAleatorio2, 4);



                    // Calcular el número de obreros ausentes
                    //int obrerosAusentes = calcularObrerosAusentes(valoresProb, total,  numeroAleatorio);
                    int obrerosAusentes2 = calcularObrerosFaltantes(numeroAleatorio2);

                    // Calcular el número de obreros presentes
                    int obrerosPresentes2 = totalObreros - obrerosAusentes2;

                    // Determinar si la planta está en funcionamiento
                    bool plantaOperativa2 = true;
                    if (obrerosPresentes2 < 20)
                    {
                        plantaOperativa2 = false;
                    }

                    // Calcular ingresos y costos
                    int ingresosDiarios2 = plantaOperativa2 ? (int)valorVenta : 0;
                    int materiaPrima2 = plantaOperativa2 ? (int)costosVariables : 0;
                    int costoManoObra2;
                    if (plantaOperativa2)
                    {
                        costoManoObra2 = (int)(remuneraciones * obrerosPresentes2);
                    }
                    else
                    {
                        costoManoObra2 = (int)(remuneraciones * (obrerosPresentes2 + obrerosAusentes2));
                    }

                    double gananciaDiaria2 = ingresosDiarios1 - materiaPrima1 - costoManoObra1;

                    // Actualizar la ganancia total
                    gananciaTotal += gananciaDiaria2;

                    // Agregar fila a DataGridView solo si el día es mayor o igual a desdeDia
                    if (dia + 1 >= desdeDia && dia + 1 <= cantidadDiasMostrar)
                    {
                        dgvSimulacion.Rows.Add(dia + 1, numeroAleatorio2, obrerosAusentes2, obrerosPresentes2, plantaOperativa2, ingresosDiarios2, materiaPrima2, costoManoObra2, gananciaDiaria2, gananciaTotal);
                    }
                    if (dia + 1 == diasSimulacion)
                    {
                        dgvSimulacion.Rows.Add(dia + 1, numeroAleatorio2, obrerosAusentes2, obrerosPresentes2, plantaOperativa2, ingresosDiarios2, materiaPrima2, costoManoObra2, gananciaDiaria2, gananciaTotal);
                    }

                }
                else
                {
                    
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
                if(dgvProb.Rows[j].Cells["Probabilidad_Acumulada"].Value != null)
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
            for(int i = 0; i<filas; i++)
            {
                if (i < 6)
                {
                    double probabilidadIndividual = double.Parse(dgvProb.Rows[i].Cells["Probabilidad"].Value.ToString());
                    if(probabilidadIndividual > 0.000)
                    {
                    double prob = Math.Round(((acumulador + probabilidadIndividual)),4);
                    acumulador = prob;
                    dgvProb.Rows[i].Cells["Probabilidad_Acumulada"].Value = acumulador;
                    }
                    //else
                    //{
                        //double prob = ((acumulador + probabilidadIndividual));
                        //acumulador = prob;
                        //dgvProb.Rows[i].Cells["Probabilidad_Acumulada"].Value = acumulador;
                    //}
                    

                }
                if (i == 6)
                {
                    dgvProb.Rows[i].Cells["Probabilidad_Acumulada"].Value = acumulador;
                }
            }


        }

        private void calcularTotalDias()
        {
            int filas = dgvProb.RowCount;
            int acumulador = 0;
            for(int i = 0; i<filas; i++)
            {
                if (i < 6)
                {
                    int fo = int.Parse(dgvProb.Rows[i].Cells["CantDias"].Value.ToString());
                    acumulador += fo;
                }
                
                
            }
            dgvProb.Rows[6].Cells["CantDias"].Value = acumulador;

        }
        
        private void calcularProbabilidad()
        {
            int filas = dgvProb.Rows.Count;
            int total = int.Parse(dgvProb.Rows[6].Cells["CantDias"].Value.ToString());

            for (int i = 0; i < filas; i++)
            {
                if (i < 6)
                {
                    int dias = int.Parse(dgvProb.Rows[i].Cells["CantDias"].Value.ToString());
                    double probabilidad = Math.Round((double)dias / total, 4);
                    dgvProb.Rows[i].Cells["Probabilidad"].Value = probabilidad;

                }

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
            //Cargar valores de serie
            calcularProbabilidad();
            calcularProbabilidadAcumulada();



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


        

        

       
        
        
        

       
        

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }
    }
}
