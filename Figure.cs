using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static FigureForms.Figure;

namespace FigureForms
{
    public static class Figure
    {

        public abstract class Figures : IFigure
        {
            public abstract double GetArea();
            public abstract double GetPerimeter();
        }

        public class Circle : Figures
        {
            public double Radius { get; set; }

            public Circle(double radius)
            {
                if (radius <= 0)
                {
                    throw new ArgumentException("Радіус повинен бути більше за 0");
                }

                Radius = radius;
            }

            public override double GetArea()
            {
                return Math.PI * Radius * Radius;
            }

            public override double GetPerimeter()
            {
                return 2 * Math.PI * Radius;
            }
        }

        public class Rectangle : Figures
        {
            public double Width { get; set; }
            public double Height { get; set; }

            public Rectangle(double width, double height)
            {
                if (width <= 0 || height <= 0)
                {
                    throw new ArgumentException("Сторони повинні бути більші за 0");
                }

                Width = width;
                Height = height;
            }

            public override double GetArea()
            {
                return Width * Height;
            }

            public override double GetPerimeter()
            {
                return 2 * (Width + Height);
            }
        }

        public class Triangle : Figures
        {
            public double SideA { get; set; }
            public double SideB { get; set; }
            public double SideC { get; set; }

            public Triangle(double sideA, double sideB, double sideC)
            {
                
                if (sideA <= 0 || sideB <= 0 || sideC <= 0)
                {
                    throw new ArgumentException("Сторони не можуть бути від'ємними");
                }

                if (sideA + sideB <= sideC || sideA + sideC <= sideB || sideB + sideC <= sideA)
                {
                    throw new ArgumentException("Сума двох сторін менше третьої");
                }

                SideA = sideA;
                SideB = sideB;
                SideC = sideC;
            }

            public override double GetPerimeter()
            {
                return SideA + SideB + SideC;
            }

            public override double GetArea()
            {
                double semiPerimeter = GetPerimeter() / 2;
                return Math.Sqrt(semiPerimeter * (semiPerimeter - SideA) * (semiPerimeter - SideB) * (semiPerimeter - SideC));
            }
        }


        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
