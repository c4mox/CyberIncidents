namespace Dominio
{
    public class Cuenta
    {
        private static int s_ultimocod = 0;
        private int _codigo;
        private Persona _titular;
        private bool _mfaHabilitado;
        private DateTime _fechaUltCambioPass;

        public int Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }
        public Persona Titular
        {
            get { return _titular; }
            set { _titular = value; }
        }

        public bool MfaHabilitado
        {
            get { return _mfaHabilitado; }
            set { _mfaHabilitado = value; }
        }
        public DateTime FechaUltCambioPass
        {
            get { return _fechaUltCambioPass; }
            set { _fechaUltCambioPass = value; }
        }
        public Cuenta()
        {
            this.Codigo = Cuenta.s_ultimocod++;
        }

        public Cuenta(Persona titular, bool mfaHabilitado, DateTime fechaUltCambioPass)
        {
            Cuenta.s_ultimocod++;
            this.Codigo = Cuenta.s_ultimocod;
            this._titular = titular;
            this._mfaHabilitado = mfaHabilitado;
            this._fechaUltCambioPass = fechaUltCambioPass;
            this.ValidarCuenta();
        }
        public override bool Equals(object obj)
        {
            if (obj is Cuenta otraCuenta)
            {
                return this._codigo == otraCuenta._codigo;
            }
            return false;
        }
        public void ValidarCuenta()
        {
            ValidarTitular();
            ValidarFechaPassword();
        }

        public void ValidarTitular()
        {
            if (this._titular == null)
            {
                throw new Exception("La cuenta debe tener un titular");
            }
        }

        public void ValidarFechaPassword()
        {
            if (this._fechaUltCambioPass > DateTime.Now)
            {
                throw new Exception("La fecha del último cambio de contraseña no puede ser futura");
            }
        }
    }
}
