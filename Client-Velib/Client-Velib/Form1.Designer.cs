namespace Client_Velib
{
    partial class Form1
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
            this.cityInput = new System.Windows.Forms.TextBox();
            this.cityButton = new System.Windows.Forms.Button();
            this.stationsComboBox = new System.Windows.Forms.ComboBox();
            this.bikeLabelNb = new System.Windows.Forms.Label();
            this.bikeNb = new System.Windows.Forms.Label();
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
            // cityInput
            // 
            this.cityInput.Location = new System.Drawing.Point(71, 6);
            this.cityInput.Name = "cityInput";
            this.cityInput.Size = new System.Drawing.Size(180, 20);
            this.cityInput.TabIndex = 1;
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
            // stationsComboBox
            // 
            this.stationsComboBox.FormattingEnabled = true;
            this.stationsComboBox.Location = new System.Drawing.Point(32, 85);
            this.stationsComboBox.Name = "stationsComboBox";
            this.stationsComboBox.Size = new System.Drawing.Size(219, 21);
            this.stationsComboBox.TabIndex = 3;
            this.stationsComboBox.SelectedIndexChanged += new System.EventHandler(this.selectedItemChange);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.bikeNb);
            this.Controls.Add(this.bikeLabelNb);
            this.Controls.Add(this.stationsComboBox);
            this.Controls.Add(this.cityButton);
            this.Controls.Add(this.cityInput);
            this.Controls.Add(this.cityLabel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label cityLabel;
        private System.Windows.Forms.TextBox cityInput;
        private System.Windows.Forms.Button cityButton;
        private System.Windows.Forms.ComboBox stationsComboBox;
        private System.Windows.Forms.Label bikeLabelNb;
        private System.Windows.Forms.Label bikeNb;
    }
}

