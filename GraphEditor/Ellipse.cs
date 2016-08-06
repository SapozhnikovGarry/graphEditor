using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphEditor
{
    class Ellipse : Figure
    {
        /// <summary>
        /// Прорисовка эллипса
        /// </summary>
        /// <param name="_firstPoint">Начальная координата</param>
        /// <param name="_secondPoint">Конечная координата</param>
        /// <param name="_borderColor">Цвет контура</param>
        /// <param name="_brushColor">Цвет фона</param>
        /// <param name="_canvas">Изображение</param>
        public override void DrawFigure(Point _firstPoint,
            Point _secondPoint, Color _borderColor, Color _brushColor, Bitmap _canvas)
        {
            
            ConvertPoint(ref _firstPoint, ref _secondPoint);    //вызываем метод базового класса конвертации координат
            
            Graphics g = Graphics.FromImage(_canvas);
            
            Rectangle rect = new Rectangle( _firstPoint.X, 
                                _firstPoint.Y, 
                                _secondPoint.X - _firstPoint.X,
                                _secondPoint.Y - _firstPoint.Y);

            SolidBrush brush = new SolidBrush(_brushColor);

            g.FillEllipse(brush, rect);

            Pen p = new Pen(_borderColor);
            g.DrawEllipse(p, rect);

            g.Dispose();
        }
    }
}
