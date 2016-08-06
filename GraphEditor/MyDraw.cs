using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace GraphEditor
{
    /// <summary>
    /// Перечисление типов фигур
    /// </summary>
    public enum figureType
    {
        Clear,
        Pencil,
        Line,
        Rectangle,
        Ellipse
    }


    /// <summary>
    /// Опсание рисунка
    /// </summary>
    static class MyDraw
    {
        public static figureType figure;                        //что рисовать

        public static Color figureBorderColor = Color.Black;    //цвет линии фигуры

        public static Color figureBrushColor = Color.White;    //цвет фона фигуры

        public static bool draw;                                //разрешение рисовать

    }

    /// <summary>
    /// Начальная координата
    /// </summary>
    public struct FirstPoint
    {
        public static int X;
        public static int Y;
    }

    /// <summary>
    /// Конечная координата
    /// </summary>
    public struct SecondPoint
    {
        public static int X;
        public static int Y;
    }

}
