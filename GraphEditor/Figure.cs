using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphEditor
{
    /// <summary>
    /// Базовый класс Фигура
    /// </summary>
    abstract class Figure
    {
        /// <summary>
        /// Переопределение координат
        /// </summary>
        /// <param name="firstPoint">Первая точка</param>
        /// <param name="secondPoint">Вторая точка</param>
        public void ConvertPoint(ref Point firstPoint, ref Point secondPoint)
        {
            if (secondPoint.X < firstPoint.X)
            {
                int buff = firstPoint.X;
                firstPoint.X = secondPoint.X;
                secondPoint.X = buff;
            }

            if (secondPoint.Y < firstPoint.Y)
            {
                int buff = firstPoint.Y;
                firstPoint.Y = secondPoint.Y;
                secondPoint.Y = buff;
            }
        }
        /// <summary>
        /// Рисование фигуры
        /// </summary>
        /// <param name="_firstPoint">Начальная координата</param>
        /// <param name="_secondPoint">Конечная координата</param>
        /// <param name="_borderColor">Цвет контура</param>
        /// <param name="_brushColor">Цвет фона</param>
        /// <param name="_canvas">Изображение</param>
        public abstract void DrawFigure(Point _firstPoint, 
            Point _secondPoint, Color _borderColor, Color _brushColor, Bitmap _canvas);
    }
}
