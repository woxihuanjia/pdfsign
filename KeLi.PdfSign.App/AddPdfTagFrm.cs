using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using KeLi.KData.KFile;
using KeLi.PdfSign.App.Properties;
using File = System.IO.File;
using Image = System.Drawing.Image;

namespace KeLi.PdfSign.App
{
    /// <summary>
    /// 设置图签
    /// </summary>
    public partial class AddPdfTagFrm : Form
    {
        /// <summary>
        /// 是否按下鼠标左键
        /// </summary>
        private bool _isDown;

        /// <summary>
        /// 鼠标指针位置
        /// </summary>
        private Point _mousePoint;

        /// <summary>
        /// 图片位置
        /// </summary>
        private Point _imgPoint;

        /// <summary>
        /// 当前图片
        /// </summary>
        private Image _img;

        /// <summary>
        /// PDF文件路径集
        /// </summary>
        private List<string> _pdfPaths;

        /// <summary>
        /// PDF文件路径集当前索引
        /// </summary>
        private int _index;

        /// <summary>
        /// 顶部二维码坐标
        /// </summary>
        private List<double> _topCode = new List<double> { 0.9, 0.1 };

        /// <summary>
        /// 总工室审图章坐标
        /// </summary>
        private List<double> _generalSign = new List<double> { 0.9, 0.5 };

        /// <summary>
        /// 图纸审核专用章坐标
        /// </summary>
        private List<double> _drawingSign = new List<double> { 0.9, 0.2 };

        /// <summary>
        /// 底部二维码坐标
        /// </summary>
        private List<double> _bottomCode = new List<double> { 0.9, 0.9 };

        /// <summary>
        /// 文件路径列表
        /// </summary>
        private List<SignFile> _files;

        /// <summary>
        /// 图片到控件缩放比例
        /// </summary>
        private double _imgScale;

        /// <summary>
        /// PDF到图片的缩放比例
        /// </summary>
        private double _pdfScale;

        /// <summary>
        /// 当前文件对象
        /// </summary>
        private readonly SignFile _file;

        /// <summary>
        /// 初始化设置图签
        /// </summary>
        public AddPdfTagFrm()
        {
            InitializeComponent();
            pbTopCode.MouseDown += MouseDown;
            pbTopCode.MouseMove += MouseMove;
            pbTopCode.MouseUp += MouseUp;
            pbBottomCode.MouseDown += MouseDown;
            pbBottomCode.MouseMove += MouseMove;
            pbBottomCode.MouseUp += MouseUp;
            pbDrawingReviewSign.MouseDown += MouseDown;
            pbDrawingReviewSign.MouseMove += MouseMove;
            pbDrawingReviewSign.MouseUp += MouseUp;
            pbGeneralOfficeSign.MouseDown += MouseDown;
            pbGeneralOfficeSign.MouseMove += MouseMove;
            pbGeneralOfficeSign.MouseUp += MouseUp;
            pbTopCode.Click += SetPictureBackColor;
            pbBottomCode.Click += SetPictureBackColor;
            pbDrawingReviewSign.Click += SetPictureBackColor;
            pbGeneralOfficeSign.Click += SetPictureBackColor;
            btnSave.Enabled = false;
            btnUp.TabStop = false;
            btnNext.TabStop = false;
            btnSave.TabStop = false;
            KeyPreview = true;
        }

        /// <summary>
        /// 初始化设置图签
        /// </summary>
        /// <param name="file"></param>
        public AddPdfTagFrm(SignFile file) : this()
        {
            if (file == null)
                return;

            _file = file;
            btnUp.Visible = false;
            btnNext.Visible = false;
        }

        /// <summary>
        /// 初始化设置图签
        /// </summary>
        /// <param name="files"></param>
        /// <param name="index"></param>
        public AddPdfTagFrm(List<SignFile> files, int index) : this()
        {
            if (files == null || files.Count == 0)
                return;

            _files = files;
            _index = index;
            _pdfPaths = files.Select(s => s.OldPath).Where(File.Exists).ToList();
        }

