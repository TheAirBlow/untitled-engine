
namespace TheAirBlow.Engine.Standalone
{
    partial class MainMenu
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.newProjectButton = new System.Windows.Forms.ToolStripButton();
            this.openProjectButton = new System.Windows.Forms.ToolStripButton();
            this.saveProjectButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutButton = new System.Windows.Forms.ToolStripButton();
            this.objectsButton = new System.Windows.Forms.Button();
            this.roomsButton = new System.Windows.Forms.Button();
            this.soundsButton = new System.Windows.Forms.Button();
            this.runButton = new System.Windows.Forms.Button();
            this.compileButton = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(62)))), ((int)(((byte)(70)))));
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newProjectButton,
            this.openProjectButton,
            this.saveProjectButton,
            this.toolStripSeparator2,
            this.aboutButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1283, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // newProjectButton
            // 
            this.newProjectButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newProjectButton.Image = ((System.Drawing.Image)(resources.GetObject("newProjectButton.Image")));
            this.newProjectButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newProjectButton.Name = "newProjectButton";
            this.newProjectButton.Size = new System.Drawing.Size(29, 24);
            this.newProjectButton.Text = "New project";
            this.newProjectButton.Click += new System.EventHandler(this.newProjectButton_Click);
            // 
            // openProjectButton
            // 
            this.openProjectButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openProjectButton.Image = ((System.Drawing.Image)(resources.GetObject("openProjectButton.Image")));
            this.openProjectButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openProjectButton.Name = "openProjectButton";
            this.openProjectButton.Size = new System.Drawing.Size(29, 24);
            this.openProjectButton.Text = "Open project...";
            this.openProjectButton.Click += new System.EventHandler(this.openProjectButton_Click);
            // 
            // saveProjectButton
            // 
            this.saveProjectButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveProjectButton.Image = ((System.Drawing.Image)(resources.GetObject("saveProjectButton.Image")));
            this.saveProjectButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveProjectButton.Name = "saveProjectButton";
            this.saveProjectButton.Size = new System.Drawing.Size(29, 24);
            this.saveProjectButton.Text = "Save project...";
            this.saveProjectButton.Click += new System.EventHandler(this.saveProjectButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // aboutButton
            // 
            this.aboutButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.aboutButton.Image = ((System.Drawing.Image)(resources.GetObject("aboutButton.Image")));
            this.aboutButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.aboutButton.Name = "aboutButton";
            this.aboutButton.Size = new System.Drawing.Size(29, 24);
            this.aboutButton.Text = "About";
            this.aboutButton.Click += new System.EventHandler(this.aboutButton_Click);
            // 
            // objectsButton
            // 
            this.objectsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(173)))), ((int)(((byte)(181)))));
            this.objectsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.objectsButton.ForeColor = System.Drawing.Color.Black;
            this.objectsButton.Location = new System.Drawing.Point(6, 21);
            this.objectsButton.Name = "objectsButton";
            this.objectsButton.Size = new System.Drawing.Size(93, 33);
            this.objectsButton.TabIndex = 1;
            this.objectsButton.Text = "Objects...";
            this.objectsButton.UseVisualStyleBackColor = false;
            this.objectsButton.Click += new System.EventHandler(this.objectsButton_Click);
            // 
            // roomsButton
            // 
            this.roomsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(173)))), ((int)(((byte)(181)))));
            this.roomsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roomsButton.ForeColor = System.Drawing.Color.Black;
            this.roomsButton.Location = new System.Drawing.Point(105, 21);
            this.roomsButton.Name = "roomsButton";
            this.roomsButton.Size = new System.Drawing.Size(93, 33);
            this.roomsButton.TabIndex = 2;
            this.roomsButton.Text = "Rooms...";
            this.roomsButton.UseVisualStyleBackColor = false;
            this.roomsButton.Click += new System.EventHandler(this.roomsButton_Click);
            // 
            // soundsButton
            // 
            this.soundsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(173)))), ((int)(((byte)(181)))));
            this.soundsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.soundsButton.ForeColor = System.Drawing.Color.Black;
            this.soundsButton.Location = new System.Drawing.Point(204, 21);
            this.soundsButton.Name = "soundsButton";
            this.soundsButton.Size = new System.Drawing.Size(93, 33);
            this.soundsButton.TabIndex = 3;
            this.soundsButton.Text = "Sounds...";
            this.soundsButton.UseVisualStyleBackColor = false;
            this.soundsButton.Click += new System.EventHandler(this.soundsButton_Click);
            // 
            // runButton
            // 
            this.runButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(173)))), ((int)(((byte)(181)))));
            this.runButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.runButton.ForeColor = System.Drawing.Color.Black;
            this.runButton.Location = new System.Drawing.Point(106, 21);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(76, 33);
            this.runButton.TabIndex = 4;
            this.runButton.Text = "Run...";
            this.runButton.UseVisualStyleBackColor = false;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // compileButton
            // 
            this.compileButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(173)))), ((int)(((byte)(181)))));
            this.compileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.compileButton.ForeColor = System.Drawing.Color.Black;
            this.compileButton.Location = new System.Drawing.Point(9, 21);
            this.compileButton.Name = "compileButton";
            this.compileButton.Size = new System.Drawing.Size(91, 33);
            this.compileButton.TabIndex = 5;
            this.compileButton.Text = "Compile...";
            this.compileButton.UseVisualStyleBackColor = false;
            this.compileButton.Click += new System.EventHandler(this.compileButton_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(62)))), ((int)(((byte)(70)))));
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(313, 674);
            this.panel1.TabIndex = 11;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.compileButton);
            this.groupBox2.Controls.Add(this.runButton);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(3, 69);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(307, 62);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Compiling";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.objectsButton);
            this.groupBox1.Controls.Add(this.soundsButton);
            this.groupBox1.Controls.Add(this.roomsButton);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(307, 60);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Menus";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label2.Location = new System.Drawing.Point(0, 637);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(50, 0, 0, 20);
            this.label2.Size = new System.Drawing.Size(252, 37);
            this.label2.TabIndex = 9;
            this.label2.Text = "Copyright (C) TheAirBlow 2021";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkBox1);
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Location = new System.Drawing.Point(3, 137);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(307, 51);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Settings";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(10, 22);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(111, 21);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "Show Splash";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // MainMenu
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(40)))), ((int)(((byte)(49)))));
            this.ClientSize = new System.Drawing.Size(1283, 701);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "MainMenu";
            this.Text = "Untitled Engine";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton newProjectButton;
        private System.Windows.Forms.ToolStripButton openProjectButton;
        private System.Windows.Forms.ToolStripButton saveProjectButton;
        private System.Windows.Forms.ToolStripButton aboutButton;
        private System.Windows.Forms.Button objectsButton;
        private System.Windows.Forms.Button roomsButton;
        private System.Windows.Forms.Button soundsButton;
        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.Button compileButton;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

