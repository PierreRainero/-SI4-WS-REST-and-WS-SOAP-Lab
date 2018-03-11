using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Client_Velib{
    public partial class Form1 : Form{
        private VelibSOAP.VelibOperationsClient velibClient;

        private string cityChosen;
        private string stationChosen;

        public Form1(){
            InitializeComponent();
            this.Text = "GUI - Velib";
            velibClient = new VelibSOAP.VelibOperationsClient();
        }

        private void cityButton_Click(object sender, EventArgs e){
            cityChosen = cityInput.Text;

            if(cityChosen != ""){
                IList<string> response = velibClient.getStations(cityChosen);
                stationsComboBox.Items.Clear();
                bikeNb.Text = "";

                foreach (string item in response)
                    stationsComboBox.Items.Add(item);

            }
        }

        private void selectedItemChange(object sender, EventArgs e){
            stationChosen = stationsComboBox.SelectedItem.ToString();
            cityChosen = cityInput.Text;

            if (cityChosen != "" && stationChosen != "")
                bikeNb.Text = velibClient.getAvailableBikes(cityChosen, stationChosen).ToString();
        }
    }
}
