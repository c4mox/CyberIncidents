namespace Dominio
{
    public abstract class Incidente : IComparable<Incidente>
    {
        private static int s_ultimoid = 0;
        private int _id;
        private DateTime _fechaReportado;
        private Activo _activoAfectado;
        private string _descripcion;
        private Estado _estado;
        private int _probabilidad;
        private int _impacto;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public DateTime FechaReportado
        {
            get { return _fechaReportado; }
            set { _fechaReportado = value; }
        }

        public Activo ActivoAfectado
        {
            get { return _activoAfectado; }
            set { _activoAfectado = value; }
        }
        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }
        public Estado Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }
        public int Probabilidad
        {
            get { return _probabilidad; }
            set { _probabilidad = value; }
        }
        public int Impacto
        {
            get { return _impacto; }
            set { _impacto = value; }
        }
        public Incidente()
        {
            this.Id = Incidente.s_ultimoid++;
        }

        public Incidente(DateTime fechaReportado, Activo activoAfectado, string descripcion, Estado estado, int probabilidad, int impacto)
        {
            Incidente.s_ultimoid++;
            this.Id = Incidente.s_ultimoid;
            this._fechaReportado = fechaReportado;
            this._activoAfectado = activoAfectado;
            this._descripcion = descripcion;
            this._estado = estado;
            this._probabilidad = probabilidad;
            this._impacto = impacto;
            this.ValidarIncidente();
        }
        public void ValidarIncidente()
        {
            ValidarFechaReportado();
            ValidarActivoAfectado();
            ValidarImpacto();
            ValidarProbabilidad();
        }
        public override bool Equals(object obj)
        {
            if (obj is Incidente otroIncidente)
            {
                return this._id == otroIncidente._id;
            }
            return false;
        }
        public override string ToString()//hice tambien el ToString de Incidente para que las clases hijas
                                         //puedan usarlo y no repetir código, y así mostrar la información común a todos los incidentes
        {
            return "\n - ID: " + this._id +
                   "\n - Fecha: " + this._fechaReportado.ToString("dd/MM/yyyy") +
                   "\n - Activo: " + this._activoAfectado.Codigo +
                   "\n - Estado: " + this._estado +
                   "\n - Impacto: " + this._impacto +
                   "\n - Probabilidad: " + this._probabilidad +
                   "\n - Descripción: " + this._descripcion;
        }
        public abstract int CalcularSeveridad(); // Metodo abstracto que será implementado por las clases hijas mediante polimorfismo,
                                                 // para calcular la severidad del incidente según su tipo

        public int CompareTo(Incidente otro)
        {
            return otro.CalcularSeveridad().CompareTo(this.CalcularSeveridad());
        }

        public void ValidarFechaReportado()
        {
            if (this._fechaReportado > DateTime.Now)
            {
                throw new Exception("La fecha reportada no puede ser futura");
            }
        }

        public void ValidarActivoAfectado()
        {
            if (this._activoAfectado == null)
            {
                throw new Exception("Debe existir un activo afectado");
            }
        }

        public void ValidarImpacto()
        {
            if (this._impacto < 1 || this._impacto > 5)
            {
                throw new Exception("El impacto debe estar entre 1 y 5");
            }
        }

        public void ValidarProbabilidad()
        {
            if (this._probabilidad < 1 || this._probabilidad > 5)
            {
                throw new Exception("La probabilidad debe estar entre 1 y 5");
            }
        }
    }
}