        /// <summary>
        /// 加载设置图签
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddPdfTagForm_Load(object sender, EventArgs e)
        {
            if (_file == null && (_pdfPaths == null || _pdfPaths.Count == 0))
            {
                btnUp.Enabled = false;
                btnNext.Enabled = false;
                return;
            }

            btnUp.Enabled = true;
            btnNext.Enabled = true;

            // 记录初始数据，防止多次缩放控件大小
            SetCtrlTag();

            UpdateData();
        }

        /// <summary>
        /// 按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddPdfTagForm_KeyDown(object sender, KeyEventArgs e)
        {
            var picBox = GetPictureBoxes().FirstOrDefault(w => w.BackColor == Color.Blue);

            if (picBox == null)
                return;

            _imgPoint = picBox.Location;

            switch (e.KeyCode)
            {
                case Keys.Up:
                    picBox.Location = new Point(_imgPoint.X, _imgPoint.Y - 1);
                    btnSave.Enabled = true;
                    break;
                case Keys.Down:
                    picBox.Location = new Point(_imgPoint.X, _imgPoint.Y + 1);
                    btnSave.Enabled = true;
                    break;
                case Keys.Left:
                    picBox.Location = new Point(_imgPoint.X - 1, _imgPoint.Y);
                    btnSave.Enabled = true;
                    break;
                case Keys.Right:
                    picBox.Location = new Point(_imgPoint.X + 1, _imgPoint.Y);
                    btnSave.Enabled = true;
                    break;
            }
        }

        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoad_Click(object sender, EventArgs e)
        {
            _files = new List<SignFile>();

            var fileDialog = new OpenFileDialog
            {
                Multiselect = true,
                Title = Resources.SelectFiles,
                Filter = Resources.FileFilter
            };

            if (fileDialog.ShowDialog() != DialogResult.OK)
                return;

            foreach (var fileName in fileDialog.FileNames)
                _files.Add(new SignFile(fileName, null));

            _pdfPaths = _files.Select(s => s.OldPath).Where(File.Exists).ToList();

            if (_file == null && (_pdfPaths == null || _pdfPaths.Count == 0))
            {
                btnUp.Enabled = false;
                btnNext.Enabled = false;
                return;
            }

            btnUp.Enabled = true;
            btnNext.Enabled = true;

            // 记录初始数据，防止多次缩放控件大小
            SetCtrlTag();

            UpdateData();
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = false;

            if (_file == null && (_pdfPaths == null || _pdfPaths.Count <= 1))
            {
                btnUp.Enabled = false;
                btnNext.Enabled = false;
                return;
            }

            btnUp.Enabled = true;
            btnNext.Enabled = true;

            var outFile = _files[_index];
            var dirName = Path.GetDirectoryName(_pdfPaths[_index]);
            var fileName = Path.GetFileNameWithoutExtension(outFile.OldPath) + ".jpg";

            // 待上传的截图路径
            var captureImg = Path.Combine(dirName, "SCREEN_" + fileName);

            // 截图功能
            CaptureImage(captureImg);

            // 记录当前标记位置
            _topCode = GetLocation(pbTopCode);
            _bottomCode = GetLocation(pbBottomCode);
            _generalSign = GetLocation(pbDrawingReviewSign);
            _drawingSign = GetLocation(pbGeneralOfficeSign);

            var error1 = ShowErrorMsg(_topCode, Resources.TopCode);
            var error2 = ShowErrorMsg(_bottomCode, Resources.BottomCode);
            var error3 = ShowErrorMsg(_generalSign, Resources.GeneralOfficeSign);
            var error4 = ShowErrorMsg(_drawingSign, Resources.DrawingReviewSign);

            if (error1 || error2 || error3 || error4)
                return;

            outFile.TopQrCodePos = RecordLocation(pbTopCode, _topCode, 0, 0);
            outFile.BottomQrCodePos = RecordLocation(pbBottomCode, _bottomCode, 0, 0);
            outFile.GeneralOfficePos = RecordLocation(pbDrawingReviewSign, _generalSign, 72, 40);
            outFile.DrawingReviewPos = RecordLocation(pbGeneralOfficeSign, _drawingSign, 72, 40);
            MessageBox.Show(Resources.SaveSuccessful);
        }

