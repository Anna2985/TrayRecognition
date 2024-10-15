
namespace TrayRecognition
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBox_料號 = new System.Windows.Forms.ComboBox();
            this.label_料號 = new System.Windows.Forms.Label();
            this.button_start = new System.Windows.Forms.Button();
            this.label_result = new System.Windows.Forms.Label();
            this.panel_stage1 = new System.Windows.Forms.Panel();
            this.panel_stage2 = new System.Windows.Forms.Panel();
            this.panel_stage3 = new System.Windows.Forms.Panel();
            this.button_continue = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBox_料號
            // 
            this.comboBox_料號.DropDownWidth = 200;
            this.comboBox_料號.Font = new System.Drawing.Font("微軟正黑體", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.comboBox_料號.FormattingEnabled = true;
            this.comboBox_料號.ItemHeight = 40;
            this.comboBox_料號.Location = new System.Drawing.Point(43, 71);
            this.comboBox_料號.Name = "comboBox_料號";
            this.comboBox_料號.Size = new System.Drawing.Size(237, 48);
            this.comboBox_料號.TabIndex = 0;
            // 
            // label_料號
            // 
            this.label_料號.AutoSize = true;
            this.label_料號.Font = new System.Drawing.Font("微軟正黑體", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_料號.Location = new System.Drawing.Point(36, 28);
            this.label_料號.Name = "label_料號";
            this.label_料號.Size = new System.Drawing.Size(81, 40);
            this.label_料號.TabIndex = 1;
            this.label_料號.Text = "料號";
            // 
            // button_start
            // 
            this.button_start.Location = new System.Drawing.Point(43, 147);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(237, 94);
            this.button_start.TabIndex = 2;
            this.button_start.Text = "button1";
            this.button_start.UseVisualStyleBackColor = true;
            // 
            // label_result
            // 
            this.label_result.AutoSize = true;
            this.label_result.Location = new System.Drawing.Point(348, 66);
            this.label_result.Name = "label_result";
            this.label_result.Size = new System.Drawing.Size(33, 12);
            this.label_result.TabIndex = 4;
            this.label_result.Text = "label1";
            // 
            // panel_stage1
            // 
            this.panel_stage1.Location = new System.Drawing.Point(500, 34);
            this.panel_stage1.Name = "panel_stage1";
            this.panel_stage1.Size = new System.Drawing.Size(200, 100);
            this.panel_stage1.TabIndex = 5;
            // 
            // panel_stage2
            // 
            this.panel_stage2.Location = new System.Drawing.Point(500, 158);
            this.panel_stage2.Name = "panel_stage2";
            this.panel_stage2.Size = new System.Drawing.Size(200, 100);
            this.panel_stage2.TabIndex = 5;
            // 
            // panel_stage3
            // 
            this.panel_stage3.Location = new System.Drawing.Point(500, 281);
            this.panel_stage3.Name = "panel_stage3";
            this.panel_stage3.Size = new System.Drawing.Size(200, 100);
            this.panel_stage3.TabIndex = 5;
            // 
            // button_continue
            // 
            this.button_continue.Location = new System.Drawing.Point(43, 263);
            this.button_continue.Name = "button_continue";
            this.button_continue.Size = new System.Drawing.Size(122, 135);
            this.button_continue.TabIndex = 6;
            this.button_continue.Text = "button1";
            this.button_continue.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button_continue);
            this.Controls.Add(this.panel_stage3);
            this.Controls.Add(this.panel_stage2);
            this.Controls.Add(this.panel_stage1);
            this.Controls.Add(this.label_result);
            this.Controls.Add(this.button_start);
            this.Controls.Add(this.label_料號);
            this.Controls.Add(this.comboBox_料號);
            this.Name = "Form1";
            this.Text = "TRAY Inspection Control";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_料號;
        private System.Windows.Forms.Label label_料號;
        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.Label label_result;
        private System.Windows.Forms.Panel panel_stage1;
        private System.Windows.Forms.Panel panel_stage2;
        private System.Windows.Forms.Panel panel_stage3;
        private System.Windows.Forms.Button button_continue;
    }
}

