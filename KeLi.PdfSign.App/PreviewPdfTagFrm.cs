using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace KeLi.PdfSign.App
{
    /// <summary>
    /// 预览图纸窗口
    /// </summary>
    public partial class PreviewPdfTagForm : Form
    {
        /// <summary>
        /// 文件路径字典
        /// </summary>
        private readonly Dictionary<string, string> _filePaths;

        /// <summary>
        /// 文件列表
        /// </summary>
        private readonly List<SignFile> _files; 

        /// <summary>
        /// 当前页
        /// </summary>
        private int _currentPage = 1;

        /// <summary>
        /// 页数
        /// </summary>
        private int _pageNum;

        /// <summary>
        /// 初始化预览图纸窗口
        /// </summary>
        public PreviewPdfTagForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 初始化预览图纸窗口
        /// </summary>
        /// <param name="files"></param>
        public PreviewPdfTagForm(List<SignFile> files) : this()
        {
            _files = files;
            _filePaths = new Dictionary<string, string>();

            foreach (var file in files)
                _filePaths.Add(file.SignedPath, Path.GetFileNameWithoutExtension(file.SignedPath));
        }

        /// <summary>
        /// 加载预览图纸窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PreviewPdfTagForm_Load(object sender, EventArgs e)
        {
            _pageNum = _filePaths.Count / 50;
            _pageNum = _filePaths.Count % 50 == 0 ? _pageNum : _pageNum + 1;
            labCurrentPage.Text = _currentPage.ToString();
            labPageNum.Text = _pageNum.ToString();
            LoadImgs(_currentPage);
        }

        /// <summary>
        /// 上一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUp_Click(object sender, EventArgs e)
        {
            if (_filePaths.Count < 50)
                return;

            _currentPage--;
            labCurrentPage.Text = _currentPage.ToString();

            if (_currentPage < 1)
                _currentPage = _pageNum;

            LoadImgs(_currentPage);
        }

        /// <summary>
        /// 下一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_filePaths.Count < 50)
                return;

            _currentPage++;
            labCurrentPage.Text = _currentPage.ToString();

            if (_currentPage > _pageNum)
                _currentPage = 1;

            LoadImgs(_currentPage);
        }

        /// <summary>
        /// 加载指定页图片列表
        /// </summary>
        /// <param name="pageNum"></param>
        private void LoadImgs(int pageNum)
        {
            pnlSign.Controls.Clear();

            var filePaths = _filePaths.Skip((pageNum - 1) * 50).Take(50).ToDictionary(k => k.Key, v => v.Value);

            for (var i = 0; i < filePaths.Count; i++)
            {
                var key = _filePaths.Keys.ToList()[i];
                var item = new PictureBox
                {
                    Text = _filePaths[key],
                    Image = Image.FromFile(key),
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Size = new Size(pnlSign.Width / 2 - 30, pnlSign.Height / 2 - 30),
                    BackColor = Color.LightGray,
                    Tag = key,
                    Parent = pnlSign
                };

                var leftX = pnlSign.Left + 10;
                var leftY = pnlSign.Top + i / 2 * (item.Height + 10 + 12 + 10);
                var rightX = leftX + item.Width + 20;
                var rightY = leftY;

                item.Location = i % 2 == 0 ? new Point(leftX, leftY) : new Point(rightX, rightY);
                item.DoubleClick += DoubleClick;

                var lable = new Label()
                {
                    Text = _filePaths[key],
                    AutoSize = true,
                    Parent = pnlSign
                };

                if (i % 2 == 0)
                {
                    leftX = leftX + (item.Width - lable.Width) / 2;
                    leftY = leftY + item.Height + 10;
                    lable.Location = new Point(leftX, leftY);
                }

                else
                {
                    rightX = rightX + (item.Width - lable.Width) / 2;
                    rightY = rightY + item.Height + 10;
                    lable.Location = new Point(rightX, rightY);
                }
            }
        }

        /// <summary>
        /// 双击图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private new void DoubleClick(object sender, EventArgs e)
        {
            var pbItem = sender as PictureBox;

            if (pbItem != null)
            {
                var index = _filePaths.Keys.ToList().FindIndex(f => f == (string) pbItem.Tag);
                var pdfForm = new AddPdfTagFrm(_files[index]);

                pdfForm.ShowDialog();
            }
        }
    }
}
