namespace Dominio
{
    public class Phishing : Incidente
    {
        private bool _entregoCredenciales;
        private bool _huboTransferencia;
        private Canal _canalUsado;


        public bool EntregoCredenciales
        {
            get { return _entregoCredenciales; }
            set { _entregoCredenciales = value; }
        }
        public bool HuboTransferencia
        {
            get { return _huboTransferencia; }
            set { _huboTransferencia = value; }
        }
        public Canal CanalUsado
        {
            get { return _canalUsado; }
            set { _canalUsado = value; }
        }

        public Phishing(DateTime fechaReportado, Activo activoAfectado, string descripcion, Estado estado, int probabilidad, int impacto,
        bool entregoCredenciales, bool huboTransferencia, Canal canalUsado) : base(fechaReportado, activoAfectado, descripcion, estado, probabilidad, impacto)
        {
            this._entregoCredenciales = entregoCredenciales;
            this._huboTransferencia = huboTransferencia;
            this._canalUsado = canalUsado;
            this.ValidarIncidente();
        }
        public override int CalcularSeveridad() // Implementacion del metodo abstracto de la clase base Incidente
        {
            int severidad = (Impacto * 12) + (Probabilidad * 8);

            if (severidad > 100)
            {
                severidad = 100;
            }
            return severidad;
        }
        public override string ToString()
        {
            string credenciales;
            if (this._entregoCredenciales)
            {
                credenciales = "Sí";
            }
            else
            {
                credenciales = "No";
            }

            string transferencia;
            if (this._huboTransferencia)
            {
                transferencia = "Sí";
            }
            else
            {
                transferencia = "No";
            }

            return base.ToString() + //el base.ToString() llama al ToString de la clase padre, en este caso Incidente,
                                     //para mostrar la información común a todos los incidentes, y luego añade la información específica de Phishing.
                   "\n - Tipo: Phishing" +
                   "\n - Canal: " + this._canalUsado +
                   "\n - Entregó credenciales: " + credenciales +
                   "\n - Transferencia de datos: " + transferencia;
        }
    }
}
