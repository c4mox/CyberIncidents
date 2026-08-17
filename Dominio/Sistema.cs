namespace Dominio
{
    public class Sistema
    {
        private static Sistema _instancia;
        private List<Persona> _personas = new List<Persona>();
        private List<Cuenta> _cuentas = new List<Cuenta>();
        private List<Activo> _activos = new List<Activo>();
        private List<Incidente> _incidentes = new List<Incidente>();

        public List<Persona> Personas { get { return _personas; } }
        public List<Cuenta> Cuentas { get { return _cuentas; } }
        public List<Activo> Activos { get { return _activos; } }
        public List<Incidente> Incidentes { get { return _incidentes; } }

        public static Sistema Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new Sistema();
                }
                return _instancia;
            }
        }

        private Sistema()
        {
            this.PrecargarDatos();
        }
        public void AgregarPersona(Persona persona)
        {
            try
            {
                if (this.Personas.Contains(persona)) // Esto asume que el método Equals de Persona está correctamente implementado
                                                     // para comparar por cédula u otro identificador único. Lo mismo en las demas clases.
                {
                    throw new Exception("Ya existe esa persona");
                }
                this.Personas.Add(persona);
            }
            catch
{
    throw;
}
        }
        public void AgregarCuenta(Cuenta cuenta)
        {
            try
            {
                if (this.Cuentas.Contains(cuenta))
                {
                    throw new Exception("Ya existe una cuenta con esos datos ");
                }
                this.Cuentas.Add(cuenta);
            }
            catch
{
    throw;
}
        }

        public void AgregarActivo(Activo activo)
        {
            try
            {
                if (this.Activos.Contains(activo))
                {
                    throw new Exception("Ya existe un activo con esos datos");
                }
                this.Activos.Add(activo);
            }
            catch
{
    throw;
}
        }


        public void AgregarIncidente(Incidente incidente)
        {
            try
            {
                if (this.Incidentes.Contains(incidente))
                {
                    throw new Exception("Ya existe ese incidente");
                }
                this.Incidentes.Add(incidente);
            }
            catch
{
    throw;
}
        }
        public void PrecargarDatos()
        {
            this.PrecargarPersonas();
            this.PrecargarCuentas();
            this.PrecargarActivos();
            this.PrecargarIncidentes();
        }
        private void PrecargarPersonas()
        {
            List<Persona> personas = new List<Persona>
{
                new Persona("12345678", "Ana García", "ana.garcia@email.com", "099123456", "admin123", Rol.ADMIN),

                new Persona("23456789", "Carlos López", "carlos.lopez@email.com", "098234567", "1234", Rol.OPERADOR),
                new Persona("34567890", "María Martínez", "maria.martinez@email.com", "097345678", "1234", Rol.OPERADOR),
                new Persona("45678901", "Juan Rodríguez", "juan.rodriguez@email.com", "096456789", "1234", Rol.OPERADOR),
                new Persona("56789012", "Laura Sánchez", "laura.sanchez@email.com", "095567890", "1234", Rol.OPERADOR),
                new Persona("67890123", "Pedro Fernández", "pedro.fernandez@email.com", "094678901", "1234", Rol.OPERADOR),
                new Persona("78901234", "Sofía González", "sofia.gonzalez@email.com", "093789012", "1234", Rol.OPERADOR),
                new Persona("89012345", "Diego Pérez", "diego.perez@email.com", "092890123", "1234", Rol.OPERADOR),
                new Persona("90123456", "Valentina Torres", "valentina.torres@email.com", "091901234", "1234", Rol.OPERADOR),
                new Persona("01234567", "Mateo Ramírez", "mateo.ramirez@email.com", "090012345", "1234", Rol.OPERADOR)
};
            foreach (Persona persona in personas)
            {
                //equipo.Validar();
                AgregarPersona(persona);
            }
        }
        private void PrecargarCuentas()
        {
            List<Cuenta> cuentas = new List<Cuenta>
            {
                new Cuenta(Personas[0], true,  new DateTime(2024, 11, 5)),
                new Cuenta(Personas[0], false, new DateTime(2023, 6, 20)),
                new Cuenta(Personas[1], true,  new DateTime(2025, 1, 15)),
                new Cuenta(Personas[2], true,  new DateTime(2024, 8, 30)),
                new Cuenta(Personas[2], true,  new DateTime(2025, 3, 10)),
                new Cuenta(Personas[3], false, new DateTime(2023, 12, 1)),
                new Cuenta(Personas[4], true,  new DateTime(2025, 2, 28)),
                new Cuenta(Personas[5], false, new DateTime(2024, 4, 17)),
                new Cuenta(Personas[5], true,  new DateTime(2024, 9, 22)),
                new Cuenta(Personas[6], false, new DateTime(2023, 7, 8)),
                new Cuenta(Personas[7], true,  new DateTime(2025, 4, 3)),
                new Cuenta(Personas[8], false, new DateTime(2024, 2, 14)),
            };
            foreach (Cuenta cuenta in cuentas)
            {
                AgregarCuenta(cuenta);
            }
        }

        private void PrecargarActivos()
        {
            List<Activo> activos = new List<Activo>
            {

                new Activo("Laptop Desarrollo 1",    TipoActivo.PC,     3, Cuentas[0],  true),
                new Activo("Laptop Diseño",          TipoActivo.PC,     2, Cuentas[1],  false),
                new Activo("PC Administración",      TipoActivo.PC,     3, Cuentas[2],  true),
                new Activo("PC Contabilidad",        TipoActivo.PC,     4, Cuentas[3],  true),
                new Activo("Laptop Gerencia",        TipoActivo.PC,     5, Cuentas[4],  true),
                new Activo("Servidor Web",           TipoActivo.SERVER, 5, Cuentas[5],  true),
                new Activo("Servidor Base de Datos", TipoActivo.SERVER, 5, Cuentas[6],  true),
                new Activo("Servidor de Archivos",   TipoActivo.SERVER, 4, Cuentas[7],  true),
                new Activo("Servidor de Correo",     TipoActivo.SERVER, 4, Cuentas[8],  true),
                new Activo("Servidor de Backup",     TipoActivo.SERVER, 3, Cuentas[9],  true),
                new Activo("Celular Soporte 1",      TipoActivo.MOVIL,  2, Cuentas[10], false),
                new Activo("Celular Soporte 2",      TipoActivo.MOVIL,  2, Cuentas[11], false),
                new Activo("Tablet Gerencia",        TipoActivo.MOVIL,  4, Cuentas[0],  true),
                new Activo("Celular Ventas 1",       TipoActivo.MOVIL,  2, Cuentas[3],  false),
                new Activo("Celular Ventas 2",       TipoActivo.MOVIL,  1, Cuentas[5],  false),
            };
            foreach (Activo activo in activos)
            {
                AgregarActivo(activo);
            }
        }
        private void PrecargarIncidentes()
        {
            List<Incidente> incidentes = new List<Incidente>
            {
                new Phishing(
                    new DateTime(2024, 1, 10), Activos[0],
                    "Correo falso suplantando al banco solicitando credenciales",
                    Estado.CERRADO, 3, 4, true, false, Canal.EMAIL),

                new Phishing(
                    new DateTime(2024, 2, 14), Activos[1],
                    "Mensaje de WhatsApp con link malicioso a sitio falso",
                    Estado.CERRADO, 2, 2, false, false, Canal.WHATSAPP),

                new Phishing(
                    new DateTime(2024, 3, 5), Activos[2],
                    "Llamada fraudulenta solicitando acceso remoto al equipo",
                    Estado.CONTENIDO, 4, 3, true, true, Canal.LLAMADA),

                new Phishing(
                    new DateTime(2024, 3, 22), Activos[3],
                    "Publicación en redes sociales con enlace a formulario falso",
                    Estado.CERRADO, 2, 2, false, false, Canal.REDES_SOCIALES),

                new Phishing(
                    new DateTime(2024, 4, 8), Activos[4],
                    "Email corporativo falsificado solicitando cambio de contraseña",
                    Estado.CERRADO, 5, 5, true, true, Canal.EMAIL),

                new Phishing(
                    new DateTime(2024, 5, 17), Activos[5],
                    "SMS con link falso suplantando servicio de mensajería",
                    Estado.CONTENIDO, 3, 3, true, false, Canal.WHATSAPP),

                new Phishing(
                    new DateTime(2024, 6, 1), Activos[6],
                    "Correo con adjunto malicioso disfrazado de factura",
                    Estado.EN_ANALISIS, 4, 4, false, true, Canal.EMAIL),

                new Phishing(
                    new DateTime(2024, 6, 28), Activos[7],
                    "Llamada simulando ser soporte técnico interno",
                    Estado.ABIERTO, 3, 3, true, false, Canal.LLAMADA),

                new Phishing(
                    new DateTime(2024, 7, 15), Activos[8],
                    "Perfil falso en redes sociales contactando a empleados",
                    Estado.EN_ANALISIS, 2, 2, false, false, Canal.REDES_SOCIALES),

                new Phishing(
                    new DateTime(2024, 8, 3), Activos[9],
                    "Email masivo falso suplantando al área de RRHH",
                    Estado.CERRADO, 4, 4, true, true, Canal.EMAIL),

                new Phishing(
                    new DateTime(2024, 8, 20), Activos[3],
                    "Mensaje de WhatsApp con cupón de descuento falso",
                    Estado.CERRADO, 1, 1, false, false, Canal.WHATSAPP),

                new Phishing(
                    new DateTime(2024, 9, 9), Activos[4],
                    "Correo falso solicitando transferencia urgente de fondos",
                    Estado.CONTENIDO, 5, 5, true, true, Canal.EMAIL),

                new Phishing(
                    new DateTime(2024, 10, 4), Activos[5],
                    "Llamada falsa solicitando código de autenticación MFA",
                    Estado.EN_ANALISIS, 4, 4, true, false, Canal.LLAMADA),

                new Phishing(
                    new DateTime(2024, 11, 11), Activos[6],
                    "Publicación falsa en LinkedIn con link a sitio de login clonado",
                    Estado.ABIERTO, 3, 3, false, false, Canal.REDES_SOCIALES),

                new Phishing(
                    new DateTime(2024, 12, 1), Activos[7],
                    "Email con link falso suplantando proveedor de software",
                    Estado.ABIERTO, 4, 5, true, true, Canal.EMAIL),

                new Ransomware(
                    new DateTime(2024, 1, 25), Activos[5],
                    "Ransomware cifró archivos del servidor web tras acceso remoto",
                    Estado.CERRADO, 5, 5, false, true),

                new Ransomware(
                    new DateTime(2024, 2, 8), Activos[6],
                    "Cifrado masivo de base de datos por variante de LockBit",
                    Estado.CERRADO, 5, 5, true, true),

                new Ransomware(
                    new DateTime(2024, 3, 14), Activos[7],
                    "Ransomware en servidor de archivos con exfiltración previa",
                    Estado.CONTENIDO, 4, 5, true, true),

                new Ransomware(
                    new DateTime(2024, 4, 2), Activos[8],
                    "Cifrado parcial de correos corporativos almacenados",
                    Estado.CONTENIDO, 3, 4, false, true),

                new Ransomware(
                    new DateTime(2024, 4, 19), Activos[9],
                    "Intento de ransomware bloqueado por antivirus en servidor backup",
                    Estado.CERRADO, 2, 3, false, false),

                new Ransomware(
                    new DateTime(2024, 5, 30), Activos[0],
                    "Ransomware en laptop de desarrollo con archivos de código fuente",
                    Estado.CERRADO, 4, 4, false, true),

                new Ransomware(
                    new DateTime(2024, 6, 15), Activos[1],
                    "Cifrado de documentos de diseño por ransomware desconocido",
                    Estado.CONTENIDO, 3, 3, false, true),

                new Ransomware(
                    new DateTime(2024, 7, 7), Activos[2],
                    "Ransomware propagado desde PC de administración a red interna",
                    Estado.EN_ANALISIS, 5, 5, true, true),

                new Ransomware(
                    new DateTime(2024, 7, 28), Activos[3],
                    "Cifrado de planillas contables con demanda de rescate",
                    Estado.EN_ANALISIS, 4, 5, true, true),

                new Ransomware(
                    new DateTime(2024, 8, 14), Activos[4],
                    "Ransomware en laptop gerencial con datos estratégicos cifrados",
                    Estado.CONTENIDO, 5, 5, true, true),

                new Ransomware(
                    new DateTime(2024, 9, 1), Activos[1],
                    "Intento de instalación de ransomware vía app falsa en celular",
                    Estado.CERRADO, 2, 2, false, false),

                new Ransomware(
                    new DateTime(2024, 10, 18), Activos[0],
                    "Ransomware en celular de soporte con acceso a red corporativa",
                    Estado.EN_ANALISIS, 3, 4, false, true),

                new Ransomware(
                    new DateTime(2024, 11, 5), Activos[9],
                    "Cifrado de datos en tablet gerencial con exfiltración confirmada",
                    Estado.ABIERTO, 5, 5, true, true),

                new Ransomware(
                    new DateTime(2024, 11, 22), Activos[7],
                    "Ransomware detectado en celular de ventas sin propagación",
                    Estado.ABIERTO, 2, 3, false, false),

                new Ransomware(
                    new DateTime(2024, 12, 10), Activos[8],
                    "Cifrado de archivos en celular de ventas con datos de clientes",
                    Estado.ABIERTO, 4, 5, true, true),
            };
            foreach (Incidente incidente in incidentes)
            {
                AgregarIncidente(incidente);
            }
        }
        public List<Incidente> ObtenerIncidentesPorPersona(Persona persona)
        {
            List<Incidente> incidentes = new List<Incidente>();

            foreach (Incidente incidente in _incidentes)
            {
                if (incidente.ActivoAfectado.Cuenta.Titular.Equals(persona))
                {
                    incidentes.Add(incidente);
                }
            }

            return incidentes;
        }
        public List<Activo> ObtenerActivosSinBackup()
        {
            List<Activo> activosSinBackup = new List<Activo>();

            foreach (Activo activo in _activos)
            {
                if (!activo.TieneBackup)
                {
                    activosSinBackup.Add(activo);
                }
            }

            return activosSinBackup;
        }
        public Persona AutenticarPersona(string email, string contrasenia) // Metodo para autenticar a una persona por email y contraseña, para el login
        {
            foreach (Persona persona in _personas)
            {
                if (persona.Email == email &&
                    persona.Contrasenia == contrasenia)
                {
                    return persona;
                }
            }

            throw new Exception("Email o contraseña incorrectos");
        }
        public List<Activo> ObtenerActivosOperador(string email) // Metodo para obtener los activos de un operador por su email,
                                                                 // para mostrar activos por usuario logueado
        {
            List<Activo> aRetornar = new List<Activo>();

            foreach (Activo activo in _activos)
            {
                if (activo.Cuenta != null &&
                    activo.Cuenta.Titular.Email == email)
                {
                    aRetornar.Add(activo);
                }
            }

            aRetornar.Sort();

            return aRetornar;
        }
        public Persona BuscarPersonaPorEmail(string email) // Metodo para buscar una persona por su email,
                                                           // para obtener la persona logueada y mostrar sus datos
        {
            foreach (Persona persona in _personas)
            {
                if (persona.Email == email)
                {
                    return persona;
                }
            }
            return null;
        }
        public List<Cuenta> ObtenerCuentasDePersona(string cedula) // Metodo para obtener las cuentas de una persona por su cédula,
                                                                   // para mostrar las cuentas de un usuario logueado
        {
            List<Cuenta> resultado = new List<Cuenta>();

            foreach (Cuenta cuenta in _cuentas)
            {
                if (cuenta.Titular.Cedula == cedula)
                {
                    resultado.Add(cuenta);
                }
            }

            return resultado;
        }
        public List<Activo> ObtenerActivosDeCuenta(int codigoCuenta) // Metodo para obtener los activos de una cuenta por su código,
                                                                     // para mostrar los activos de una cuenta seleccionada
        {
            List<Activo> aRetornar = new List<Activo>();

            foreach (Activo activo in _activos)
            {
                if (activo.Cuenta != null &&
                    activo.Cuenta.Codigo == codigoCuenta)
                {
                    aRetornar.Add(activo);
                }
            }

            return aRetornar;
        }
        public Activo BuscarActivo(string codigo) // Metodo para buscar un activo por su codigo,
                                                  // para mostrar los detalles del activo seleccionado
        {
            foreach (Activo activo in _activos)
            {
                if (activo.Codigo == codigo)
                {
                    return activo;
                }
            }

            return null;
        }
        public bool TieneIncidentes(Activo activo) // Metodo para verificar si un activo tiene incidentes asociados,
                                                   // para ver si se puede desasociar o no
        {
            foreach (Incidente incidente in _incidentes)
            {
                if (incidente.ActivoAfectado.Equals(activo))
                {
                    return true;
                }
            }

            return false;
        }
        public Persona BuscarPersonaPorCedula(string cedula) // Metodo para buscar una persona por su cedula,
                                                             // para obtener la persona logueada y mostrar sus datos
        {
            foreach (Persona persona in _personas)
            {
                if (persona.Cedula == cedula)
                {
                    return persona;
                }
            }

            return null;
        }
        public Cuenta BuscarCuenta(int codigo) // Metodo para buscar una cuenta por su codigo,
                                               // para obtener la cuenta seleccionada y mostrar sus datos
        {
            foreach (Cuenta cuenta in _cuentas)
            {
                if (cuenta.Codigo == codigo)
                {
                    return cuenta;
                }
            }

            return null;
        }
        public List<Incidente> ObtenerIncidentesPorSeveridad() // Metodo para obtener los incidentes ordenados por severidad,
                                                               // para mostrar los incidentes en la vista de incidentes
        {
            List<Incidente> resultado = new List<Incidente>(_incidentes);

            resultado.Sort();

            return resultado;
        }
    }
}
