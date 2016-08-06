using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GraphEditor
{
    class ImageInvertor
    {
        public Bitmap image;                //изображение, которое будет инвертировано 
        public int progress;                //прогресс

        public delegate void invertCompleteHandler();                     //обработчик события завершения инвесии
        public event invertCompleteHandler invertComplete;                //событие завершения процесса инверсии

        /// <summary>
        /// старт инвентирования картинки
        /// </summary>
        public void invertStart()
        {
            Thread t = new Thread(invertImage);
            t.Start();
        }

        /// <summary>
        /// метод инвертирует изображение
        /// </summary>
        private void invertImage()
        {
            for (int i = 0; i < image.Size.Height; i++)
            {
                for (int j = 0; j < image.Size.Width; j++)
                {
                    Color c = image.GetPixel(j, i);
                    c = Color.FromArgb(c.ToArgb() ^ 0xffffff);
                    image.SetPixel(j, i, c);
                }
                Thread.Sleep(5);                                  //замедляем обработку изображения
                progress++;
            }

            invertComplete();                                      //кидаем событие завершения обработки  
        }
    }
}
