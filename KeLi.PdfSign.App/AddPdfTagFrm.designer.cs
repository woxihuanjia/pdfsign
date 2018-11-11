namespace KeLi.PdfSign.App
{
    partial class AddPdfTagFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlImg = new System.Windows.Forms.Panel();
            this.pbGeneralOfficeSign = new System.Windows.Forms.PictureBox();
            this.pbTopCode = new System.Windows.Forms.PictureBox();
            this.pbDrawingReviewSign = new System.Windows.Forms.PictureBox();
            this.pbBottomCode = new System.Windows.Forms.PictureBox();
            this.pbImg = new System.Windows.Forms.PictureBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.pnlCtrl = new System.Windows.Forms.Panel();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.pnlImg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbGeneralOfficeSign)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTopCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDrawingReviewSign)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBottomCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImg)).BeginInit();
            this.pnlCtrl.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlImg
            // 
            this.pnlImg.AutoScroll = true;
            this.pnlImg.AutoSize = true;
            this.pnlImg.Controls.Add(this.pbGeneralOfficeSign);
            this.pnlImg.Controls.Add(this.pbTopCode);
            this.pnlImg.Controls.Add(this.pbDrawingReviewSign);
            this.pnlImg.Controls.Add(this.pbBottomCode);
            this.pnlImg.Controls.Add(this.pbImg);
            this.pnlImg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlImg.Location = new System.Drawing.Point(0, 0);
            this.pnlImg.Name = "pnlImg";
            this.pnlImg.Size = new System.Drawing.Size(1221, 846);
            this.pnlImg.TabIndex = 7;
            // 
            // pbGeneralOfficeSign
            // 
            this.pbGeneralOfficeSign.BackColor = System.Drawing.Color.White;
            this.pbGeneralOfficeSign.Image = global::KeLi.PdfSign.App.Properties.Resources.GeneralOffice;
            this.pbGeneralOfficeSign.Location = new System.Drawing.Point(1067, 288);
            this.pbGeneralOfficeSign.Name = "pbGeneralOfficeSign";
            this.pbGeneralOfficeSign.Size = new System.Drawing.Size(135, 80);
            this.pbGeneralOfficeSign.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbGeneralOfficeSign.TabIndex = 6;
            this.pbGeneralOfficeSign.TabStop = false;
            // 
            // pbTopCode
            // 
            this.pbTopCode.Image = global::KeLi.PdfSign.App.Properties.Resources.QrCode;
            this.pbTopCode.Location = new System.Drawing.Point(1121, 12);
            this.pbTopCode.Name = "pbTopCode";
            this.pbTopCode.Size = new System.Drawing.Size(80, 80);
            this.pbTopCode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbTopCode.TabIndex = 3;
            this.pbTopCode.TabStop = false;
            // 
            // pbDrawingReviewSign
            // 
            this.pbDrawingReviewSign.Image = global::KeLi.PdfSign.App.Properties.Resources.DrawingReview;
            this.pbDrawingReviewSign.Location = new System.Drawing.Point(1049, 465);
            this.pbDrawingReviewSign.Name = "pbDrawingReviewSign";
            this.pbDrawingReviewSign.Size = new System.Drawing.Size(152, 92);
            this.pbDrawingReviewSign.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbDrawingReviewSign.TabIndex = 5;
            this.pbDrawingReviewSign.TabStop = false;
            // 
            // pbBottomCode
            // 
            this.pbBottomCode.Image = global::KeLi.PdfSign.App.Properties.Resources.QrCode;
            this.pbBottomCode.Location = new System.Drawing.Point(1121, 709);
            this.pbBottomCode.Name = "pbBottomCode";
            this.pbBottomCode.Size = new System.Drawing.Size(80, 80);
            this.pbBottomCode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbBottomCode.TabIndex = 4;
            this.pbBottomCode.TabStop = false;
            // 
            // pbImg
            // 
            this.pbImg.BackColor = System.Drawing.Color.LightSeaGreen;
            this.pbImg.Location = new System.Drawing.Point(0, 0);
            this.pbImg.Name = "pbImg";
            this.pbImg.Size = new System.Drawing.Size(1221, 845);
            this.pbImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImg.TabIndex = 0;
            this.pbImg.TabStop = false;
            this.pbImg.Tag = "ImgTag";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(21, 69);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.TabStop = false;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // pnlCtrl
            // 
            this.pnlCtrl.Controls.Add(this.btnLoad);
            this.pnlCtrl.Controls.Add(this.btnTest);
            this.pnlCtrl.Controls.Add(this.btnUp);
            this.pnlCtrl.Controls.Add(this.btnNext);
            this.pnlCtrl.Controls.Add(this.btnSave);
            this.pnlCtrl.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlCtrl.Location = new System.Drawing.Point(1221, 0);
            this.pnlCtrl.Name = "pnlCtrl";
            this.pnlCtrl.Size = new System.Drawing.Size(120, 846);
            this.pnlCtrl.TabIndex = 8;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(21, 23);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 6;
            this.btnLoad.TabStop = false;
            this.btnLoad.Text = "加载";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(21, 228);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 5;
            this.btnTest.TabStop = false;
            this.btnTest.Text = "图签";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnUp
            // 
            this.btnUp.Location = new System.Drawing.Point(21, 121);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(75, 23);
            this.btnUp.TabIndex = 4;
            this.btnUp.TabStop = false;
            this.btnUp.Text = "上一张";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(21, 177);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 3;
            this.btnNext.TabStop = false;
            this.btnNext.Text = "下一张";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // AddPdfTagFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1341, 846);
            this.Controls.Add(this.pnlImg);
            this.Controls.Add(this.pnlCtrl);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1357, 885);
            this.MinimizeBox = false;
            this.Name = "AddPdfTagFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设置图签";
            this.Load += new System.EventHandler(this.AddPdfTagForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AddPdfTagForm_KeyDown);
            this.pnlImg.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbGeneralOfficeSign)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTopCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDrawingReviewSign)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBottomCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImg)).EndInit();
            this.pnlCtrl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbImg;
        private System.Windows.Forms.Panel pnlImg;
        private System.Windows.Forms.PictureBox pbDrawingReviewSign;
        private System.Windows.Forms.PictureBox pbBottomCode;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel pnlCtrl;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.PictureBox pbTopCode;
        private System.Windows.Forms.PictureBox pbGeneralOfficeSign;
        private System.Windows.Forms.Button btnLoad;
    }
}