using Contadores.App_Data;
using Contadores.Models;
using LinqToDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Contadores.Services
{
    public class GateWayService
    {
        private List<TextBox> listTextBox;

        public GateWayService(List<TextBox> listTextBox)
        {
            this.listTextBox = listTextBox;
        }

        public void RegisterGateWay()
        {
            try
            {
                using (var db = new Conexion())
                {
                    db.Insert(new Gateway()
                    {
                        serialNumber = listTextBox[0].Text,
                        brand = listTextBox[1].Text,
                        model = listTextBox[2].Text,
                        ip = listTextBox[3].Text,
                        port = listTextBox[4].Text
                    });
                }
            }
            catch (Exception ex) { throw ex; }
        }

        

        // check if it exists in the database before saving it
        public bool CheckDuplicate()
        {
            try
            {
                
                    using (var db = new Conexion())
                    {
                        var gt = db._Gateway.Where(u => u.serialNumber.Equals(listTextBox[0].Text) && u.ip.Equals(listTextBox[3].Text)).ToList();

                        if (gt.Count.Equals(0))
                        {
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    }
            }
            catch (Exception ex) { throw ex; }

        }

        //list gateway
        public List<Gateway> ListAllGateways() {
            List<Gateway> gt = new List<Gateway>();
            try
            {

                using (var db = new Conexion())
                {
                    return gt = db._Gateway.ToList();
                                        
                }
            }
            catch (Exception ex) { throw ex; }
        }

    }
}