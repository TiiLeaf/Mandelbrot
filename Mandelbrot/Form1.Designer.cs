namespace Mandelbrot
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
            this.canvas = new System.Windows.Forms.PictureBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.renderTimeLabel = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.bitmapStitchingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.multithreadedReducedCameraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.multithreadedOptimizedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.multithreadedDoublesOnlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.multithreadedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reducedCameraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.singlethreadedOptimizedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.doublesOnlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.singlethreadedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.singlethreadedFinalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.multithreadedFinalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.threadpoolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bitmapStitchingThreadpoolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // canvas
            // 
            this.canvas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.canvas.Location = new System.Drawing.Point(0, 27);
            this.canvas.Margin = new System.Windows.Forms.Padding(0);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(512, 512);
            this.canvas.TabIndex = 0;
            this.canvas.TabStop = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripSeparator1,
            this.toolStripLabel2,
            this.toolStripButton3,
            this.toolStripButton4,
            this.toolStripButton5,
            this.toolStripButton6});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(512, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(42, 22);
            this.toolStripLabel1.Text = "Zoom:";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "+";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "-";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(30, 22);
            this.toolStripLabel2.Text = "Pan:";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "<";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton4.Text = ">";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton5.Text = "^";
            this.toolStripButton5.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton6.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton6.Image")));
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton6.Text = "v";
            this.toolStripButton6.Click += new System.EventHandler(this.toolStripButton6_Click);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.renderTimeLabel,
            this.toolStripSeparator2,
            this.toolStripDropDownButton1,
            this.toolStripDropDownButton2});
            this.toolStrip2.Location = new System.Drawing.Point(0, 541);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(512, 25);
            this.toolStrip2.TabIndex = 2;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // renderTimeLabel
            // 
            this.renderTimeLabel.Name = "renderTimeLabel";
            this.renderTimeLabel.Size = new System.Drawing.Size(101, 22);
            this.renderTimeLabel.Text = "Render Time: 0ms";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bitmapStitchingToolStripMenuItem,
            this.multithreadedReducedCameraToolStripMenuItem,
            this.multithreadedOptimizedToolStripMenuItem,
            this.multithreadedDoublesOnlyToolStripMenuItem,
            this.multithreadedToolStripMenuItem,
            this.reducedCameraToolStripMenuItem,
            this.singlethreadedOptimizedToolStripMenuItem,
            this.doublesOnlyToolStripMenuItem,
            this.singlethreadedToolStripMenuItem,
            this.singlethreadedFinalToolStripMenuItem,
            this.multithreadedFinalToolStripMenuItem,
            this.threadpoolToolStripMenuItem,
            this.bitmapStitchingThreadpoolToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(137, 22);
            this.toolStripDropDownButton1.Text = "Single-threaded Naive";
            this.toolStripDropDownButton1.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStripDropDownButton1_DropDownItemClicked);
            // 
            // bitmapStitchingToolStripMenuItem
            // 
            this.bitmapStitchingToolStripMenuItem.Name = "bitmapStitchingToolStripMenuItem";
            this.bitmapStitchingToolStripMenuItem.Size = new System.Drawing.Size(260, 22);
            this.bitmapStitchingToolStripMenuItem.Text = "Bitmap Stitching";
            // 
            // multithreadedReducedCameraToolStripMenuItem
            // 
            this.multithreadedReducedCameraToolStripMenuItem.Name = "multithreadedReducedCameraToolStripMenuItem";
            this.multithreadedReducedCameraToolStripMenuItem.Size = new System.Drawing.Size(260, 22);
            this.multithreadedReducedCameraToolStripMenuItem.Text = "Multi-threaded Reduced Camera";
            // 
            // multithreadedOptimizedToolStripMenuItem
            // 
            this.multithreadedOptimizedToolStripMenuItem.Name = "multithreadedOptimizedToolStripMenuItem";
            this.multithreadedOptimizedToolStripMenuItem.Size = new System.Drawing.Size(260, 22);
            this.multithreadedOptimizedToolStripMenuItem.Text = "Multi-threaded Algebra Optimized";
            // 
            // multithreadedDoublesOnlyToolStripMenuItem
            // 
            this.multithreadedDoublesOnlyToolStripMenuItem.Name = "multithreadedDoublesOnlyToolStripMenuItem";
            this.multithreadedDoublesOnlyToolStripMenuItem.Size = new System.Drawing.Size(260, 22);
            this.multithreadedDoublesOnlyToolStripMenuItem.Text = "Multi-threaded Doubles";
            // 
            // multithreadedToolStripMenuItem
            // 
            this.multithreadedToolStripMenuItem.Name = "multithreadedToolStripMenuItem";
            this.multithreadedToolStripMenuItem.Size = new System.Drawing.Size(260, 22);
            this.multithreadedToolStripMenuItem.Text = "Multi-threaded Naive";
            // 
            // reducedCameraToolStripMenuItem
            // 
            this.reducedCameraToolStripMenuItem.Name = "reducedCameraToolStripMenuItem";
            this.reducedCameraToolStripMenuItem.Size = new System.Drawing.Size(260, 22);
            this.reducedCameraToolStripMenuItem.Text = "Reduced Camera";
            // 
            // singlethreadedOptimizedToolStripMenuItem
            // 
            this.singlethreadedOptimizedToolStripMenuItem.Name = "singlethreadedOptimizedToolStripMenuItem";
            this.singlethreadedOptimizedToolStripMenuItem.Size = new System.Drawing.Size(260, 22);
            this.singlethreadedOptimizedToolStripMenuItem.Text = "Single-threaded Algebra Optimized";
            // 
            // doublesOnlyToolStripMenuItem
            // 
            this.doublesOnlyToolStripMenuItem.Name = "doublesOnlyToolStripMenuItem";
            this.doublesOnlyToolStripMenuItem.Size = new System.Drawing.Size(260, 22);
            this.doublesOnlyToolStripMenuItem.Text = "Doubles Only";
            // 
            // singlethreadedToolStripMenuItem
            // 
            this.singlethreadedToolStripMenuItem.Name = "singlethreadedToolStripMenuItem";
            this.singlethreadedToolStripMenuItem.Size = new System.Drawing.Size(260, 22);
            this.singlethreadedToolStripMenuItem.Text = "Single-threaded Naive";
            // 
            // singlethreadedFinalToolStripMenuItem
            // 
            this.singlethreadedFinalToolStripMenuItem.Name = "singlethreadedFinalToolStripMenuItem";
            this.singlethreadedFinalToolStripMenuItem.Size = new System.Drawing.Size(260, 22);
            this.singlethreadedFinalToolStripMenuItem.Text = "Single-threaded Final";
            // 
            // multithreadedFinalToolStripMenuItem
            // 
            this.multithreadedFinalToolStripMenuItem.Name = "multithreadedFinalToolStripMenuItem";
            this.multithreadedFinalToolStripMenuItem.Size = new System.Drawing.Size(260, 22);
            this.multithreadedFinalToolStripMenuItem.Text = "Multi-threaded Final";
            // 
            // threadpoolToolStripMenuItem
            // 
            this.threadpoolToolStripMenuItem.Name = "threadpoolToolStripMenuItem";
            this.threadpoolToolStripMenuItem.Size = new System.Drawing.Size(260, 22);
            this.threadpoolToolStripMenuItem.Text = "Threadpool";
            // 
            // bitmapStitchingThreadpoolToolStripMenuItem
            // 
            this.bitmapStitchingThreadpoolToolStripMenuItem.Name = "bitmapStitchingThreadpoolToolStripMenuItem";
            this.bitmapStitchingThreadpoolToolStripMenuItem.Size = new System.Drawing.Size(260, 22);
            this.bitmapStitchingThreadpoolToolStripMenuItem.Text = "Bitmap Stitching Threadpool";
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem8,
            this.toolStripMenuItem7,
            this.toolStripMenuItem6,
            this.toolStripMenuItem9,
            this.toolStripMenuItem5,
            this.toolStripMenuItem10,
            this.toolStripMenuItem4,
            this.toolStripMenuItem3,
            this.toolStripMenuItem2});
            this.toolStripDropDownButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton2.Image")));
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(26, 22);
            this.toolStripDropDownButton2.Text = "5";
            this.toolStripDropDownButton2.ToolTipText = "Thread Count";
            this.toolStripDropDownButton2.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStripDropDownButton2_DropDownItemClicked);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem8.Text = "16";
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem7.Text = "12";
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem6.Text = "8";
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem9.Text = "7";
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem5.Text = "6";
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem10.Text = "5";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem4.Text = "4";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem3.Text = "2";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem2.Text = "1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 566);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.canvas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Mandelbrot Explorer";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox canvas;
        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButton1;
        private ToolStripButton toolStripButton2;
        private ToolStripButton toolStripButton3;
        private ToolStripButton toolStripButton4;
        private ToolStripButton toolStripButton5;
        private ToolStripButton toolStripButton6;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripLabel toolStripLabel1;
        private ToolStripLabel toolStripLabel2;
        private ToolStrip toolStrip2;
        private ToolStripLabel renderTimeLabel;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripDropDownButton toolStripDropDownButton1;
        private ToolStripMenuItem bitmapStitchingToolStripMenuItem;
        private ToolStripMenuItem multithreadedToolStripMenuItem;
        private ToolStripMenuItem singlethreadedToolStripMenuItem;
        private ToolStripMenuItem doublesOnlyToolStripMenuItem;
        private ToolStripMenuItem multithreadedDoublesOnlyToolStripMenuItem;
        private ToolStripMenuItem multithreadedOptimizedToolStripMenuItem;
        private ToolStripMenuItem singlethreadedOptimizedToolStripMenuItem;
        private ToolStripDropDownButton toolStripDropDownButton2;
        private ToolStripMenuItem toolStripMenuItem8;
        private ToolStripMenuItem toolStripMenuItem7;
        private ToolStripMenuItem toolStripMenuItem6;
        private ToolStripMenuItem toolStripMenuItem5;
        private ToolStripMenuItem toolStripMenuItem4;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem toolStripMenuItem9;
        private ToolStripMenuItem reducedCameraToolStripMenuItem;
        private ToolStripMenuItem multithreadedReducedCameraToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem10;
        private ToolStripMenuItem singlethreadedFinalToolStripMenuItem;
        private ToolStripMenuItem multithreadedFinalToolStripMenuItem;
        private ToolStripMenuItem threadpoolToolStripMenuItem;
        private ToolStripMenuItem bitmapStitchingThreadpoolToolStripMenuItem;
    }
}