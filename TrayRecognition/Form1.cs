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
            button_start.Size = new Size(153, 73);
            button_start.Text = "Start";
            button_start.Font = new Font("Microsoft JhengHei", 24);
            label_result.Size = new Size(71, 153);
            label_result.Font = new Font("Microsoft JhengHei", 24);
            label_result.Text = "";
            comboBox_料號.SelectedIndexChanged += ComboBox_料號_SelectedIndexChanged;
            this.button_start.Click += Button_start_Click;

        }

        private void Button_start_Click(object sender, EventArgs e)
        {
            string datetime = DateTime.Now.ToDateTimeString().Replace("/","_").Replace(":","_");
            
            if (comboBox_料號.Text == "product_03") 
            {
                List<string> result = ExcuteProduct1(datetime);
                label_result.Text = string.Join(Environment.NewLine, result);
            }

        }

        private void ComboBox_料號_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (comboBox_料號.SelectedItem.ToString() == "product_03")
            //{
            //    RemoveRuttons();
            //    create2Buttons();
            //}
            //else if (comboBox_料號.SelectedItem.ToString() == "料號2")
            //{
            //    RemoveRuttons();
            //    create2Buttons();
            //    create3Buttons();
            //}
            if (comboBox_料號.SelectedItem.ToString() == "product_03")
            {
                RemovePanels();
                create2Panel();
                create3Panel();
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
        private void create2Panel()
        {
            //Panel panel_stage1 = new Panel();
            //panel_stage1.Location = new Point(527, 94);
            //panel_stage1.Size = new Size(153, 73);
            //this.Controls.Add(panel_stage1);

            //Panel panel_stage2 = new Panel();
            //panel_stage2.Location = new Point(527, 94);
            //panel_stage2.Size = new Size(153, 73);
            //this.Controls.Add(panel_stage2);

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
            //Panel Panel3 = new Panel();
            //Panel3.Location = new Point(527, 94);
            //Panel3.Size = new Size(153, 73);
            //Panel3.Text = "Stage 3";
            //Panel3.Font = new Font("Microsoft JhengHei", 24);
            //this.Controls.Add(Panel3);

            Label label3 = new Label();
            label3.Text = "Stage 3";
            label3.Font = new Font("Microsoft JhengHei", 24);
            label3.Dock = DockStyle.Fill;
            label3.TextAlign = ContentAlignment.MiddleCenter;
            panel_stage3.Controls.Add(label3);

        }
        private void RemovePanels()
        {
            foreach (Control control in this.Controls.OfType<Button>().ToList())
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
        private List<string> ExcuteProduct1(string datetime)
        {
            int stage_num = 3;
            string matrix1 = "2,2";
            string matrix2 = "2,1";
            List<string> result = new List<string>();
            for (int i = 0; i < stage_num; i++)
            {
                updateStage(i);
                returnData returnData = new returnData();
                List<excuteClass> excuteClasses = new List<excuteClass>();
                excuteClass excuteClass = new excuteClass();
                excuteClass.matrix = (i != stage_num - 1) ? matrix1 : matrix2;
                excuteClass.stage = (i + 1).ToString();
                excuteClass.product = "product_03";
                excuteClass.op_time = datetime;
                excuteClasses.Add(excuteClass);

                returnData.Data = excuteClasses;
                string url = "http://192.168.15.113:3000/MetalMarkAI";
                string json_in = returnData.JsonSerializationt();
                string json_out = Net.WEBApiPostJson(url, json_in);
                returnData = json_out.JsonDeserializet<returnData>();
                if (i == 0) 
                {
                    if(returnData.ValueAry != null)
                    {
                        result.AddRange(returnData.ValueAry);
                    }                  
                }
                else if( i == 1)
                {

                    if (returnData.ValueAry != null)
                    {
                        for (int j = 0; j < returnData.ValueAry.Count; j++)
                        {
                            string matrix = returnData.ValueAry[j];
                            string[] parts = matrix.Split(',');
                            int number = parts[1].StringToInt32();
                            number += 2;
                            matrix = $"{parts[0]},{number}";
                            result.Add(matrix);
                        }
                    }
                }
                else
                {
                    if (returnData.ValueAry != null)
                    {
                        for (int j = 0; j < returnData.ValueAry.Count; j++)
                        {
                            string matrix = returnData.ValueAry[j];
                            string[] parts = matrix.Split(',');
                            int number = parts[1].StringToInt32();
                            number += 4;
                            matrix = $"{parts[0]},{number}";
                            result.Add(matrix);
                        }
                    }
                    
                }                
            }
            return result;
        }

        
    }
}
