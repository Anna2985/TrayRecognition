
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
            this.SuspendLayout();
            // 
            // comboBox_料號
            // 
            this.comboBox_料號.Font = new System.Drawing.Font("微軟正黑體", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.comboBox_料號.FormattingEnabled = true;
            this.comboBox_料號.ItemHeight = 40;
            this.comboBox_料號.Location = new System.Drawing.Point(120, 99);
            this.comboBox_料號.Name = "comboBox_料號";
            this.comboBox_料號.Size = new System.Drawing.Size(155, 48);
            this.comboBox_料號.TabIndex = 0;
            // 
            // label_料號
            // 
            this.label_料號.AutoSize = true;
            this.label_料號.Font = new System.Drawing.Font("微軟正黑體", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_料號.Location = new System.Drawing.Point(33, 102);
            this.label_料號.Name = "label_料號";
            this.label_料號.Size = new System.Drawing.Size(81, 40);
            this.label_料號.TabIndex = 1;
            this.label_料號.Text = "料號";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
    }
}

