using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphEditor
{    
    class Line: Figure
    {
        /// <summary>
        /// Прорисовка Линии
        /// </summary>
        /// <param name="_firstPoint">Начальная координата</param>
        /// <param name="_secondPoint">Конечная координата</param>
        /// <param name="_borderColor">Цвет контура</param>
        /// <param name="_brushColor">Цвет фона</param>
        /// <param name="_canvas">Изображение</param>
        public override void DrawFigure(Point _firstPoint, Point _secondPoint, 
            Color _borderColor, Color _brushColor, Bitmap _canvas)
        {
            Graphics g = Graphics.FromImage(_canvas);
            Pen p = new Pen(_borderColor);

            g.DrawLine(p,
                       _firstPoint,
                       _secondPoint);

            g.Dispose();    
        }
    }
}
