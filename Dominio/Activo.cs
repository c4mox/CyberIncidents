namespace Dominio
{
    public class Activo : IComparable<Activo>
    {
        private static int s_ultimocodPC = 0;
        private static int s_ultimocodServer = 0; // lo agregue para mantener un contador separado para servidores
        private static int s_ultimocodMovil = 0;

        private string _codigo;
        private string _nombre;
        private TipoActivo _tipoActivo;
        private int _criticidad;
        private Cuenta _cuentaResponsable;
        private bool _tieneBackup;

        public string Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        public TipoActivo TipoActivo
        {
            get { return _tipoActivo; }
            set { _tipoActivo = value; }
        }
        public int Criticidad
        {
            get { return _criticidad; }
            set { _criticidad = value; }
        }
        public Cuenta Cuenta
        {
            get { return _cuentaResponsable; }
            set { _cuentaResponsable = value; }
        }
        public bool TieneBackup
        {
            get { return _tieneBackup; }
            set { _tieneBackup = value; }
        }

        public Activo(string nombre, TipoActivo tipoActivo, int criticidad, Cuenta cuentaResponsable, bool tieneBackup)
        {
            this._tipoActivo = tipoActivo;
            this._nombre = nombre;
            this._criticidad = criticidad;
            this._cuentaResponsable = cuentaResponsable;
            this._tieneBackup = tieneBackup;
            this.ValidarActivo();

            switch (tipoActivo) //genero el código automáticamente según el tipo de activo, con un contador separado para cada tipo.
            {
                case TipoActivo.PC:
                    this._codigo = TipoActivo.PC.ToString() + (++s_ultimocodPC).ToString("D4");//el formato D4 hace que el número se muestre con 4 dígitos,
                                                                                               //agregando ceros a la izquierda si es necesario.
                    break;
                case TipoActivo.SERVER:
                    this._codigo = TipoActivo.SERVER.ToString() + (++s_ultimocodServer).ToString("D4");
                    break;
                case TipoActivo.MOVIL:
                    this._codigo = TipoActivo.MOVIL.ToString() + (++s_ultimocodMovil).ToString("D4");
                    break;
            }
        }
        public int CompareTo(Activo otro)
        {
            return Codigo.CompareTo(otro.Codigo);
        }
        public override string ToString()
        {
            string backup;
            if (this._tieneBackup)//para mostrar si o no enves de true o false
            {
                backup = "Sí";
            }
            else
            {
                backup = "No";
            }

            return " - Código: " + this._codigo +
                   " - Nombre: " + this._nombre +
                   " - Tipo: " + this._tipoActivo +
                   " - Criticidad: " + this._criticidad +
                   " - Cuenta responsable: " + this._cuentaResponsable.Codigo +
                   " - Backup: " + backup;
        }
        public override bool Equals(object obj)
        {
            if (obj is Activo otroActivo)
            {
                return this._codigo == otroActivo._codigo;
            }
            return false;
        }
        public void ValidarActivo()//validaciones que note pertinentes
        {
            ValidarNombre();
            ValidarCriticidad();
        }

        public void ValidarNombre()
        {
            if (string.IsNullOrEmpty(this._nombre))
            {
                throw new Exception("El nombre no puede estar vacío");
            }
        }

        public void ValidarCriticidad()
        {
            if (this._criticidad < 1 || this._criticidad > 5)
            {
                throw new Exception("La criticidad debe estar entre 1 y 5");
            }
        }
    }
}
