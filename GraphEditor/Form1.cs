using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphEditor
{

    public partial class Form1 : Form
    {
        Image image;                            
        Figure line, rectangle, ellipse;        

        OpenSaveFile openSaveFile;

        public Form1()  //конструктор для Form1
        {
            InitializeComponent();

            MyDraw.figure = figureType.Clear;                   

            image = new Image(picture.Width, picture.Height);   //инициализируем изображение
            picture.Image = image.сanvas;                       //обратная инициализация

            line = new Line();                          //создаем объект Линия, прямоугольник и эллипс
            rectangle = new Rectangles();               
            ellipse = new Ellipse();

            openSaveFile = new OpenSaveFile();
        }

        private void picture_MouseMove(object sender, MouseEventArgs e)
        {
            SecondPoint.X = e.X;                //определяем вторую координату после MouseMove
            SecondPoint.Y = e.Y;

            if (MyDraw.figure == figureType.Pencil) //по MouseMove рисуем только если выбран карандаш
            {
                Drawing();

                FirstPoint.X = e.X;             //переопределяем стартовые координаты
                FirstPoint.Y = e.Y;
            }

        }

        private void picture_MouseDown(object sender, MouseEventArgs e)
        {
            MyDraw.draw = true;             //разрешаем рисовать фигуру при нахатии мыши

            FirstPoint.X = e.X;             //определяем стартовые координаты
            FirstPoint.Y = e.Y;
        }

        private void picture_MouseUp(object sender, MouseEventArgs e)
        {
            SecondPoint.X = e.X;            //определяем конечные координаты
            SecondPoint.Y = e.Y;

            Drawing();

            MyDraw.draw = false;        //запрещаем рисовать фигуру при нахатии мыши

        }

        protected void DrawFigure(figureType f)
        {
            MyDraw.figure = f;
        }

        private void btnPencil_CheckedChanged(object sender, EventArgs e)
        {
            DrawFigure(figureType.Pencil);                  //рисуем карандашом
        }

        private void btnLine_CheckedChanged(object sender, EventArgs e)
        {
            DrawFigure(figureType.Line);                    //рисуем линию
        }

        private void btnRectangle_CheckedChanged(object sender, EventArgs e)
        {
            DrawFigure(figureType.Rectangle);               //рисуем прямоугольник
        }

        private void btnEllipse_CheckedChanged(object sender, EventArgs e)
        {
            DrawFigure(figureType.Ellipse);                 //рисуем эллипс
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PictureClear();                                 //очистка окна
        }

        
        private void inversionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (image != null && image.сanvas != null && picture != null)
                new Form2(image.сanvas, picture).Show();            //вызываем инверсию и форму 2 с индикатором
            else
                MessageBox.Show(Error.imageIsNull);                 //иначе кидаем ошибку
        }

        private void changeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyDraw.figureBorderColor = openSaveFile.ChooseColorFromDialog();        //вызываем диалог выбора цвета
        }

        private void brushColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyDraw.figureBrushColor = openSaveFile.ChooseColorFromDialog();         //вызываем диалог выбора цвета
        }



        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openSaveFile.SaveFile(picture);         //сохраняем картинку
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openSaveFile.OpenFile(picture);         //открываем картинку

            image.GetNewBitmap(picture.Image);      //обновляем канву
        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.N:
                        PictureClear();
                        break;

                    case Keys.O:
                        openSaveFile.OpenFile(picture);
                        image.GetNewBitmap(picture.Image);
                        break;

                    case Keys.S:
                        openSaveFile.SaveFile(picture);
                        break;
                }
            }
            if (e.Alt && e.KeyCode == Keys.F4)                  //при Alt F4 закрываем форму
                this.Close();
        }

#region METHODS

        public void PictureClear()
        {
            picture.Image = null;
            image = new Image(picture.Width, picture.Height);

        }

        /// <summary>
        /// Метод прорисовки Фигур
        /// </summary>
        private void Drawing()
        {
            if (MyDraw.draw)
            {
                switch (MyDraw.figure)
                {

                    //рисуем карандашом или линию
                    case figureType.Pencil:
                    case figureType.Line:
                        line.DrawFigure(new Point(FirstPoint.X, FirstPoint.Y),
                                        new Point(SecondPoint.X, SecondPoint.Y),
                                        MyDraw.figureBorderColor,
                                        MyDraw.figureBrushColor,
                                        image.сanvas);
                        break;

                    //рисуем прямоугольник
                    case figureType.Rectangle:
                        rectangle.DrawFigure(new Point(FirstPoint.X, FirstPoint.Y),
                                        new Point(SecondPoint.X, SecondPoint.Y),
                                        MyDraw.figureBorderColor,
                                        MyDraw.figureBrushColor,
                                        image.сanvas);
                        break;

                    //рисуем эллипс
                    case figureType.Ellipse:

                        ellipse.DrawFigure(new Point(FirstPoint.X, FirstPoint.Y),
                                        new Point(SecondPoint.X, SecondPoint.Y),
                                        MyDraw.figureBorderColor,
                                        MyDraw.figureBrushColor,
                                        image.сanvas);
                        break;

                }
                picture.Image = image.сanvas;           //обновляем PictureBox
            }
        }

#endregion


    }
}
