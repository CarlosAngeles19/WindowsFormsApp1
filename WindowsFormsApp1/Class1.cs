using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroMascotas
{
    // Clase para representar a un dueño
    public class Dueño
    {
        // Propiedades del dueño
        public string Nombre { get; set; }
        public string Dirección { get; set; }
        public string Teléfono { get; set; }

        // Constructor de la clase Dueño
        public Dueño(string nombre, string dirección, string teléfono)
        {
            Nombre = nombre;
            Dirección = dirección;
            Teléfono = teléfono;
        }

        // Sobrescribir el método ToString para mostrar el nombre en controles como ComboBox
        public override string ToString()
        {
            return Nombre;
        }
    }

    // Clase para representar a una mascota
    public class Mascota
    {
        // Propiedades de la mascota
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string Raza { get; set; }
        public Dueño Dueño { get; set; }

        // Constructor de la clase Mascota
        public Mascota(string nombre, int edad, string raza, Dueño dueño)
        {
            Nombre = nombre;
            Edad = edad;
            Raza = raza;
            Dueño = dueño;
        }
    }
}
