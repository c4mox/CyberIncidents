namespace Dominio
{
    public class Ransomware : Incidente
    {
        private bool _huboExfiltracion;
        private bool _datosEncriptados;

        public bool HuboExfiltracion
        {
            get { return _huboExfiltracion; }
            set { _huboExfiltracion = value; }
        }
        public bool DatosEncriptados
        {
            get { return _datosEncriptados; }
            set { _datosEncriptados = value; }
        }

        public Ransomware(DateTime fechaReportado, Activo activoAfectado, string descripcion, Estado estado, int probabilidad, int impacto,
        bool huboExfiltracion, bool datosEncriptados) : base(fechaReportado, activoAfectado, descripcion, estado, probabilidad, impacto)
        {
            this._huboExfiltracion = huboExfiltracion;
            this._datosEncriptados = datosEncriptados;
            this.ValidarIncidente();
        }
        public override int CalcularSeveridad() // Implementacion del metodo abstracto de la clase base Incidente
        {
            int severidad = (Impacto * 12) + (Probabilidad * 8);
            if (_datosEncriptados)
            {
                severidad += 20;
            }
            if (_huboExfiltracion)
            {
                severidad += 25;
            }
            if (ActivoAfectado.TieneBackup)
            {
                severidad -= 15;
            }
            if (severidad > 100)
            {
                severidad = 100;
            }
            return severidad;
        }
        public override string ToString()
        {
            string encriptados;
            if (this._datosEncriptados)
            {
                encriptados = "Sí";
            }
            else
            {
                encriptados = "No";
            }

            string exfiltracion;
            if (this._huboExfiltracion)
            {
                exfiltracion = "Sí";
            }
            else
            {
                exfiltracion = "No";
            }

            return base.ToString() +
                   "\n - Tipo: Ransomware" +
                   "\n - Datos encriptados: " + encriptados +
                   "\n - Exfiltración: " + exfiltracion;
        }
    }
}
