namespace MarsLander
{
    partial class FlightDataReader
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.FlightDataReaderOutput = new System.Windows.Forms.RichTextBox();
            this.CloseFlightReader = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // FlightDataReaderOutput
            // 
            this.FlightDataReaderOutput.Location = new System.Drawing.Point(12, 12);
            this.FlightDataReaderOutput.Name = "FlightDataReaderOutput";
            this.FlightDataReaderOutput.Size = new System.Drawing.Size(483, 568);
            this.FlightDataReaderOutput.TabIndex = 0;
            this.FlightDataReaderOutput.Text = "";
            // 
            // CloseFlightReader
            // 
            this.CloseFlightReader.Location = new System.Drawing.Point(222, 598);
            this.CloseFlightReader.Name = "CloseFlightReader";
            this.CloseFlightReader.Size = new System.Drawing.Size(75, 23);
            this.CloseFlightReader.TabIndex = 1;
            this.CloseFlightReader.Text = "Close";
            this.CloseFlightReader.UseVisualStyleBackColor = true;
            this.CloseFlightReader.Click += new System.EventHandler(this.CloseFlightReader_Click);
            // 
            // FlightDataReader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 633);
            this.Controls.Add(this.CloseFlightReader);
            this.Controls.Add(this.FlightDataReaderOutput);
            this.Name = "FlightDataReader";
            this.Text = "Flight Data Reader";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox FlightDataReaderOutput;
        private System.Windows.Forms.Button CloseFlightReader;
    }
}