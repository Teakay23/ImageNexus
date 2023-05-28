namespace ImageNexus
{
    partial class Display
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
            mainFormPanel = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            previousButton = new ReaLTaiizor.Controls.SocialButton();
            nextButton = new ReaLTaiizor.Controls.SocialButton();
            mainPictureBox = new ReaLTaiizor.Controls.HopePictureBox();
            imageNameLabel = new ReaLTaiizor.Controls.DungeonLabel();
            thumbnailPanel = new FlowLayoutPanel();
            mainFormPanel.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)mainPictureBox).BeginInit();
            SuspendLayout();
            // 
            // mainFormPanel
            // 
            mainFormPanel.BackColor = Color.Black;
            mainFormPanel.Controls.Add(tableLayoutPanel1);
            mainFormPanel.Dock = DockStyle.Fill;
            mainFormPanel.Location = new Point(0, 0);
            mainFormPanel.Name = "mainFormPanel";
            mainFormPanel.Size = new Size(800, 557);
            mainFormPanel.TabIndex = 9;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.Transparent;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 0);
            tableLayoutPanel1.Controls.Add(imageNameLabel, 0, 1);
            tableLayoutPanel1.Controls.Add(thumbnailPanel, 0, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 130F));
            tableLayoutPanel1.Size = new Size(800, 557);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 7.5F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 85F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 7.5F));
            tableLayoutPanel2.Controls.Add(previousButton, 0, 0);
            tableLayoutPanel2.Controls.Add(nextButton, 2, 0);
            tableLayoutPanel2.Controls.Add(mainPictureBox, 1, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Size = new Size(794, 401);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // previousButton
            // 
            previousButton.Anchor = AnchorStyles.Left;
            previousButton.BackgroundImage = Properties.Resources.arrow_symbol_opposite;
            previousButton.DownEllipseColor = Color.FromArgb(153, 34, 34);
            previousButton.HoverEllipseColor = Color.FromArgb(32, 34, 37);
            previousButton.Image = Properties.Resources.arrow_symbol_opposite;
            previousButton.Location = new Point(3, 173);
            previousButton.Name = "previousButton";
            previousButton.NormalEllipseColor = Color.FromArgb(66, 76, 85);
            previousButton.Size = new Size(54, 54);
            previousButton.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            previousButton.TabIndex = 0;
            previousButton.Click += previousButton_Click;
            // 
            // nextButton
            // 
            nextButton.Anchor = AnchorStyles.Right;
            nextButton.BackgroundImage = Properties.Resources.arrow_symbol3;
            nextButton.DownEllipseColor = Color.FromArgb(153, 34, 34);
            nextButton.HoverEllipseColor = Color.FromArgb(32, 34, 37);
            nextButton.Image = Properties.Resources.arrow_symbol3;
            nextButton.Location = new Point(737, 173);
            nextButton.Name = "nextButton";
            nextButton.NormalEllipseColor = Color.FromArgb(66, 76, 85);
            nextButton.Size = new Size(54, 54);
            nextButton.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            nextButton.TabIndex = 1;
            nextButton.Click += nextButton_Click;
            // 
            // mainPictureBox
            // 
            mainPictureBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            mainPictureBox.BackColor = Color.FromArgb(192, 196, 204);
            mainPictureBox.BorderStyle = BorderStyle.Fixed3D;
            mainPictureBox.Image = Properties.Resources.image_not_found_icon;
            mainPictureBox.Location = new Point(62, 3);
            mainPictureBox.Name = "mainPictureBox";
            mainPictureBox.PixelOffsetType = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            mainPictureBox.Size = new Size(668, 395);
            mainPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            mainPictureBox.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            mainPictureBox.TabIndex = 2;
            mainPictureBox.TabStop = false;
            mainPictureBox.TextRenderingType = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            // 
            // imageNameLabel
            // 
            imageNameLabel.Anchor = AnchorStyles.None;
            imageNameLabel.AutoSize = true;
            imageNameLabel.BackColor = Color.Transparent;
            imageNameLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            imageNameLabel.ForeColor = Color.FromArgb(76, 76, 77);
            imageNameLabel.Location = new Point(351, 408);
            imageNameLabel.Name = "imageNameLabel";
            imageNameLabel.Size = new Size(98, 17);
            imageNameLabel.TabIndex = 2;
            imageNameLabel.Text = "dungeonLabel1";
            // 
            // thumbnailPanel
            // 
            thumbnailPanel.Dock = DockStyle.Fill;
            thumbnailPanel.Location = new Point(3, 430);
            thumbnailPanel.Name = "thumbnailPanel";
            thumbnailPanel.Padding = new Padding(5, 0, 0, 0);
            thumbnailPanel.Size = new Size(794, 124);
            thumbnailPanel.TabIndex = 3;
            // 
            // Display
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 557);
            Controls.Add(mainFormPanel);
            KeyPreview = true;
            MinimumSize = new Size(816, 596);
            Name = "Display";
            Text = "ImageNexus";
            KeyDown += Display_KeyDown;
            Resize += Display_Resize;
            mainFormPanel.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)mainPictureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel mainFormPanel;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private ReaLTaiizor.Controls.DungeonLabel imageNameLabel;
        private ReaLTaiizor.Controls.SocialButton previousButton;
        private ReaLTaiizor.Controls.SocialButton nextButton;
        private ReaLTaiizor.Controls.HopePictureBox mainPictureBox;
        private FlowLayoutPanel thumbnailPanel;
    }
}