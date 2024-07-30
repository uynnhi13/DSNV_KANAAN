using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Kanaan_DataAccess
{
    public class Function
    {
        public string UpLoadImgage(PictureBox UploadImg, string MaNV)
        {
            string imgLocation = "";
            string destinationPath = @"D:\Thực Tập Conect\Winform\DSNV_KANAAN\Kanaan\Image\Avatar\avatarnv" + MaNV + ".jpg";
            if(File.Exists(destinationPath))
            {
                File.Delete(destinationPath );
            }
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "jpg files(*.jpg)|*.jpg| PNG files(*.pgn)|*pgn| All Files(*.*)|*.*";

                if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    imgLocation = openFileDialog.FileName;
                    UploadImg.ImageLocation = imgLocation;
                }

                File.Copy(imgLocation, destinationPath);
            }
            catch (Exception)
            {
                MessageBox.Show("An Error Occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return destinationPath;
        }
    }
}
