namespace Dominio
{
    public class Persona
    {
        private string _cedula;
        private string _nombre;
        private string _email;
        private string _telefono;
        private string _contrasenia;
        private Rol _rol;

        public string Cedula
        {
            get { return _cedula; }
            set { _cedula = value; }
        }
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public string Telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }
        public string Contrasenia
        {
            get { return _contrasenia; }
            set { _contrasenia = value; }
        }
        public Rol Rol
        {
            get { return _rol; }
            set { _rol = value; }
        }

        public Persona(string cedula, string nombre, string email, string telefono, string contrasenia, Rol rol)
        {
            this._cedula = cedula;
            this._nombre = nombre;
            this._email = email;
            this._telefono = telefono;
            this._contrasenia = contrasenia;
            this._rol = rol;
            this.ValidarPersona();
        }
        public override bool Equals(object obj)
        {
            if (obj is Persona otraPersona)
            {
                return this._cedula == otraPersona._cedula;
            }
            return false;
        }
        public override string ToString()
        {
            return " - Cédula: " + this._cedula +
                   " - Nombre: " + this._nombre +
                   " - Email: " + this._email +
                   " - Teléfono: " + this._telefono +
                   " - Rol: " + this._rol + "\n";
        }
        public void ValidarPersona()//validaciones que fui mas estricto ya que era el alta de persona,
                                    //y me parecio que era importante validar cada campo bien
        {
            ValidarCedula();
            ValidarNombre();
            ValidarEmail();
            ValidarTelefono();
            ValidarContrasenia();
        }
        public void ValidarContrasenia()
        {
            if (string.IsNullOrEmpty(this._contrasenia))
            {
                throw new Exception("La contraseña no puede estar vacía");
            }
        }

        public void ValidarCedula()
        {
            if (string.IsNullOrEmpty(this._cedula))
            {
                throw new Exception("La cédula no puede estar vacía");
            }

            if (this._cedula.Length != 8)
            {
                throw new Exception("La cédula debe tener 8 dígitos.");
            }

            foreach (char c in this._cedula)
            {
                if (!char.IsDigit(c))
                {
                    throw new Exception("La cédula debe contener solo números.");
                }
            }
        }

        public void ValidarNombre()
        {
            if (string.IsNullOrEmpty(this._nombre))
            {
                throw new Exception("El nombre no puede estar vacío");
            }

            foreach (char c in this._nombre)
            {
                if (!char.IsLetter(c) && c != ' ')
                {
                    throw new Exception("El nombre debe contener solo letras.");
                }
            }
        }

        public void ValidarEmail()
        {
            if (string.IsNullOrEmpty(this._email))
            {
                throw new Exception("El email no puede estar vacío");
            }

            if (!this._email.Contains("@"))
            {
                throw new Exception("El email debe contener @");
            }
        }

        public void ValidarTelefono()
        {
            if (string.IsNullOrEmpty(this._telefono))
            {
                throw new Exception("El teléfono no puede estar vacío");
            }

            if (this._telefono.Length != 9)
            {
                throw new Exception("El teléfono debe tener 9 dígitos.");
            }

            if (!this._telefono.StartsWith("09"))
            {
                throw new Exception("El teléfono debe empezar con 09.");
            }

            foreach (char c in this._telefono)
            {
                if (!char.IsDigit(c))
                {
                    throw new Exception("El teléfono debe contener solo números.");
                }
            }
        }
    }
}
