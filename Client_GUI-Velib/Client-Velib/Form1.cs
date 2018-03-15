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

            IList<string> response = velibClient.getCities();
            foreach (string item in response)
                cityComboBox.Items.Add(item);
        }

        private void cityButton_Click(object sender, EventArgs e){
            cityChosen = cityComboBox.SelectedItem.ToString();

            if(cityChosen != ""){
                IList<string> response = velibClient.getStations(cityChosen);
                stationComboBox.Items.Clear();
                bikeNb.Text = "";

                foreach (string item in response)
                    stationComboBox.Items.Add(item);

            }
        }

        private void selectedItemChange(object sender, EventArgs e){
            stationChosen = stationComboBox.SelectedItem.ToString();
            cityChosen = cityComboBox.SelectedItem.ToString();
            
            if (cityChosen != "" && stationChosen != "")
                bikeNb.Text = velibClient.getAvailableBikes(cityChosen, stationChosen).ToString();
        }
    }
}
