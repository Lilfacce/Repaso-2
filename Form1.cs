﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Repaso_2;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace Repaso_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            label7.Visible = false;
            label8.Visible = false;
        }
        List<Clientes> clientes = new List<Clientes>();
        List<Vehiculos> vehiculos = new List<Vehiculos>();
        List<Alquiler> alquileres = new List<Alquiler>();
        List<Reporte> reportes = new List<Reporte>();
        private void Guardar(string fileName, string texto)
        {
            //Abrir el archivo: Write sobreescribe el archivo, Append agrega los datos al final del archivo
            FileStream flujo = new FileStream("Vehiculos.txt", FileMode.Open, FileAccess.Write);
            //Crear un objeto para escribir el archivo
            StreamWriter writer = new StreamWriter(flujo);
            //Usar el objeto para escribir al archivo, WriteLine, escribe linea por linea
            //Write escribe todo en la misma linea. En este ejemplo se hará un dato por cada línea
            foreach (var vehiculo in vehiculos)
            {
                writer.WriteLine(vehiculo.Placa);
                writer.WriteLine(vehiculo.Marca);
                writer.WriteLine(vehiculo.Modelo);
                writer.WriteLine(vehiculo.Color);
                writer.WriteLine(vehiculo.Precio);

            }

            //Cerrar el archivo para que no se quede abierto y entonces se pueda volver a abrir, de lo contario va a haber un error y no podra abrirse de nuevo
            writer.Close();


        }
        private void GuardarVehiculo()
        {
            //Abrir el archivo: Write sobreescribe el archivo, Append agrega los datos al final del archivo
            FileStream flujo = new FileStream("Vehiculos.txt", FileMode.Open, FileAccess.Write);
            //Crear un objeto para escribir el archivo
            StreamWriter writer = new StreamWriter(flujo);
            //Usar el objeto para escribir al archivo, WriteLine, escribe linea por linea
            //Write escribe todo en la misma linea. En este ejemplo se hará un dato por cada línea
            foreach (var vehiculo in vehiculos)
            {
                writer.WriteLine(vehiculo.Placa);
                writer.WriteLine(vehiculo.Marca);
                writer.WriteLine(vehiculo.Modelo);
                writer.WriteLine(vehiculo.Color);
                writer.WriteLine(vehiculo.Precio);

            }

            //Cerrar el archivo para que no se quede abierto y entonces se pueda volver a abrir, de lo contario va a haber un error y no podra abrirse de nuevo
            writer.Close();


        }
        private void GuardarReporte()
        {
            //Abrir el archivo: Write sobreescribe el archivo, Append agrega los datos al final del archivo
            FileStream flujo = new FileStream("Reporte.txt", FileMode.Open, FileAccess.Write);
            //Crear un objeto para escribir el archivo
            StreamWriter writer = new StreamWriter(flujo);
            //Usar el objeto para escribir al archivo, WriteLine, escribe linea por linea
            //Write escribe todo en la misma linea. En este ejemplo se hará un dato por cada línea
            foreach (var reporte in reportes)
            {
                writer.WriteLine(reporte.Nombre);
                writer.WriteLine(reporte.Marca);
                writer.WriteLine(reporte.Modelo);
                writer.WriteLine(reporte.FechaDevo);
                writer.WriteLine(reporte.Total);

            }

            //Cerrar el archivo para que no se quede abierto y entonces se pueda volver a abrir, de lo contario va a haber un error y no podra abrirse de nuevo
            writer.Close();


        }

        //private void button2_Click(object sender, EventArgs e)
        //{
        //Guardar(@"C:\Users\MSI\source\repos\LabVehiculos\LabVehiculos\bin\Debug\Vehiculos.txt", textBox1.Text);
        //Muestra un mensaje despues 
        //MessageBox.Show("Archivo Guardado con Exito!!!");
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            MostrarAlquileres();
            MostrarClientes();

        }
        public void CargarClientes()
        {
            // Cargar o leer los Datos de los Empleados


            //Leer el Archivo y Cargarlo a la Lista
            string fileName = "Clientes.txt";

            //Abrimos el archivo, en este caso lo abrimos para lectura
            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            //Un ciclo para leer el archivo hasta el final del archivo
            //Lo leído se va guardando en un control richTextBox
            while (reader.Peek() > -1)
            //Esta linea envía el texto leído a un control richTextBox, se puede cambiar para que
            //lo muestre en otro control por ejemplo un combobox
            {

                Clientes cliente = new Clientes();
                cliente.Nit = Convert.ToInt32(reader.ReadLine());
                cliente.Nombre = (reader.ReadLine());
                cliente.Direccion = (reader.ReadLine());


                //Guardar el empleado en la lista de Empleados
                clientes.Add(cliente);
            }
            //Cerrar el archivo, esta linea es importante porque sino despues de correr varias veces el programa daría error de que el archivo quedó abierto muchas veces. Entonces es necesario cerrarlo despues de terminar de leerlo.
            reader.Close();
        }
        private void cargar_alquileres()
        {
            string fileName = "Alquileres.txt";
            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            while (reader.Peek() > -1)
            {
                Alquiler alquiler = new Alquiler();
                alquiler.Nit = int.Parse(reader.ReadLine());
                alquiler.Placa = reader.ReadLine();
                alquiler.FechaIg = Convert.ToDateTime(reader.ReadLine());
                alquiler.FechaDev = Convert.ToDateTime(reader.ReadLine());
                alquiler.Km = int.Parse(reader.ReadLine());
                alquileres.Add(alquiler);
            }
            reader.Close();
        }

        public void MostrarClientes()
        {
            //Mostrar la lista de empleados en el GridView
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = clientes;
            dataGridView1.Refresh();
        }
        public void MostrarVehiculos()
        {
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = vehiculos;
            dataGridView2.Refresh();
        }
        public void MostrarAlquileres()
        {
            dataGridView4.DataSource = null;
            dataGridView4.DataSource = alquileres;
            dataGridView4.Refresh();
        }
        public void MostrarReporte()
        {
            dataGridView3.DataSource = null;
            dataGridView3.DataSource = reportes;
            dataGridView3.Refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            reportes.Clear();
            //Ya deben estar llenas todas las listas
            //Recorre cada alquiler
            foreach (var alquiler in alquileres)
            {
                //obtiene los datos del cliente que alquilo el vehiculo
                Clientes cliente = clientes.Find(c => c.Nit == alquiler.Nit);

                //obtener los datos del automovil que fue alquilado
                Vehiculos vehiculo = vehiculos.Find(v => v.Placa == alquiler.Placa);


                //Meter todos los datos obtenidos a la lista reporte
                Reporte reporte = new Reporte();
                reporte.Nombre = cliente.Nombre;
                reporte.Marca = vehiculo.Marca;
                reporte.Modelo = vehiculo.Modelo;
                reporte.FechaDevo = alquiler.FechaDev;
                reporte.Total = vehiculo.Precio * alquiler.Km;

                reportes.Add(reporte);
            }



            MostrarReporte();

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Vehiculos vehiculo = new Vehiculos();
            vehiculo.Placa = textBox1.Text;
            vehiculo.Marca = textBox2.Text;
            vehiculo.Modelo = textBox3.Text;
            vehiculo.Color = textBox4.Text;
            vehiculo.Precio = Convert.ToDecimal(textBox5.Text);

            vehiculos.Add(vehiculo);
            GuardarVehiculo();
            MostrarVehiculos();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            int kmMayor = alquileres.Max(a => a.Km);
            label2.Text = "Vehiculo con Mayor Kilometraje:";
            label3.Text = kmMayor.ToString();
            label4.Visible = true;
            label5.Visible = true;
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            CargarClientes();
            cargar_alquileres();
        }
    }
}