using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppBibilioteca.Vista
{
    public partial class tester : Form
    {
        public tester()
        {
            InitializeComponent();
        }

        private void tester_Load(object sender, EventArgs e)
        {
            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
            flowLayoutPanel.Dock = DockStyle.Fill; // Fill the entire form
            this.Controls.Add(flowLayoutPanel);

            // Create multiple cards dynamically
            for (int i = 0; i < 5; i++)
            {
                // Create a panel to represent a card
                Panel cardPanel = new Panel();
                cardPanel.BorderStyle = BorderStyle.FixedSingle;
                cardPanel.Size = new System.Drawing.Size(200, 100);

                // Create a Label for card content
                Label label = new Label();
                label.Text = "Card " + (i + 1);
                label.Dock = DockStyle.Top; // Dock label to the top of the panel
                cardPanel.Controls.Add(label);

                // Create a Button for card content
                Button button = new Button();
                button.Text = "Click me";
                button.Dock = DockStyle.Bottom; // Dock button to the bottom of the panel
                button.Click += (s, evt) => MessageBox.Show("Button clicked on card " + (i + 1));
                cardPanel.Controls.Add(button);

                // Add the card panel to the FlowLayoutPanel
                flowLayoutPanel.Controls.Add(cardPanel);
            }
            }
    }
}
