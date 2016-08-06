using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphEditor
{
    class Rectangles: Figure
    {
        public override void DrawFigure(Point _firstPoint,
           Point _secondPoint, Color _borderColor, Color _brushColor, Bitmap _canvas)
        {
            ConvertPoint(ref _firstPoint, ref _secondPoint);

            Graphics g = Graphics.FromImage(_canvas);

            Rectangle rect = new Rectangle( _firstPoint.X, 
                                            _firstPoint.Y, 
                                            _secondPoint.X - _firstPoint.X,
                                            _secondPoint.Y - _firstPoint.Y);

            SolidBrush brush = new SolidBrush(_brushColor);

            g.FillRectangle(brush, rect);

            Pen p = new Pen(_borderColor);

            g.DrawRectangle(p, rect);

            g.Dispose();
        }
    }
}
