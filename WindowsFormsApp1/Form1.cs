using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace RegistroMascotas
{
    public partial class Form1 : Form
    {
        // Lista para almacenar los dueños
        private List<Dueño> dueños = new List<Dueño>();

        // Lista para almacenar las mascotas
        private List<Mascota> mascotas = new List<Mascota>();

        // Constructor del formulario
        public Form1()
        {
            InitializeComponent();
        }

        // Evento que se ejecuta cuando se hace clic en el botón para registrar un dueño
        private void btnRegistrarDueño_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar campos vacíos
                if (string.IsNullOrWhiteSpace(txtNombreDueño.Text) ||
                    string.IsNullOrWhiteSpace(txtDirecciónDueño.Text) ||
                    string.IsNullOrWhiteSpace(txtTeléfonoDueño.Text))
                {
                    MessageBox.Show("Por favor, complete todos los campos del dueño.");
                    return;
                }

                // Obtener datos de los TextBox
                string nombre = txtNombreDueño.Text;
                string direccion = txtDirecciónDueño.Text;
                string telefono = txtTeléfonoDueño.Text;

                // Crear una nueva instancia de Dueño
                Dueño nuevoDueño = new Dueño(nombre, direccion, telefono);

                // Agregar el nuevo dueño a la lista y al ComboBox
                dueños.Add(nuevoDueño);
                comboDueños.Items.Add(nuevoDueño);

                // Mostrar mensaje de éxito y limpiar los TextBox
                MessageBox.Show("Dueño registrado con éxito");
                txtNombreDueño.Clear();
                txtDirecciónDueño.Clear();
                txtTeléfonoDueño.Clear();
            }
            catch (Exception ex)
            {
                // Manejar cualquier error que ocurra durante el registro
                MessageBox.Show("Error al registrar dueño: " + ex.Message);
            }
        }

        // Evento que se ejecuta cuando se hace clic en el botón para registrar una mascota
        private void btnRegistrarMascota_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar campos vacíos
                if (string.IsNullOrWhiteSpace(txtNombreMascota.Text) ||
                    string.IsNullOrWhiteSpace(txtEdadMascota.Text) ||
                    string.IsNullOrWhiteSpace(txtRazaMascota.Text) ||
                    comboDueños.SelectedItem == null)
                {
                    MessageBox.Show("Por favor, complete todos los campos de la mascota.");
                    return;
                }

                // Obtener datos de los TextBox y ComboBox
                string nombre = txtNombreMascota.Text;
                if (!int.TryParse(txtEdadMascota.Text, out int edad))
                {
                    MessageBox.Show("Por favor, ingrese una edad válida.");
                    return;
                }
                string raza = txtRazaMascota.Text;
                Dueño dueño = (Dueño)comboDueños.SelectedItem;

                // Crear una nueva instancia de Mascota
                Mascota nuevaMascota = new Mascota(nombre, edad, raza, dueño);

                // Agregar la nueva mascota a la lista
                mascotas.Add(nuevaMascota);

                // Mostrar mensaje de éxito y limpiar los controles
                MessageBox.Show("Mascota registrada con éxito");
                txtNombreMascota.Clear();
                txtEdadMascota.Clear();
                txtRazaMascota.Clear();
                comboDueños.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                // Manejar cualquier error que ocurra durante el registro
                MessageBox.Show("Error al registrar mascota: " + ex.Message);
            }
        }

        // Evento que se ejecuta cuando se hace clic en el botón para buscar una mascota
        private void btnBuscarMascota_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar campo de búsqueda vacío
                if (string.IsNullOrWhiteSpace(txtBuscarMascota.Text))
                {
                    MessageBox.Show("Por favor, ingrese el nombre de la mascota a buscar.");
                    return;
                }

                // Obtener el nombre de la mascota a buscar
                string nombre = txtBuscarMascota.Text;

                // Llamar al método para buscar la mascota
                Mascota encontrada = BuscarMascota(nombre);

                // Mostrar el resultado de la búsqueda
                if (encontrada != null)
                {
                    MessageBox.Show($"Mascota encontrada: {encontrada.Nombre}, Edad: {encontrada.Edad}, Raza: {encontrada.Raza}, Dueño: {encontrada.Dueño.Nombre}");
                }
                else
                {
                    MessageBox.Show("Mascota no encontrada");
                }
            }
            catch (Exception ex)
            {
                // Manejar cualquier error que ocurra durante la búsqueda
                MessageBox.Show("Error al buscar mascota: " + ex.Message);
            }
        }

        // Método para buscar una mascota por nombre
        private Mascota BuscarMascota(string nombre)
        {
            return mascotas.FirstOrDefault(m => m.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
        }
    }
}
