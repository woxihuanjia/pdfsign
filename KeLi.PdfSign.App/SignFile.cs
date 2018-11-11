using System;
using System.Drawing;
using System.IO;
using iTextSharp.text.pdf;
using ThoughtWorks.QRCode.Codec;

namespace KeLi.PdfSign.App
{
    /// <summary>
    /// 图签文件
    /// </summary>
    public class SignFile
    {
        /// <summary>
        /// 文件编号
        /// </summary>
        public string FileId { get; set; }

        /// <summary>
        /// 项目编号
        /// </summary>
        public string PrjId { get; set; }

        /// <summary>
        /// 批次编号
        /// </summary>
        public string BatchId { get; set; }

        /// <summary>
        /// 用户编号
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// 原始路径
        /// </summary>
        public string OldPath { get; set; }

        /// <summary>
        /// 图签路径
        /// </summary>
        public string SignedPath { get; set; }

        /// <summary>
        /// 图签一位置
        /// </summary>
        public string GeneralOfficePos { get; set; }

        /// <summary>
        /// 图签二位置
        /// </summary>
        public string DrawingReviewPos { get; set; }

        /// <summary>
        /// 二维码一位置
        /// </summary>
        public string TopQrCodePos { get; set; }

        /// <summary>
        /// 二维码二位置
        /// </summary>
        public string BottomQrCodePos { get; set; }

        /// <summary>
        /// 上传时间
        /// </summary>
        public string UploadTime { get; set; }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="oldPath"></param>
        /// <param name="signedPath"></param>
        public SignFile(string oldPath, string signedPath)
        {
            OldPath = oldPath;
            SignedPath = signedPath;
        }

        /// <summary>
        /// 添加二维码
        /// </summary>
        public void AddSign(string link, Point position)
        {
            if (string.IsNullOrWhiteSpace(OldPath))
                throw new ArgumentException(nameof(OldPath));

            if (string.IsNullOrWhiteSpace(SignedPath))
                throw new ArgumentException(nameof(SignedPath));

            if (string.IsNullOrWhiteSpace(link))
                throw new ArgumentException(nameof(link));

            if (!File.Exists(OldPath))
                throw new FileNotFoundException(nameof(OldPath));

            if (File.Exists(SignedPath))
            {
                File.SetAttributes(SignedPath, File.GetAttributes(SignedPath) & FileAttributes.Archive);
                File.Delete(SignedPath);
            }

            using (var input = new FileStream(OldPath, FileMode.Open, FileAccess.Read))
            using (var output = new FileStream(SignedPath, FileMode.Create, FileAccess.Write))
            using (var reader = new PdfReader(input))
            using (var stamper = new PdfStamper(reader, output))
            {
                var content = stamper.GetOverContent(1);

                using (var memory = new MemoryStream())
                {
                    GetImage(link).Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);

                    var image = iTextSharp.text.Image.GetInstance(memory.ToArray());

                    image.SetAbsolutePosition(position.X, position.Y);
                    image.ScaleAbsolute(80, 80);
                    content.AddImage(image);
                }
            }
        }

        /// <summary>
        /// 获取二维码图片
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        public static Bitmap GetImage(string link)
        {
            if (string.IsNullOrWhiteSpace(link))
                throw new ArgumentException(nameof(link));

            var qrCodeEncoder = new QRCodeEncoder
            {
                QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE,
                QRCodeScale = 4,
                QRCodeVersion = 0,
                QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M
            };

            return qrCodeEncoder.Encode(link);
        }
    }
}
