using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace AccesoDatos
{
    public class PacienteDatos
    {
        public int AgregarPaciente (Paciente paciente)
        {
            ConexionDB datos = new ConexionDB();

            try
            {
                datos.setearConsulta(@"
                    SET XACT_ABORT ON;
                    BEGIN TRAN;

                        INSERT INTO USUARIO (nombre_usuario, password_hash, email, rol)
                        VALUES (@email, @passwordHash, @email, 'Paciente');

                        DECLARE @idUsuario INT = SCOPE_IDENTITY();

                        INSERT INTO PERSONA (id_usuario, dni, nombre, apellido, telefono)
                        VALUES (@idUsuario, @dni, @nombre, @apellido, @telefono);

                        DECLARE @idPersona INT = SCOPE_IDENTITY();

                        INSERT INTO PACIENTE (id_paciente, fecha_nacimiento, sexo, calle, altura, localidad,
                                              id_obra_social, nro_afiliado, id_titular, parentesco)
                        VALUES (@idPersona, @fechaNacimiento, @sexo, @calle, @altura, @localidad,
                                @idObraSocial, @nroAfiliado, @idTitular, @parentesco);

                    COMMIT;

                    SELECT @idPersona;");

                // USUARIO
                datos.setearParametro("@email", paciente.Usuario!.Email);
                datos.setearParametro("@passwordHash", paciente.Usuario.PasswordHash);

                // PERSONA
                datos.setearParametro("@dni", paciente.Dni);
                datos.setearParametro("@nombre", paciente.Nombre);
                datos.setearParametro("@apellido", paciente.Apellido);
                datos.setearParametro("@telefono", paciente.Telefono);

                // PACIENTE
                datos.setearParametro("@fechaNacimiento", paciente.FechaNacimiento);
                datos.setearParametro("@sexo", paciente.Sexo);
                datos.setearParametro("@calle", paciente.Calle);
                datos.setearParametro("@altura", paciente.Altura);
                datos.setearParametro("@localidad", paciente.Localidad);
                datos.setearParametro("@idObraSocial", paciente.IdObraSocial);
                datos.setearParametro("@nroAfiliado", paciente.NroAfiliado);
                datos.setearParametro("@idTitular", paciente.IdTitular);
                datos.setearParametro("@parentesco", paciente.Parentesco);

                return datos.obtenerId();
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public bool ExisteDni(string dni)
        {
            ConexionDB datos = new ConexionDB();

            try
            {
                datos.setearConsulta("SELECT COUNT(*) FROM PERSONA WHERE dni = @dni");
                datos.setearParametro("@dni", dni);

                return datos.obtenerId() > 0;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }



    }
}
