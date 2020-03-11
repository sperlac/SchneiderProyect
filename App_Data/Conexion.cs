using Contadores.Models;
using LinqToDB;
using LinqToDB.Data;

namespace Contadores.App_Data
{
    public class Conexion : DataConnection
    {
        public Conexion() : base("PDHN1") { }
        public ITable<Meter> _Meter { get { return GetTable<Meter>(); } }
        public ITable<Gateway> _Gateway { get { return GetTable<Gateway>(); } }
    }
}