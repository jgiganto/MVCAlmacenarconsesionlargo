using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCAlmacenarconsesionlargo.Models
{
    
    public class ModeloHospital
    {
        ContextoHospital contexto;
        public ModeloHospital()
        {
            contexto = new ContextoHospital();
        }
        public IQueryable<EMP> GetEmpleados()
        {
            var consulta = from datos in this.contexto.EMP
                           select datos;
            return consulta;
        }

        public IQueryable<EMP> GetEmpleadosSession(List<int> emplados)
        {
            var consulta = from datos in this.contexto.EMP
                           where emplados.Contains(datos.EMP_NO)
                           select datos;
            return consulta;
        }
    }
}