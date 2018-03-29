namespace Client_Velib
{
    partial class GUI_Form
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.cityLabel = new System.Windows.Forms.Label();
            this.cityButton = new System.Windows.Forms.Button();
            this.stationComboBox = new System.Windows.Forms.ComboBox();
            this.bikeLabelNb = new System.Windows.Forms.Label();
            this.bikeNb = new System.Windows.Forms.Label();
            this.stationLabel = new System.Windows.Forms.Label();
            this.cityComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cityLabel
            // 
            this.cityLabel.AutoSize = true;
            this.cityLabel.Location = new System.Drawing.Point(29, 9);
            this.cityLabel.Name = "cityLabel";
            this.cityLabel.Size = new System.Drawing.Size(26, 13);
            this.cityLabel.TabIndex = 0;
            this.cityLabel.Text = "Ville";
            // 
            // cityButton
            // 
            this.cityButton.Location = new System.Drawing.Point(111, 32);
            this.cityButton.Name = "cityButton";
            this.cityButton.Size = new System.Drawing.Size(75, 23);
            this.cityButton.TabIndex = 2;
            this.cityButton.Text = "Rechercher";
            this.cityButton.UseVisualStyleBackColor = true;
            this.cityButton.Click += new System.EventHandler(this.cityButton_Click);
            // 
            // stationComboBox
            // 
            this.stationComboBox.FormattingEnabled = true;
            this.stationComboBox.Location = new System.Drawing.Point(71, 85);
            this.stationComboBox.Name = "stationComboBox";
            this.stationComboBox.Size = new System.Drawing.Size(180, 21);
            this.stationComboBox.TabIndex = 3;
            this.stationComboBox.SelectedIndexChanged += new System.EventHandler(this.selectedItemChange);
            // 
            // bikeLabelNb
            // 
            this.bikeLabelNb.AutoSize = true;
            this.bikeLabelNb.Location = new System.Drawing.Point(29, 122);
            this.bikeLabelNb.Name = "bikeLabelNb";
            this.bikeLabelNb.Size = new System.Drawing.Size(94, 13);
            this.bikeLabelNb.TabIndex = 4;
            this.bikeLabelNb.Text = "Vélos disponibles :";
            // 
            // bikeNb
            // 
            this.bikeNb.AutoSize = true;
            this.bikeNb.Location = new System.Drawing.Point(129, 122);
            this.bikeNb.Name = "bikeNb";
            this.bikeNb.Size = new System.Drawing.Size(0, 13);
            this.bikeNb.TabIndex = 5;
            // 
            // stationLabel
            // 
            this.stationLabel.AutoSize = true;
            this.stationLabel.Location = new System.Drawing.Point(30, 88);
            this.stationLabel.Name = "stationLabel";
            this.stationLabel.Size = new System.Drawing.Size(40, 13);
            this.stationLabel.TabIndex = 6;
            this.stationLabel.Text = "Station";
            // 
            // cityComboBox
            // 
            this.cityComboBox.FormattingEnabled = true;
            this.cityComboBox.Location = new System.Drawing.Point(71, 6);
            this.cityComboBox.Name = "cityComboBox";
            this.cityComboBox.Size = new System.Drawing.Size(180, 21);
            this.cityComboBox.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.cityComboBox);
            this.Controls.Add(this.stationLabel);
            this.Controls.Add(this.bikeNb);
            this.Controls.Add(this.bikeLabelNb);
            this.Controls.Add(this.stationComboBox);
            this.Controls.Add(this.cityButton);
            this.Controls.Add(this.cityLabel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label cityLabel;
        private System.Windows.Forms.Button cityButton;
        private System.Windows.Forms.ComboBox stationComboBox;
        private System.Windows.Forms.Label bikeLabelNb;
        private System.Windows.Forms.Label bikeNb;
        private System.Windows.Forms.Label stationLabel;
        private System.Windows.Forms.ComboBox cityComboBox;
    }
}

