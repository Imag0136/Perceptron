﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab0
{
    class Neuron
    {
        //public int T { get; set; }
        //public int error;
        public int limit = 0;
        public double sum = 0;
        //public int picturesCount = 10;
         // скорость обучения
        public int[,] imgArray = new int[100, 100];
        public double[,] weightArray = new double[100, 100];
        public double[,] y = new double[100, 100];

        public Neuron ()
        {
            //Установление случайных весов_________________________________________
            Random rand = new Random((int)DateTime.Now.Ticks);
            for (int i = 0; i < 100; i++)
                for (int j = 0; j < 100; j++)
                    weightArray[i, j] = Convert.ToDouble(rand.Next(-3, 4) / 10.0);
            //_____________________________________________________________________
        }

        public bool Learn(Bitmap img)
        {            
            for (int i = 0; i < img.Width; i++)
            {
                for (int j = 0; j < img.Height; j++)
                {
                    if (img.GetPixel(i, j) == Color.FromArgb(255, 0, 0, 0))
                    {
                        imgArray[i, j] = 1;
                        y[i, j] = imgArray[i, j] * weightArray[i, j];
                        sum += y[i, j];
                    }
                }
            }

            return sum > limit;
            //StreamWriter sw = new StreamWriter(@"C:\Users\Imag0136\Pictures\text.txt");
            //for (int i = 0; i < img.Height; i++)
            //{
            //    for (int j = 0; j < img.Width; j++)
            //    {
            //        sw.Write($"{imgArray[j, i]}");
            //    }
            //    sw.WriteLine();
            //}
            //sw.Close();
        }
    }
}
