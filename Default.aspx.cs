using Contadores.App_Data;
using Contadores.Models;
using Contadores.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Contadores
{
    public partial class _Default : Page
    {
        #region
        protected void Page_Load(object sender, EventArgs e)
        {
            //Load grid view with all meter and gateways
            loadAll();
        }
        //to insert new meter and gateway
        protected void add_Click(object sender, EventArgs e)
        {
            if (this.options.SelectedItem.Text.Equals("Gateway") && !this.serialNumerBox.Text.Equals("") && !this.ipBox.Text.Equals(""))
            {
                List<TextBox> listText = new List<TextBox>();
                listText.Add(this.serialNumerBox);
                listText.Add(this.brandBox);
                listText.Add(this.modelBox);
                listText.Add(this.ipBox);
                listText.Add(this.portBox);

                GateWayService ms = new GateWayService(listText);
                if (!ms.CheckDuplicate())
                {
                    ms.RegisterGateWay();
                    cleanForm();
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "showInfo", "alert('This gateway has been saved');", true);
                }
                else
                {
                    //alert alreay exists
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "showError", "alert('This gateway already exists');", true);
                }
            }
            else if (!this.serialNumerBox.Text.Equals(""))
            {
                if (this.options.SelectedItem.Text.Equals("Light meter"))
                {

                    List<TextBox> listText = new List<TextBox>();
                    listText.Add(this.serialNumerBox);
                    listText.Add(this.brandBox);
                    listText.Add(this.modelBox);

                    MeterService ms = new MeterService(listText);
                    if (!ms.CheckDuplicate("Light-"))
                    {
                        ms.RegisterMeter("Light-");
                        cleanForm();
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "showInfo", "alert('This meter has been saved');", true);
                    }
                    else
                    {
                        //alert alreay exists
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "showError", "alert('This meter already exists');", true);
                    }
                }
                else if (this.options.SelectedItem.Text.Equals("Water meter"))
                {
                    List<TextBox> listText = new List<TextBox>();
                    listText.Add(this.serialNumerBox);
                    listText.Add(this.brandBox);
                    listText.Add(this.modelBox);

                    MeterService ms = new MeterService(listText);
                    if (!ms.CheckDuplicate("Water-"))
                    {
                        ms.RegisterMeter("Water-");
                        cleanForm();
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "showInfo", "alert('This meter has been saved');", true);
                    }
                    else
                    {
                        //alert alreay exists
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "showError", "alert('This meter already exists');", true);
                    }

                }
            }
            else {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "showError", "alert('Someone data has not been writtens');", true);
            }
                
        }
        
        //visibility options
        protected void loadOptions(object sender, EventArgs e)
        {
            if (this.options.SelectedItem.Text.Equals("Light meter") || this.options.SelectedItem.Text.Equals("Water meter"))
            {
                this.ip.Visible = false;
                this.port.Visible = false;
                this.portBox.Visible = false;
                this.ipBox.Visible = false;
            }
            else if (this.options.SelectedItem.Text.Equals("Gateway"))
            {
                this.ip.Visible = true;
                this.port.Visible = true;
                this.portBox.Visible = true;
                this.ipBox.Visible = true;

            }

        }
        #endregion

        //clean form when this is added
        public void cleanForm() {            
            this.portBox.Text = string.Empty;
            this.ipBox.Text = string.Empty;
            this.modelBox.Text = string.Empty;
            this.serialNumerBox.Text = string.Empty;
            this.brandBox.Text = string.Empty;
        }
        //list all meters and gateways
        public void loadAll() {
            GateWayService gt = new GateWayService(new List<TextBox>());
            List <Gateway> listGateWay = new List<Gateway>();
            listGateWay = gt.ListAllGateways();
            this.GridView_Gateways.DataSource = listGateWay;
            this.GridView_Gateways.DataBind();

            MeterService mt = new MeterService(new List<TextBox>());
            List<Meter> listMeter = new List<Meter>();
            listMeter = mt.ListAllMeters();
            this.GridView_Meters.DataSource = listMeter;
            this.GridView_Meters.DataBind();

        }
    }
}