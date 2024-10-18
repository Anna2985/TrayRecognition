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
using Tray_Lib;



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
            button_start.Size = new Size(153, 73);
            button_start.Text = "Start";
            button_start.Font = new Font("Microsoft JhengHei", 24);
            label_result.Size = new Size(71, 153);
            label_result.Font = new Font("Microsoft JhengHei", 24);
            label_result.Text = "";
            comboBox_料號.SelectedIndexChanged += ComboBox_料號_SelectedIndexChanged;
            this.button_start.Click += Button_start_Click;
            this.button_continue.Click += Button_continue_Click;

        }

        private void Button_continue_Click(object sender, EventArgs e)
        {
            Tray_Lib.AnotherExcuteClass.Execute();
            Console.WriteLine($"ContinueExcute 設置為: {Tray_Lib.excuteClass.ContinueExcute}");
        }

        //private void Button_start_Click(object sender, EventArgs e)
        //{            
        //    if (comboBox_料號.Text == "product_03") 
        //    {
        //        List<string> result = Tray_Lib.excuteClass.ExcuteProduct03();
        //        label_result.Text = string.Join(Environment.NewLine, result);
        //    }
        //}
        private void Button_start_Click(object sender, EventArgs e)
        {
            if (comboBox_料號.Text == "product_03")
            {
                try
                {
                    Task.Run(() =>
                    {
                        List<string> result = Tray_Lib.excuteClass.ExcuteProduct03();

                        this.Invoke(new Action(() =>
                        {
                            label_result.Text = string.Join(Environment.NewLine, result);
                        }));
                    });
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"錯誤: {ex.Message}");
                }
                
            }
        }
        private void ComboBox_料號_SelectedIndexChanged(object sender, EventArgs e)
        {          
            if (comboBox_料號.SelectedItem.ToString() == "product_03")
            {
                RemovePanels();
                create2Panel();
                create3Panel();
            }
        }
        private void create2Panel()
        {
            Label label1 = new Label();
            label1.Text = "Stage 1";
            label1.Font = new Font("Microsoft JhengHei", 24);
            label1.Dock = DockStyle.Fill; 
            label1.TextAlign = ContentAlignment.MiddleCenter;
            panel_stage1.Controls.Add(label1);

            Label label2 = new Label();
            label2.Text = "Stage 2";
            label2.Font = new Font("Microsoft JhengHei", 24);
            label2.Dock = DockStyle.Fill; 
            label2.TextAlign = ContentAlignment.MiddleCenter;
            panel_stage2.Controls.Add(label2); 
        }
        private void create3Panel()
        {
            Label label3 = new Label();
            label3.Text = "Stage 3";
            label3.Font = new Font("Microsoft JhengHei", 24);
            label3.Dock = DockStyle.Fill;
            label3.TextAlign = ContentAlignment.MiddleCenter;
            panel_stage3.Controls.Add(label3);
        }
        private void RemovePanels()
        {
            foreach (Control control in this.Controls.OfType<Panel>().ToList())
            {
                if (control.Text == "Stage 1" || control.Text == "Stage 2" || control.Text == "Stage 3")
                {
                    this.Controls.Remove(control);
                }
            }
        }
        private void updateStage(int stage)
        {
            switch (stage)
            {
                case 0:
                    panel_stage1.BackColor = Color.Yellow;
                    panel_stage2.BackColor = Color.Gray;
                    panel_stage3.BackColor = Color.Gray;
                    break;
                case 1:
                    panel_stage1.BackColor = Color.Gray;
                    panel_stage2.BackColor = Color.Yellow;
                    panel_stage3.BackColor = Color.Gray;
                    break;
                case 2:
                    panel_stage1.BackColor = Color.Gray;
                    panel_stage2.BackColor = Color.Gray;
                    panel_stage3.BackColor = Color.Yellow;
                    break;
            }
        }             
    }
}