        /// <summary>
        /// 上一张
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUp_Click(object sender, EventArgs e)
        {
            if (btnSave.Enabled)
            {
                var result = MessageBox.Show(Resources.IsSave, Resources.Prompt, MessageBoxButtons.OKCancel);

                if (result == DialogResult.OK)
                {
                    // 延迟一小段时间解决点击确定瞬间把消息框截取下来的问题
                    Thread.Sleep(10);

                    btnSave.PerformClick();
                }
            }

            _index--;

            if (_index < 0)
                _index = _pdfPaths.Count - 1;

            btnSave.Enabled = false;
            GetPictureBoxes().ForEach(f => f.BackColor = Color.DarkGray);
            UpdateData();
        }

        /// <summary>
        /// 下一张
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (btnSave.Enabled)
            {
                var result = MessageBox.Show(Resources.IsSave, Resources.Prompt, MessageBoxButtons.OKCancel);

                if (result == DialogResult.OK)
                {
                    // 延迟一小段时间解决点击确定瞬间把消息框截取下来的问题
                    Thread.Sleep(10);

                    btnSave.PerformClick();
                }
            }

            _index++;

            if (_index > _pdfPaths.Count - 1)
                _index = 0;

            btnSave.Enabled = false;
            GetPictureBoxes().ForEach(f => f.BackColor = Color.DarkGray);
            UpdateData();
        }

        /// <summary>
        /// 测试
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTest_Click(object sender, EventArgs e)
        {
            var oldPath = _pdfPaths[_index];
            var signedPath = Path.Combine(Path.GetDirectoryName(oldPath), "SIGN_" + Path.GetFileName(oldPath));
            var position = RecordLocation(pbTopCode, _topCode, 0, 0);
            var point = new Point(Convert.ToInt32(position.Split(',')[0]), Convert.ToInt32(position.Split(',')[1]));

            if (File.Exists(signedPath))
                File.Delete(signedPath);

            File.Copy(oldPath, signedPath, true);
            SetSign(oldPath, signedPath, point);
        }

        /// <summary>
        /// 按下鼠标左键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private new void MouseDown(object sender, MouseEventArgs e)
        {
            _isDown = true;
            _mousePoint = PointToClient(MousePosition);

            var picBox = sender as PictureBox;

            if (picBox == null)
                return;

            _imgPoint = picBox.Location;
        }

        /// <summary>
        /// 松开鼠标左键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private new void MouseUp(object sender, MouseEventArgs e)
        {
            _isDown = false;
        }

        /// <summary>
        /// 移动鼠标
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private new void MouseMove(object sender, MouseEventArgs e)
        {
            var x = PointToClient(MousePosition).X - _mousePoint.X;
            var y = PointToClient(MousePosition).Y - _mousePoint.Y;

            if (!_isDown)
                return;

            var pbWidth = pbImg.Width;
            var pbHeight = pbImg.Height;
            var picBox = sender as PictureBox;

            if (picBox == null)
                return;

            if (_imgPoint.X + x <= 0)
                return;

            if (_imgPoint.Y + y <= 0)
                return;

            if (_imgPoint.X + x >= pbWidth - picBox.Width)
                return;

            if (_imgPoint.Y + y >= pbHeight - picBox.Height)
                return;

            if (_imgPoint.X + x >= pbWidth - picBox.Width)
                return;

            if (_imgPoint.Y + y >= pbHeight - picBox.Height)
                return;

            if (x != 0 || y != 0)
                btnSave.Enabled = true;

            else
                btnSave.Enabled = false;

            picBox.Location = new Point(_imgPoint.X + x, _imgPoint.Y + y);
        }

