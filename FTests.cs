using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using static FigureForms.Figure;

namespace FigureTests
{
    [TestClass]
    public class FTests
    {
        [TestMethod()]
        public void CircleTest()
        {
            double radius = 5;
            Circle circle = new Circle(radius);

            double area = circle.GetArea();
            double perimeter = circle.GetPerimeter();

            Assert.AreEqual(Math.PI * radius * radius, area, 0.0001, "Area calculation is incorrect for Circle.");
            Assert.AreEqual(2 * Math.PI * radius, perimeter, 0.0001, "Perimeter calculation is incorrect for Circle.");
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void CircleFailureTest()
        {
            double radius = -1;
            Circle circle = new Circle(radius);

            circle.GetArea();
            circle.GetPerimeter();
        }


        [TestMethod()]
        public void RectangleTest()
        {
            double width = 4;
            double height = 6;
            Rectangle rectangle = new Rectangle(width, height);

            double area = rectangle.GetArea();
            double perimeter = rectangle.GetPerimeter();

            Assert.AreEqual(width * height, area, 0.0001, "Area calculation is incorrect for Rectangle.");
            Assert.AreEqual(2 * (width + height), perimeter, 0.0001, "Perimeter calculation is incorrect for Rectangle.");
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void RectangleFailureTest()
        {
            double width = -4;
            double height = -6;

            Rectangle rectangle = new Rectangle(width, height);
            rectangle.GetArea();
            rectangle.GetPerimeter();
        }


        [TestMethod()]
        public void TriangleTest()
        {

            double sideA = 3;
            double sideB = 4;
            double sideC = 5;
            Triangle triangle = new Triangle(sideA, sideB, sideC);
           
            double area = triangle.GetArea();
            double perimeter = triangle.GetPerimeter();
            
            double semiPerimeter = (sideA + sideB + sideC) / 2;
            double expectedArea = Math.Sqrt(semiPerimeter * (semiPerimeter - sideA) * (semiPerimeter - sideB) * (semiPerimeter - sideC));
            double expectedPerimeter = sideA + sideB + sideC;

            Assert.AreEqual(expectedArea, area, 0.0001, "Area calculation is incorrect for Triangle.");
            Assert.AreEqual(expectedPerimeter, perimeter, 0.0001, "Perimeter calculation is incorrect for Triangle.");
        }

        [TestMethod("Passes if traingle check for side1 + side2 <= side3 throws exception")]
        [ExpectedException(typeof(ArgumentException))]
        public void TriangleFailureTest1() 
        {

            double sideA = 5;
            double sideB = 3;
            double sideC = 8;
            Triangle triangle = new Triangle(sideA,sideB, sideC);

            triangle.GetArea();
            triangle.GetPerimeter();

        }

        [TestMethod("Passes if triangle check for side <= 0 throws exception")]
        [ExpectedException(typeof(ArgumentException))]
        public void TriangleFailureTest2()
        {

            double sideA = 3;
            double sideB = 4;
            double sideC = -4;
            Triangle triangle = new Triangle(sideA, sideB, sideC);

            triangle.GetArea();
            triangle.GetPerimeter();
        }
    }
}
