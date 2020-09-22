using System;

namespace Formulas
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program().MathematicalFormulas();
        }

        //Top Menu Class.
        private void MathematicalFormulas()
        {
            Console.WriteLine("Please choose a Mathematical Formula to calculate:\n");
            Console.WriteLine("1.  Area and Circumference of a Circle.");
            Console.WriteLine("2.  Volume of a Hemisphere.");
            Console.WriteLine("3.  Area of a Triangle.");
            Console.WriteLine("4.  Solving a Quadratic Equation.\n");

            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 1)
            {
                Circle();
            }
            else if (choice == 2)
            {
                Hemisphere();
            }
            else if (choice == 3)
            {
                Triangle();
            }
            else if (choice == 4)
            {
                QuadraticEquation();
            }
            else
            {
                InvalidInput();
                MathematicalFormulas();
            }
        }

        //Circle Option.
        private void Circle()
        {
            string input;
            float radius;

            Console.WriteLine(GetRadius());
            input = Console.ReadLine();
            
            while (float.TryParse(input, out radius) == false || radius <= 0)
            {
                InvalidInput();
                GetRadius();
                input = Console.ReadLine();
            }
            
            CalculateArea(radius);
            CalculateCircumference(radius);
            ChooseAnother();
        }

        //Hemisphere Option.
        private void Hemisphere()
        {
            string input;
            float radius;

            Console.WriteLine(GetRadius());
            input = Console.ReadLine();

            while (float.TryParse(input, out radius) == false || radius <= 0)
            {
                InvalidInput();
                GetRadius();
                input = Console.ReadLine();
            }
            
            CalculateVolume(radius);
            ChooseAnother();
        }

        //Triangle Option.
        private void Triangle()
        {
            string input;
            float a, b, c;

            Console.Write("\n Enter side a of your triangle (i.e. 4.25):  ");
            input = Console.ReadLine();

            while (float.TryParse(input, out a) == false || a <= 0)
            {
                InvalidInput();
                Console.Write("\n Enter side a of your triangle (i.e. 4.25):  ");
                input = Console.ReadLine();
            }

            Console.Write("\n Enter side b of your triangle (i.e. 4.25):  ");
            input = Console.ReadLine();

            while (float.TryParse(input, out b) == false || b <= 0)
            {
                InvalidInput();
                Console.Write("\n Enter side b of your triangle (i.e. 4.25):  ");
                input = Console.ReadLine();
            }

            Console.Write("\n Enter side c of your triangle (i.e. 4.25):  ");
            input = Console.ReadLine();

            while (float.TryParse(input, out c) == false || c <= 0)
            {
                InvalidInput();
                Console.Write("\n Enter side c of your triangle (i.e. 4.25):  ");
                input = Console.ReadLine();
            }

            if (a + b < c)
            {
                Console.WriteLine("This is not a triangle due to c being greater than the sum of a and b.  Try again.");
                Triangle();
            }
            else if (a + c < b)
            {
                Console.WriteLine("This is not a triangle due to b being greater than the sum of a and c.  Try again.");
                Triangle();
            }
            else if (b + c < a)
            {
                Console.WriteLine("This is not a triangle due to a being greater than the sum of b and c.  Try again.");
                Triangle();
            }
            else
            {
                CalculateArea(a, b, c);
                ChooseAnother();
            }
        }

        //Quadratic Option.
        private void QuadraticEquation()
        {
            GetInput();
            ChooseAnother();
        }

        //Area of Circle.
        private void CalculateArea(float radius)
        {
            double area;
            area = Math.PI * Math.Pow(radius, 2);
            Console.WriteLine($"\tThe area of your circle is {area}.\n");            
        }
        
        //Circumference of Circle.
        private void CalculateCircumference(float radius)
        {
            double circumference;
            circumference = 2 * Math.PI * radius;
            Console.WriteLine($"\tThe circumference of your circle is {circumference}.\n");
        }       
        
        //Volume of Hemisphere.
        private void CalculateVolume(float radius)
        {
            double volume;
            volume = (2 * Math.PI * Math.Pow(radius, 3)) / 3;
            Console.WriteLine($"\tThe volume of your hemisphere is {volume}.\n");
        }        

        //Area of Triangle.  Overloaded Method.
        private void CalculateArea(float a, float b, float c)
        {
            float p, p1, p2, p3;
            double area;

            p = (a + b + c) / 2;            
            p1 = p - a;            
            p2 = p - b;            
            p3 = p - c;

            area = Math.Sqrt(p * p1 * p2 * p3);

            Console.WriteLine($"\tThe area of your triangle is {area}.\n");
        }        

        //Quadratic Equation Methods.
        private void GetInput()
        {
            string input;
            float a, b, c;

            Console.Write("\n Enter the numeric value of a that is not 0 :  ");
            input = Console.ReadLine();

            while (float.TryParse(input, out a) == false || a == 0)
            {
                InvalidInput();
                Console.Write("\n Enter the numeric value of a that is not 0:  ");
                input = Console.ReadLine();
            }

            Console.Write("\n Enter the numeric value of b:  ");
            input = Console.ReadLine();

            while (float.TryParse(input, out b) == false)
            {
                InvalidInput();
                Console.Write("\n Enter the numeric value of b:  ");
                input = Console.ReadLine();
            }

            Console.Write("\n Enter the numeric value of c:  ");
            input = Console.ReadLine();

            while (float.TryParse(input, out c) == false)
            {
                InvalidInput();
                Console.Write("\n Enter the numeric value of c:  ");
                input = Console.ReadLine();
            }

            CalculateEquation(a, b, c);
        }        

        private void CalculateEquation(float a, float b, float c)
        {
            double sqrtEquation;
            double positiveValue, negativeValue;

            sqrtEquation = (Math.Pow(b,2)) - (4 * a * c);

            if (sqrtEquation < 0)
            {
                Console.WriteLine("The current result will lead to an imaginary number.  Please readjust the values of b, c, or both to calculate.");
                GetInput();
            }

            positiveValue = (-b + Math.Sqrt(sqrtEquation)) / (2 * a);
            negativeValue = (-b - Math.Sqrt(sqrtEquation)) / (2 * a);

            Console.WriteLine($"The positive solution is {positiveValue}");
            Console.WriteLine($"The negative solution is {negativeValue}");
        }       

        //Menu Options and Methods.
        //used for Menu choice 1 and 2
        private string GetRadius()
        {
            string enter = "\n Enter the radius of your circle (i.e. 4.25):  ";
            return enter;
        }        

        private void ChooseAnother()
        {
            int choice;
            Console.Write("Press 1 to choose another formula or 2 to exit:  ");
            choice = Convert.ToInt32(Console.ReadLine());

            if(choice == 1)
            {
                Console.WriteLine();
                MathematicalFormulas();
            }
            else if (choice == 2)
            {
                return;
            }
            else
            {
                InvalidInput();                
                ChooseAnother();
            }
        }

        private void InvalidInput() => Console.WriteLine("Invalid input.  Please try again.");
    }
}
