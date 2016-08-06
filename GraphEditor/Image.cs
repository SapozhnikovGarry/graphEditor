using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;


namespace GraphEditor
{
    class Image
    {
        private Bitmap canvas;                   //изображение
        private int width, height;               //ширина и высота изображения 

        public Bitmap сanvas
        {
            get
            {
                return canvas;
            }
        }

        /// <summary>
        /// конструктор 
        /// </summary>
        /// <param name="width">ширина изображения</param>
        /// <param name="height">высота изображения</param>
        public Image(int width, int height)
        {
            this.width = width;
            this.height = height;
            initImage(width, height);
        }

        /// <summary>
        /// метод для инициализации изображения
        /// </summary>
        /// <param name="width">ширина изображения</param>
        /// <param name="height">высота изображения</param>
        private void initImage(int width, int height)
        {
            if (canvas != null) canvas.Dispose();
            canvas = new Bitmap(width, height);
            Graphics.FromImage(canvas).Clear(Color.White);
        }

        /// <summary>
        /// Обновление канвы
        /// </summary>
        /// <param name="img"></param>
        public void GetNewBitmap(System.Drawing.Image img)
        {
            canvas = new Bitmap(img);
        }

    }
}
