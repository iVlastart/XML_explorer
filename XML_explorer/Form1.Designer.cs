namespace XML_explorer
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            toolStrip1 = new ToolStrip();
            toolStripButton1 = new ToolStripButton();
            toolStripButton2 = new ToolStripButton();
            toolStripButton3 = new ToolStripButton();
            filesTreeView = new TreeView();
            lblFilename = new Label();
            lblMaxDepth = new Label();
            lblChildren = new Label();
            lblMinAttrs = new Label();
            lblMaxAttrs = new Label();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripButton1, toolStripButton2, toolStripButton3 });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(800, 27);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButton1.Image = (Image)resources.GetObject("toolStripButton1.Image");
            toolStripButton1.ImageTransparentColor = Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new Size(58, 24);
            toolStripButton1.Text = "Otevřít";
            toolStripButton1.Click += toolStripButton1_Click;
            // 
            // toolStripButton2
            // 
            toolStripButton2.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButton2.Image = (Image)resources.GetObject("toolStripButton2.Image");
            toolStripButton2.ImageTransparentColor = Color.Magenta;
            toolStripButton2.Name = "toolStripButton2";
            toolStripButton2.Size = new Size(52, 24);
            toolStripButton2.Text = "Uložit";
            toolStripButton2.Click += toolStripButton2_Click;
            // 
            // toolStripButton3
            // 
            toolStripButton3.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButton3.Image = (Image)resources.GetObject("toolStripButton3.Image");
            toolStripButton3.ImageTransparentColor = Color.Magenta;
            toolStripButton3.Name = "toolStripButton3";
            toolStripButton3.Size = new Size(51, 24);
            toolStripButton3.Text = "Zavřít";
            toolStripButton3.ToolTipText = "Zavřít";
            toolStripButton3.Click += toolStripButton3_Click;
            // 
            // filesTreeView
            // 
            filesTreeView.Location = new Point(0, 30);
            filesTreeView.Name = "filesTreeView";
            filesTreeView.Size = new Size(184, 419);
            filesTreeView.TabIndex = 1;
            // 
            // lblFilename
            // 
            lblFilename.AutoSize = true;
            lblFilename.Location = new Point(236, 30);
            lblFilename.Name = "lblFilename";
            lblFilename.Size = new Size(0, 20);
            lblFilename.TabIndex = 2;
            // 
            // lblMaxDepth
            // 
            lblMaxDepth.AutoSize = true;
            lblMaxDepth.Location = new Point(236, 62);
            lblMaxDepth.Name = "lblMaxDepth";
            lblMaxDepth.Size = new Size(0, 20);
            lblMaxDepth.TabIndex = 3;
            lblMaxDepth.Click += lblMaxDepth_Click;
            // 
            // lblChildren
            // 
            lblChildren.AutoSize = true;
            lblChildren.Location = new Point(236, 95);
            lblChildren.Name = "lblChildren";
            lblChildren.Size = new Size(0, 20);
            lblChildren.TabIndex = 4;
            // 
            // lblMinAttrs
            // 
            lblMinAttrs.AutoSize = true;
            lblMinAttrs.Location = new Point(236, 124);
            lblMinAttrs.Name = "lblMinAttrs";
            lblMinAttrs.Size = new Size(0, 20);
            lblMinAttrs.TabIndex = 5;
            // 
            // lblMaxAttrs
            // 
            lblMaxAttrs.AutoSize = true;
            lblMaxAttrs.Location = new Point(236, 153);
            lblMaxAttrs.Name = "lblMaxAttrs";
            lblMaxAttrs.Size = new Size(0, 20);
            lblMaxAttrs.TabIndex = 6;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblMaxAttrs);
            Controls.Add(lblMinAttrs);
            Controls.Add(lblChildren);
            Controls.Add(lblMaxDepth);
            Controls.Add(lblFilename);
            Controls.Add(filesTreeView);
            Controls.Add(toolStrip1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButton1;
        private ToolStripButton toolStripButton2;
        private ToolStripButton toolStripButton3;
        private TreeView filesTreeView;
        private Label lblFilename;
        private Label lblMaxDepth;
        private Label lblChildren;
        private Label lblMinAttrs;
        private Label lblMaxAttrs;
    }
}
