using System;
using System.Windows.Forms;
using static FigureForms.Figure;

namespace FigureForms
{
    public partial class Form1 : Form
    {
        // UI controls
        private TextBox txtRadius, txtWidth, txtHeight, txtSideA, txtSideB, txtSideC;
        private Button btnCircle, btnRectangle, btnTriangle;
        private Label lblCircleResult, lblRectangleResult, lblTriangleResult;
        private Label lblRadius, lblWidth, lblHeight, lblSideA, lblSideB, lblSideC;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Circle Controls
            lblRadius = new Label { Text = "Радиус:", Location = new System.Drawing.Point(10, 10), Width = 80 };
            txtRadius = new TextBox { Location = new System.Drawing.Point(100, 10), Width = 100 };
            btnCircle = new Button { Text = "Calculate Circle", Location = new System.Drawing.Point(210, 10) };
            lblCircleResult = new Label { Location = new System.Drawing.Point(10, 40), Width = 300 };

            // Button Click event
            btnCircle.Click += (circleSender, circleEventArgs) => CalculateCircle();

            // Rectangle Controls
            lblWidth = new Label { Text = "Ширина:", Location = new System.Drawing.Point(10, 70), Width = 80 };
            lblHeight = new Label { Text = "Высота:", Location = new System.Drawing.Point(210, 70), Width = 80 };
            txtWidth = new TextBox { Location = new System.Drawing.Point(100, 70), Width = 100 };
            txtHeight = new TextBox { Location = new System.Drawing.Point(300, 70), Width = 100 };
            btnRectangle = new Button { Text = "Calculate Rectangle", Location = new System.Drawing.Point(410, 70) };
            lblRectangleResult = new Label { Location = new System.Drawing.Point(10, 100), Width = 300 };

            // Button Click event
            btnRectangle.Click += (rectangleSender, rectangleEventArgs) => CalculateRectangle();

            // Triangle Controls
            lblSideA = new Label { Text = "Сторона A:", Location = new System.Drawing.Point(10, 130), Width = 80 };
            lblSideB = new Label { Text = "Сторона B:", Location = new System.Drawing.Point(210, 130), Width = 80 };
            lblSideC = new Label { Text = "Сторона C:", Location = new System.Drawing.Point(410, 130), Width = 80 };
            txtSideA = new TextBox { Location = new System.Drawing.Point(100, 130), Width = 100 };
            txtSideB = new TextBox { Location = new System.Drawing.Point(300, 130), Width = 100 };
            txtSideC = new TextBox { Location = new System.Drawing.Point(500, 130), Width = 100 };
            btnTriangle = new Button { Text = "Calculate Triangle", Location = new System.Drawing.Point(610, 130) };
            lblTriangleResult = new Label { Location = new System.Drawing.Point(10, 160), Width = 300 };

            // Button Click event
            btnTriangle.Click += (triangleSender, triangleEventArgs) => CalculateTriangle();

            // Adding controls to the form
            Controls.Add(lblRadius);
            Controls.Add(txtRadius);
            Controls.Add(btnCircle);
            Controls.Add(lblCircleResult);
            Controls.Add(lblWidth);
            Controls.Add(lblHeight);
            Controls.Add(txtWidth);
            Controls.Add(txtHeight);
            Controls.Add(btnRectangle);
            Controls.Add(lblRectangleResult);
            Controls.Add(lblSideA);
            Controls.Add(lblSideB);
            Controls.Add(lblSideC);
            Controls.Add(txtSideA);
            Controls.Add(txtSideB);
            Controls.Add(txtSideC);
            Controls.Add(btnTriangle);
            Controls.Add(lblTriangleResult);
        }

        // Method to calculate the area and perimeter of the circle
        private void CalculateCircle()
        {
            try
            {
                double radius = double.Parse(txtRadius.Text);
                if (radius <= 0)
                    throw new ArgumentException("Радіус повинен бути більше за 0");
                Circle circle = new Circle(radius);
                lblCircleResult.Text = $"Площа: {circle.GetArea():0.##},  Окружність: {circle.GetPerimeter():0.##}";
            }
            catch (Exception ex)
            {
                lblCircleResult.Text = ex.Message;
            }
        }

        // Method to calculate the area and perimeter of the rectangle
        private void CalculateRectangle()
        {
            try
            {
                double width = double.Parse(txtWidth.Text);
                double height = double.Parse(txtHeight.Text);
                if (width <= 0 || height <= 0)
                    throw new ArgumentException("Сторони повинні бути більші за 0");
                Rectangle rectangle = new Rectangle(width, height);
                lblRectangleResult.Text = $"Площа: {rectangle.GetArea():0.##},  Периметр: {rectangle.GetPerimeter():0.##}";
            }
            catch (Exception ex)
            {
                lblRectangleResult.Text = ex.Message;
            }
        }

        // Method to calculate the area and perimeter of the triangle
        private void CalculateTriangle()
        {
            try
            {
                double sideA = double.Parse(txtSideA.Text);
                double sideB = double.Parse(txtSideB.Text);
                double sideC = double.Parse(txtSideC.Text);
                if (sideA <= 0 || sideB <= 0 || sideC <= 0)
                    throw new ArgumentException("Сторони повинні бути більші за 0");
                Triangle triangle = new Triangle(sideA, sideB, sideC);
                lblTriangleResult.Text = $"Площа: {triangle.GetArea():0.##},  Периметр: {triangle.GetPerimeter():0.##}";
            }
            catch (Exception ex)
            {
                lblTriangleResult.Text = ex.Message;
            }
        }
    }
}