        /// <summary>
        /// 设置图片背景色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetPictureBackColor(object sender, EventArgs e)
        {
            var pictureBox = sender as PictureBox;

            if (pictureBox == null)
                return;

            pictureBox.BackColor = Color.Blue;
            pictureBox.Focus();

            var pbs = GetPictureBoxes().Where(s => s.Name != pictureBox.Name).ToList();

            pbs.ForEach(f => f.BackColor = Color.DarkGray);
        }

        /// <summary>
        /// 获取图片控件列表
        /// </summary>
        /// <returns></returns>
        private List<PictureBox> GetPictureBoxes()
        {
            var results = new List<PictureBox>();

            foreach (var control in Controls)
            {
                var px = control as PictureBox;

                if (px != null)
                {
                    results.Add(px);
                    continue;
                }

                var pnl = control as Panel;

                if (pnl == null)
                    continue;

                results.AddRange(pnl.Controls.Cast<Control>().Where(w => w is PictureBox).Cast<PictureBox>().ToList());
            }

            return results;
        }

        /// <summary>
        /// 提示位置错误
        /// </summary>
        /// <param name="loation"></param>
        /// <param name="name"></param>
        private bool ShowErrorMsg(List<double> loation, string name)
        {
            var result = false;
            var pdfSize = PdfConverter.GetPdfSize(_pdfPaths[_index]);

            if (Math.Abs(loation[0]) < 0.000001)
            {
                MessageBox.Show($"{Resources.SignError}，{name}{Resources.LoseHView}");
                result = true;
            }

            if (loation[0] > pdfSize.Width)
            {
                MessageBox.Show($"{Resources.SignError}，{name}{Resources.BeyondHView}");
                result = true;
            }

            if (Math.Abs(loation[1]) < 0.000001)
            {
                MessageBox.Show($"{Resources.SignError}，{name}{Resources.LoseVView}");
                result = true;
            }

            if (loation[1] > pdfSize.Height)
            {
                MessageBox.Show($"{Resources.SignError}，{name}{Resources.BeyondVView}");
                result = true;
            }

            return result;
        }

        /// <summary>
        /// 设置默认大小
        /// </summary>
        private void SetCtrlTag()
        {
            pbTopCode.Tag = pbTopCode.Width + "," + pbTopCode.Height;
            pbDrawingReviewSign.Tag = pbDrawingReviewSign.Width + "," + pbDrawingReviewSign.Height;
            pbGeneralOfficeSign.Tag = pbGeneralOfficeSign.Width + "," + pbGeneralOfficeSign.Height;
            pbBottomCode.Tag = pbBottomCode.Width + "," + pbBottomCode.Height;
        }

