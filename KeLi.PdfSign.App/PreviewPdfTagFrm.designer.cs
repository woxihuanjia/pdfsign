namespace KeLi.PdfSign.App
{
    partial class PreviewPdfTagForm
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
            this.components = new System.ComponentModel.Container();
            this.imgSign = new System.Windows.Forms.ImageList(this.components);
            this.pnlSign = new System.Windows.Forms.Panel();
            this.tlpCtrl = new System.Windows.Forms.TableLayoutPanel();
            this.labConn = new System.Windows.Forms.Label();
            this.labPageNum = new System.Windows.Forms.Label();
            this.labCurrentPage = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.tlpCtrl.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // imgSign
            // 
            this.imgSign.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imgSign.ImageSize = new System.Drawing.Size(256, 256);
            this.imgSign.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // pnlSign
            // 
            this.pnlSign.AutoScroll = true;
            this.pnlSign.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSign.Location = new System.Drawing.Point(0, 0);
            this.pnlSign.Name = "pnlSign";
            this.pnlSign.Size = new System.Drawing.Size(919, 714);
            this.pnlSign.TabIndex = 0;
            // 
            // tlpCtrl
            // 
            this.tlpCtrl.ColumnCount = 2;
            this.tlpCtrl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCtrl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCtrl.Controls.Add(this.pnlRight, 1, 0);
            this.tlpCtrl.Controls.Add(this.btnUp, 0, 0);
            this.tlpCtrl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tlpCtrl.Location = new System.Drawing.Point(0, 664);
            this.tlpCtrl.Name = "tlpCtrl";
            this.tlpCtrl.RowCount = 1;
            this.tlpCtrl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCtrl.Size = new System.Drawing.Size(919, 50);
            this.tlpCtrl.TabIndex = 5;
            // 
            // labConn
            // 
            this.labConn.AutoSize = true;
            this.labConn.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labConn.Location = new System.Drawing.Point(97, 14);
            this.labConn.Name = "labConn";
            this.labConn.Size = new System.Drawing.Size(16, 16);
            this.labConn.TabIndex = 4;
            this.labConn.Text = "-";
            // 
            // labPageNum
            // 
            this.labPageNum.AutoSize = true;
            this.labPageNum.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labPageNum.Location = new System.Drawing.Point(107, 14);
            this.labPageNum.Name = "labPageNum";
            this.labPageNum.Size = new System.Drawing.Size(24, 16);
            this.labPageNum.TabIndex = 3;
            this.labPageNum.Text = "10";
            // 
            // labCurrentPage
            // 
            this.labCurrentPage.AutoSize = true;
            this.labCurrentPage.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labCurrentPage.Location = new System.Drawing.Point(85, 14);
            this.labCurrentPage.Name = "labCurrentPage";
            this.labCurrentPage.Size = new System.Drawing.Size(16, 16);
            this.labCurrentPage.TabIndex = 2;
            this.labCurrentPage.Text = "1";
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(3, 10);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 1;
            this.btnNext.Text = "下一页";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnUp
            // 
            this.btnUp.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnUp.Location = new System.Drawing.Point(381, 13);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(75, 23);
            this.btnUp.TabIndex = 0;
            this.btnUp.Text = "上一页";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // pnlRight
            // 
            this.pnlRight.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pnlRight.Controls.Add(this.btnNext);
            this.pnlRight.Controls.Add(this.labCurrentPage);
            this.pnlRight.Controls.Add(this.labConn);
            this.pnlRight.Controls.Add(this.labPageNum);
            this.pnlRight.Location = new System.Drawing.Point(462, 3);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(200, 44);
            this.pnlRight.TabIndex = 6;
            // 
            // PreviewPdfTagForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(919, 714);
            this.Controls.Add(this.tlpCtrl);
            this.Controls.Add(this.pnlSign);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PreviewPdfTagForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "预览图签";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PreviewPdfTagForm_Load);
            this.tlpCtrl.ResumeLayout(false);
            this.pnlRight.ResumeLayout(false);
            this.pnlRight.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ImageList imgSign;
        private System.Windows.Forms.Panel pnlSign;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label labPageNum;
        private System.Windows.Forms.Label labCurrentPage;
        private System.Windows.Forms.Label labConn;
        private System.Windows.Forms.TableLayoutPanel tlpCtrl;
        private System.Windows.Forms.Panel pnlRight;
    }
}