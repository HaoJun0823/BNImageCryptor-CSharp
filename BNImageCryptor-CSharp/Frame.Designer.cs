namespace BNImageCryptor_CSharp
{
    partial class Frame
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frame));
            this.btn_Select = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.tb_PW = new System.Windows.Forms.TextBox();
            this.lb_PW = new System.Windows.Forms.Label();
            this.tb_W = new System.Windows.Forms.TextBox();
            this.tb_H = new System.Windows.Forms.TextBox();
            this.lb_W = new System.Windows.Forms.Label();
            this.lb_H = new System.Windows.Forms.Label();
            this.lb_I = new System.Windows.Forms.Label();
            this.rb_D = new System.Windows.Forms.RadioButton();
            this.rb_E = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // btn_Select
            // 
            resources.ApplyResources(this.btn_Select, "btn_Select");
            this.btn_Select.Name = "btn_Select";
            this.btn_Select.UseVisualStyleBackColor = true;
            this.btn_Select.Click += new System.EventHandler(this.btn_Select_Click);
            // 
            // btn_Save
            // 
            resources.ApplyResources(this.btn_Save, "btn_Save");
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // tb_PW
            // 
            resources.ApplyResources(this.tb_PW, "tb_PW");
            this.tb_PW.Name = "tb_PW";
            // 
            // lb_PW
            // 
            resources.ApplyResources(this.lb_PW, "lb_PW");
            this.lb_PW.Name = "lb_PW";
            // 
            // tb_W
            // 
            resources.ApplyResources(this.tb_W, "tb_W");
            this.tb_W.Name = "tb_W";
            this.tb_W.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.number_KeyPress);
            // 
            // tb_H
            // 
            resources.ApplyResources(this.tb_H, "tb_H");
            this.tb_H.Name = "tb_H";
            this.tb_H.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.number_KeyPress);
            // 
            // lb_W
            // 
            resources.ApplyResources(this.lb_W, "lb_W");
            this.lb_W.Name = "lb_W";
            // 
            // lb_H
            // 
            resources.ApplyResources(this.lb_H, "lb_H");
            this.lb_H.Name = "lb_H";
            // 
            // lb_I
            // 
            resources.ApplyResources(this.lb_I, "lb_I");
            this.lb_I.Name = "lb_I";
            // 
            // rb_D
            // 
            resources.ApplyResources(this.rb_D, "rb_D");
            this.rb_D.Name = "rb_D";
            this.rb_D.UseVisualStyleBackColor = true;
            // 
            // rb_E
            // 
            resources.ApplyResources(this.rb_E, "rb_E");
            this.rb_E.Checked = true;
            this.rb_E.Name = "rb_E";
            this.rb_E.TabStop = true;
            this.rb_E.UseVisualStyleBackColor = true;
            // 
            // Frame
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rb_E);
            this.Controls.Add(this.rb_D);
            this.Controls.Add(this.lb_I);
            this.Controls.Add(this.lb_H);
            this.Controls.Add(this.lb_W);
            this.Controls.Add(this.tb_H);
            this.Controls.Add(this.tb_W);
            this.Controls.Add(this.lb_PW);
            this.Controls.Add(this.tb_PW);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.btn_Select);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Frame";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Select;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.TextBox tb_PW;
        private System.Windows.Forms.Label lb_PW;
        private System.Windows.Forms.TextBox tb_W;
        private System.Windows.Forms.TextBox tb_H;
        private System.Windows.Forms.Label lb_W;
        private System.Windows.Forms.Label lb_H;
        private System.Windows.Forms.Label lb_I;
        private System.Windows.Forms.RadioButton rb_D;
        private System.Windows.Forms.RadioButton rb_E;
    }
}