        /// <summary>
        /// 截图
        /// </summary>
        private void CaptureImage(string filePath)
        {
            if (File.Exists(filePath))
                File.Delete(filePath);

            var rect = Screen.PrimaryScreen.Bounds;
            var size = new Size(pbImg.Width, pbImg.Height);

            using (var bitmap = new Bitmap(rect.Width, rect.Height))
            {
                var grp = Graphics.FromImage(bitmap);
                var location = new Point(Left + 8, Top + 32);

                grp.CopyFromScreen(location, new Point(0, 0), size);
                grp.ReleaseHdc(grp.GetHdc());
                bitmap.Save(filePath);
            }

            using (var srcImg = Image.FromFile(filePath))
            using (var bitmap = new Bitmap(pbImg.Width, pbImg.Height))
            using (var grp = Graphics.FromImage(bitmap))
            {
                grp.DrawImage(srcImg, 0, 0, new Rectangle(new Point(), size), GraphicsUnit.Pixel);
                srcImg.Dispose();

                using (Image newImg = Image.FromHbitmap(bitmap.GetHbitmap()))
                    newImg.Save(filePath, ImageFormat.Jpeg);
            }
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        private void UpdateData()
        {
            _img?.Dispose();

            string filePath;
            var pdfPath = _pdfPaths[_index];

            // 拼凑同目录下的图片路径
            if (_file != null)
                filePath = _file.OldPath.Remove(_file.OldPath.LastIndexOf('.')) + ".jpg";

            else
                filePath = pdfPath.Remove(pdfPath.LastIndexOf('.')) + ".jpg";

            List<string> imgFiles;

            // 存在就加载，不存在则转换
            if (File.Exists(filePath))
                _img = Image.FromFile(filePath);

            else if (_file != null)
            {
                imgFiles = _file.OldPath.ToImages();

                if (imgFiles.Count > 0)
                    _img = Image.FromFile(_file.OldPath.ToImages()[0]);

                else
                {
                    pbImg.Image = null;
                    Text = Path.GetFileName(_file == null ? _files[_index].OldPath : _file.OldPath);
                    return;
                }
            }

            else
            {
                imgFiles = pdfPath.ToImages();

                if (imgFiles.Count > 0)
                    _img = Image.FromFile(imgFiles[0]);

                else
                {
                    pbImg.Image = null;
                    Text = Path.GetFileName(_file == null ? _files[_index].OldPath : _file.OldPath);
                    return;
                }
            }

            _pdfScale = GetScale(PdfConverter.GetPdfSize(pdfPath), _img.Size);
            _imgScale = GetScale(_img.Size, pnlImg.Size);
            pbImg.Image = _img;

            // 设置标记前必须先设置图纸所在控件大小，防止参照上一个图纸大小设置位置
            ZoomCtrl();

            SetLocation();
            Text = Path.GetFileName(_file == null ? _files[_index].OldPath : _file.OldPath);
        }

        /// <summary>
        /// 获取缩放比例
        /// </summary>
        /// <param name="imageSize"></param>
        /// <param name="itemSize"></param>
        /// <returns></returns>
        private static double GetScale(Size imageSize, Size itemSize)
        {
            var xScale = imageSize.Width * 1.0 / itemSize.Width;
            var yScale = imageSize.Height * 1.0 / itemSize.Height;

            return Math.Max(xScale, yScale);
        }

        /// <summary>
        /// 等比例缩放控件
        /// </summary>
        private void ZoomCtrl()
        {
            ZoomCtrl(pbImg);
            ZoomCtrl(pbTopCode);
            ZoomCtrl(pbDrawingReviewSign);
            ZoomCtrl(pbGeneralOfficeSign);
            ZoomCtrl(pbBottomCode);
        }

        /// <summary>
        /// 等比例缩放控件
        /// </summary>
        /// <param name="ctrl"></param>
        /// <returns></returns>
        private void ZoomCtrl(Control ctrl)
        {
            if (ctrl.Tag.ToString() == Resources.ImgTag)
                ctrl.Size = new Size((int)(_img.Width / _imgScale), (int)(_img.Height / _imgScale));

            else
            {
                var width = (int)(Convert.ToInt32(ctrl.Tag.ToString().Split(',')[0]) / (_imgScale * _pdfScale));
                var height = (int)(Convert.ToInt32(ctrl.Tag.ToString().Split(',')[1]) / (_imgScale * _pdfScale));

                ctrl.Size = new Size(width, height);
            }
        }

        /// <summary>
        /// 获取当前标记位置
        /// </summary>
        /// <param name="ctrl"></param>
        /// <returns></returns>
        private List<double> GetLocation(Control ctrl)
        {
            return new List<double> { ctrl.Left * 1.0 / pbImg.Width, ctrl.Top * 1.0 / pbImg.Height };
        }

        /// <summary>
        /// 设置标记加载位置
        /// </summary>
        private void SetLocation()
        {
            var outFile = _file ?? _files[_index];

            if (string.IsNullOrEmpty(outFile.TopQrCodePos))
                btnSave.Enabled = true;

            else if (string.IsNullOrEmpty(outFile.BottomQrCodePos))
                btnSave.Enabled = true;

            else if (string.IsNullOrEmpty(outFile.GeneralOfficePos))
                btnSave.Enabled = true;

            else if (string.IsNullOrEmpty(outFile.DrawingReviewPos))
                btnSave.Enabled = true;

            else
            {
                _topCode = outFile.TopQrCodePos.Split(',').Select(Convert.ToDouble).ToList().GetRange(2, 2);
                _bottomCode = outFile.BottomQrCodePos.Split(',').Select(Convert.ToDouble).ToList().GetRange(2, 2);
                _generalSign = outFile.GeneralOfficePos.Split(',').Select(Convert.ToDouble).ToList().GetRange(2, 2);
                _drawingSign = outFile.DrawingReviewPos.Split(',').Select(Convert.ToDouble).ToList().GetRange(2, 2);
            }

            SetLocation(pbTopCode, _topCode);
            SetLocation(pbDrawingReviewSign, _generalSign);
            SetLocation(pbGeneralOfficeSign, _drawingSign);
            SetLocation(pbBottomCode, _bottomCode);
        }

        /// <summary>
        /// 设置标记加载位置
        /// </summary>
        /// <param name="ctrl"></param>
        /// <param name="location"></param>
        /// <returns></returns>
        private void SetLocation(Control ctrl, List<double> location)
        {
            ctrl.Location = new Point((int)(pbImg.Width * location[0]), (int)(pbImg.Height * location[1]));

            // 处理图签相对较大导致超出边界问题
            if (ctrl.Location.X + ctrl.Width > pbImg.Width)
                ctrl.Location = new Point((int)(pbImg.Width * location[0] - ctrl.Width), (int)(pbImg.Height * location[1]));

            if (ctrl.Location.Y + ctrl.Height > pbImg.Height)
                ctrl.Location = new Point((int)(pbImg.Width * location[0]), (int)(pbImg.Height * location[1] - ctrl.Height));
        }

        /// <summary>
        /// 记录左下角为原点的标记位置
        /// </summary>
        /// <param name="ctrl"></param>
        /// <param name="location"></param>
        /// <param name="wOffset"></param>
        /// <param name="hOffset"></param>
        /// <returns></returns>
        private string RecordLocation(Control ctrl, List<double> location, int wOffset, int hOffset)
        {
            var signX = (int)(pbImg.Width * _imgScale * _pdfScale * location[0]) + wOffset;
            var signY = (int)((pbImg.Height * (1 - location[1]) - ctrl.Height) * _imgScale * _pdfScale) + hOffset;
            var screenX = location[0];
            var screenY = location[1];

            return $"{signX},{signY},{screenX},{screenY}";
        }

        /// <summary>
        /// 设置标记
        /// </summary>
        /// <param name="position"></param>
        /// <param name="oldPath"></param>
        /// <param name="signedPath"></param>
        private static void SetSign(string oldPath, string signedPath, Point position)
        {
            if (string.IsNullOrWhiteSpace(oldPath))
                throw new ArgumentException(nameof(oldPath));

            if (string.IsNullOrWhiteSpace(signedPath))
                throw new ArgumentException(nameof(signedPath));

            if (!File.Exists(oldPath))
                throw new FileNotFoundException(nameof(oldPath));

            if (!File.Exists(signedPath))
                throw new FileNotFoundException(nameof(signedPath));

            var fileInfo = new FileInfo(oldPath);

            if (fileInfo.IsReadOnly)
                fileInfo.IsReadOnly = false;

            const string link = "http://www.bing.com";

            var signFile = new SignFile(oldPath, signedPath);

            signFile.AddSign(link, position);
            fileInfo = new FileInfo(signedPath);

            if (fileInfo.IsReadOnly)
                fileInfo.IsReadOnly = false;

            fileInfo.Delete();
        }
    }
}
