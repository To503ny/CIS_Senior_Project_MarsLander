using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarsLander
{
    public partial class FlightDataReader : Form
    {
        /// <summary>
        /// This field will store the full path to the flight data file
        /// </summary>
        private string ReadThisFlightData;

        /// <summary>
        /// Default constructor sets the file path to empty.
        /// </summary>
        public FlightDataReader()
        {
            ReadThisFlightData = "";
            InitializeComponent();
        }

        /// <summary>
        /// This constructor takes the full path of a flight data file to initialize the class member ReadThisFlightData string.
        /// </summary>
        /// <param name="readThis">The full path to the flight data file</param>
        /// <seealso cref="ReadThisFlightData"/>
        public FlightDataReader(string readThis)
        {
            ReadThisFlightData = readThis;
            InitializeComponent();
        }

        /// <summary>
        /// This method will attempt to load the CSV data file to the rich text field.
        /// </summary>
        public void LoadFlightData()
        {
            try
            {
                FlightDataReaderOutput.LoadFile(ReadThisFlightData, RichTextBoxStreamType.PlainText);

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, err.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CloseFlightReader_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}