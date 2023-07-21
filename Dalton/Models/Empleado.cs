namespace Dalton.Models
{
   public class Empleado
      {
            public long BintEmpleadoKey { get; set; }
            public long BintPersonaLink { get; set; }
            public long BintIdProveedorLink { get; set; }
            public long BintPlazaLink { get; set; }
            public long BintMaterialLink { get; set; }
            public DateTime DtFechaIngreso { get; set; }
            public DateTime? DtFechaBaja { get; set; }
            public string VchFoto { get; set; }
            public bool BitActivo { get; set; }
     }
}