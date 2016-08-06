using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphEditor
{
    class OpenSaveFile
    {
        /// <summary>
        /// Открыть файл с картинкой
        /// </summary>
        /// <param name="pic">PictureBox, в который откроется картинка</param>
        public void OpenFile(PictureBox pic)
        {
            try
            {
                OpenFileDialog open = new OpenFileDialog();

                open.Title = "Open Image";
                open.Filter = "Images|*.png;*.bmp;*.jpg";

                if (open.ShowDialog() == DialogResult.OK)
                    pic.Image = Bitmap.FromFile(open.FileName);

                open.Dispose();
            }
            catch
            {
                MessageBox.Show(Error.openFileError);
            }
        }

        /// <summary>
        /// Сохранить в файл
        /// </summary>
        /// <param name="pic">PictureBox, из которого сохранится картинка</param>
        public void SaveFile(PictureBox pic)
        {
            try
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Title = "Save Image";
                save.Filter = "Images|*.png;*.bmp;*.jpg";

                ImageFormat format = ImageFormat.Jpeg;

                if (save.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string ext = System.IO.Path.GetExtension(save.FileName);
                    switch (ext)
                    {
                        case ".png":
                            format = ImageFormat.Png;
                            break;
                        case ".bmp":
                            format = ImageFormat.Bmp;
                            break;
                    }

                    pic.Image.Save(save.FileName, format);
                }
            }
            catch
            {
                MessageBox.Show(Error.saveFileError);
            }


        }

        /// <summary>
        /// открытие диалога выбора цвета контура и фона
        /// </summary>
        /// <returns>выбранный цвет</returns>
        public Color ChooseColorFromDialog()
        {
            ColorDialog MyDialog = new ColorDialog();
            MyDialog.AllowFullOpen = false;

            if (MyDialog.ShowDialog() == DialogResult.OK)
                return MyDialog.Color;
            else
                return Color.Black;
        }

    }
}
