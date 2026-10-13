using Dominio;
using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class PacienteNegocio
    {

        private readonly PacienteDatos pacienteDatos = new PacienteDatos();
        private readonly UsuarioDatos usuarioDatos = new UsuarioDatos();

        public int Agregar(Paciente paciente, string password)
        {
           
            if (paciente.Usuario == null || string.IsNullOrWhiteSpace(paciente.Usuario.Email))
                throw new Exception("El correo electrónico es obligatorio.");

           
            if (string.IsNullOrWhiteSpace(password) || password.Length < 8)
                throw new Exception("La contraseña debe tener al menos 8 caracteres.");

            
            if (pacienteDatos.ExisteDni(paciente.Dni))
                throw new Exception("Ya existe un paciente registrado con ese DNI.");

            
            paciente.Usuario.Email = paciente.Usuario.Email.Trim().ToLower();
            if (usuarioDatos.ExisteEmail(paciente.Usuario.Email))
                throw new Exception("Ese correo ya está registrado.");

            paciente.Usuario.PasswordHash = BCrypt.Net.BCrypt.HashPassword(password);

            return pacienteDatos.AgregarPaciente(paciente);
        }




    }
}
