using Contadores.App_Data;
using Contadores.Models;
using LinqToDB;
using LinqToDB.DataProvider.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;


namespace Contadores.Services
{
    public class MeterService
    {
        private List<TextBox> listTextBox;

        public MeterService(List<TextBox> listTextBox)
        {
            this.listTextBox = listTextBox;
        }

        public void RegisterMeter(string typeMeter)
        {
            try
            {
                using (var db = new Conexion())
                {
                    db.Insert(new Meter()
                    {
                        serialNumber = typeMeter + listTextBox[0].Text,
                        brand = listTextBox[1].Text,
                        model = listTextBox[2].Text
                    });
                }
            }
            catch (Exception ex) { throw ex; }
        }

        // check if it exists in the database before saving it
        public bool CheckDuplicate(string typeMeter)
        {
            try
            {
                if (typeMeter.Equals("Water-") || typeMeter.Equals("Light-"))
                {
                    using (var db = new Conexion())
                    {
                        var met = db._Meter.Where(u => u.serialNumber.Equals(typeMeter + listTextBox[0].Text)).ToList();
                        if (met.Count.Equals(0))
                        {
                            return false;
                        }
                    }
                }              
                
            }
            catch (Exception ex) { throw ex; }
            return true;
        }

        

        //list meters
        public List<Meter> ListAllMeters()
        {
            List<Meter> mt = new List<Meter>();
            try
            {

                using (var db = new Conexion())
                {
                    return mt = db._Meter.ToList();

                }
            }
            catch (Exception ex) { throw ex; }
        }
    }
}