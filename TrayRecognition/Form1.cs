using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Basic;
using SQLUI;

namespace TrayRecognition
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox_料號.DataSource = new enum_pn().GetEnumNames();
            comboBox_料號.SelectedIndex = -1;
            comboBox_料號.Text = "選擇料號";
            comboBox_料號.SelectedIndexChanged += ComboBox_料號_SelectedIndexChanged;
        }

        private void ComboBox_料號_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_料號.SelectedItem.ToString() == "料號1")
            {
                RemoveRuttons();
                create2Buttons();
            }
            else if (comboBox_料號.SelectedItem.ToString() == "料號2")
            {
                RemoveRuttons();
                create2Buttons();
                create3Buttons();
            }
            
        }
        private void create2Buttons()
        {
            Button button1 = new Button();
            button1.Location = new Point(527, 94);
            button1.Size = new Size(153, 73);
            button1.Text = "Stage 1";
            button1.Font = new Font("Microsoft JhengHei", 24);
            this.Controls.Add(button1);

            Button button2 = new Button();
            button2.Location = new Point(527, 197);
            button2.Size = new Size(153, 73);
            button2.Text = "Stage 2";
            button2.Font = new Font("Microsoft JhengHei", 24);
            this.Controls.Add(button2);

        }
        private void create3Buttons()
        {
            Button button3 = new Button();
            button3.Location = new Point(527, 303);
            button3.Size = new Size(153, 73);
            button3.Text = "Stage 3";
            button3.Font = new Font("Microsoft JhengHei", 24);
            this.Controls.Add(button3);      

        }
        private void RemoveRuttons()
        {
            foreach (Control control in this.Controls.OfType<Button>().ToList())
            {
                if(control.Text == "Stage 1" || control.Text == "Stage 2" || control.Text == "Stage 3")
                {
                    this.Controls.Remove(control);
                }
            }
        }
    }
}
