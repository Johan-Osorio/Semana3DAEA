using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace Semana3
{
    /// <summary>
    /// Lógica de interacción para Estudiantes.xaml
    /// </summary>
    public partial class Estudiantes : Window
    {
        private DataTable dataTable;
        private string StudentId;
        private string FirstName;
        private string LastName;

        public Estudiantes()
        {
            InitializeComponent();
            dataTable = new DataTable();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = "Data Source=LAB1504-29\\SQLEXPRESS; Initial Catalog=Sentinels; User Id=Johan; Password=123456";

            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM Students", connection);

                SqlDataAdapter adapter = new SqlDataAdapter(command);

                adapter.Fill(dataTable);

                connection.Close();

                dgvDemo.ItemsSource = dataTable.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            string connectionString = "Data Source=LAB1504-29\\SQLEXPRESS; Initial Catalog=Sentinels; User Id=Johan; Password=123456";
            List<Estudiantes> estudiantes = new List<Estudiantes>();
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM Students", connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    StudentId = reader.GetString(reader.GetOrdinal("StudentId"));
                    FirstName = reader.GetString(reader.GetOrdinal("FirstName"));
                    LastName = reader.GetString(reader.GetOrdinal("LastName"));

                    estudiantes.Add(new Estudiantes { StudentId = this.StudentId, FirstName = this.FirstName, LastName = this.LastName });
                }

                connection.Close();
                dgvDemo.ItemsSource = estudiantes;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

    }
}
