using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace GraphEditor
{
    public partial class Form2 : Form
    {
        private ImageInvertor imgInvertor;      
        private PictureBox prBox;                //элемент для отображения результата

        public Form2(Bitmap img, PictureBox pic)    //конструктор для Form2
        {
            InitializeComponent();
            progressBar1.Maximum = img.Size.Height;  //инициализация progressBar1
            progressBar1.Step = 1;
            progressBar1.Value = 0;

            imgInvertor = new ImageInvertor();  
            imgInvertor.image = img;
            imgInvertor.progress = 0;
            imgInvertor.invertComplete += imgInvertor_invertComplete;   //вешаем обработчик конца инвертации

            prBox = pic;

            timer1.Interval = 10;               //инициализация для таймера
            timer1.Enabled = true;

        }

        private void imgInvertor_invertComplete()
        {
            timer1.Stop();

            this.BeginInvoke(new Action(() =>       //асинхронно перезаписываем картинку
            {
                prBox.Image = imgInvertor.image;
                this.Close();
            }));
        }

        private void Form2_Shown(object sender, EventArgs e)
        {
            imgInvertor.invertStart();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Value = imgInvertor.progress;
        }

    }
}
