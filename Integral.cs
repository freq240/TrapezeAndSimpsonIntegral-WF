using System;
using System.IO;

namespace TrapezeAndSimpsonIntegral
{

    class Integral
    {
        private double n = 1;
        // Dots
        private double dot1;
        private double dot2;
        private double dot3;


        private double j1, j2;
        private double eps, error;

        private double xi;


        public Integral()
        {
            SetDataFromFile();
        }

        // Epsilon set method
        public void SetDataFromFile()
        {
            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            string path = @"WRITE YOUR PATH TO DATA.TXT";
            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

            FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(file);

            this.dot1 = Convert.ToDouble(reader.ReadLine());
            this.dot2 = Convert.ToDouble(reader.ReadLine());
            this.dot3 = Convert.ToDouble(reader.ReadLine());
            this.eps = Convert.ToDouble(reader.ReadLine());

            reader.Close();
            file.Close();
        }
        
        // 
        public void CalculationError()
        {

            do
            {
                double xi;
                n *= 2;
                double i1 = 0, i2 = 0;

                for (int i = 1; i <= n - 1; i++)
                {
                    xi = 1 + i * (dot2 - dot1) / n;
                    i1 += Math.Pow(xi - 1, 2);
                }

                j1 = ((dot2 - dot1) / n) * (Math.Pow(dot1 - 1, 2) / 2 + i1);
                n *= 2;

                for (int i = 1; i <= n - 1; i++)
                {
                    xi = 1 + i * (dot2 - dot1) / n;
                    i2 += Math.Pow(xi - 1, 2);
                }

                j2 = ((dot2 - dot1) / n) * (Math.Pow(dot2 - 1, 2) / 2 + i2);
                error = Math.Abs(j1 - j2);
            } while (error > eps);
        }
        public double SimpsonMethod()
        {
            CalculationError();
            double s1 = 0;
            for (int i = 1; i <= n - 1; i++)
            {
                xi = 1 + i * (dot2 - dot1) / n;
                s1 += Math.Pow(xi - 1, 2);
            }

            double sum1 = ((dot2 - dot1) / n) * (Math.Pow(dot2 - 1, 2) / 2 + s1);

            double s2 = 0;
            for (int i = 1; i <= n - 1; i++)
            {
                xi = dot2 + i * (dot3 - dot2) / n;
                s2 += xi * (2 - xi);
            }
            double sum2 = ((dot3 - dot2) / n) * (dot2 * (dot3 - dot2) / 2 + s2);

            return sum1 + sum2;
        }
        public double TrapezeMethod()
        {
            CalculationError();
            double s31 = 0;
            for (int i = 1; i <= n / 2; i++)
            {
                xi = 1 + (2 * i - 1) * (dot2 - dot1) / n;
                s31 += Math.Pow(xi - 1, 2);
            }
            double s32 = 0;
            for (int i = 1; i <= n / 2 - 1; i++)
            {
                xi = 1 + 2 * i * (dot2 - dot1) / n;
                s32 += Math.Pow(xi - 1, 2);
            }
            double sum3 = ((dot2 - dot1) / (3 * n)) * (Math.Pow(dot2, 2) + 4 * s31 + 2 * s32);

            double s41 = 0;
            for (int i = 1; i <= n / 2; i++)
            {
                xi = dot2 + (2 * i - 1) * (dot3 - dot2) / n;
                s41 += xi * (2 - xi);
            }
            double s42 = 0;
            for (int i = 1; i <= n / 2 - 1; i++)
            {
                xi = dot2 + 2 * i * (dot3 - dot2) / n;
                s42 += xi * (2 - xi);
            }
            double sum4 = ((dot3 - dot2) / (3 * n)) * (dot2 * (2 - dot2) + 4 * s41 + 2 * s42);

            return sum3 + sum4;
        }

        public double GetDot1()
        {
            return dot1;
        }
        public double GetDot2()
        {
            return dot2;
        }
        public double GetDot3()
        {
            return dot3;
        }
        public double GetEps()
        {
            return eps;
        }
    }
}
