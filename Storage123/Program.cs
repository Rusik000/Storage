using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;


namespace ConsoleApp3
{
    abstract class Storage
    {
        public Storage(string model, double capacity, double currentSize)
        {
            Model = model;
            Capacity = capacity;
            CurrentSize = currentSize;
        }

        public string Model { get; set; }

        public double Capacity { get; set; }

        public double CurrentSize { get; set; }

        public abstract void Copy(double size);

        public abstract double FreeMemory();

        public abstract void PrintDeviceInfo();


    }


    class Flash : Storage

    {
        public Flash(string model, double capacity, double currentSize) : base(model, capacity, currentSize)
        {
        }
        private static void WriteBlinkingText(string text, int delay, bool visible)
        {
            if (visible)
                Console.Write(text);
            else
                for (int i = 0; i < text.Length; i++)
                    Console.Write(" ");
            Console.CursorLeft -= text.Length;
            System.Threading.Thread.Sleep(delay);

        }

        public override void Copy(double size)
        {
            CurrentSize = CurrentSize + size;
            string txt = "Flash copy data!";
            int count3 = 10;
            while (count3 == 0)
            {
                WriteBlinkingText(txt, 500, true);
                WriteBlinkingText(txt, 500, false);
                count3--;
            }
            Thread.Sleep(2000);
            Console.WriteLine("Flash Data is copied");
        }

        public override double FreeMemory()
        {
            double freeMemory = Capacity - CurrentSize;
            return freeMemory;
        }

        public override void PrintDeviceInfo()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("=========Flash=========");
            Console.WriteLine($"Model :{Model} ");
            Console.WriteLine($"Capacity :{Capacity} ");
            Console.WriteLine($"CurrentSize :{CurrentSize} ");
            Console.WriteLine();
            Console.ResetColor();
        }
    }


    class SSD : Storage
    {
        public SSD(string model, double capacity, double currentSize) : base(model, capacity, currentSize)
        {
        }


        private static void WriteBlinkingText(string text, int delay, bool visible)
        {
            if (visible)
                Console.Write(text);
            else
                for (int i = 0; i < text.Length; i++)
                    Console.Write(" ");
            Console.CursorLeft -= text.Length;
            System.Threading.Thread.Sleep(delay);

        }

        public override void Copy(double size)
        {
            CurrentSize = CurrentSize + size;
            string txt = "Flash copy data!";
            int count2 = 5;
            while (count2 == 0)
            {
                WriteBlinkingText(txt, 500, true);
                WriteBlinkingText(txt, 500, false);
                count2--;
            }
            Thread.Sleep(500);
            Console.WriteLine("SSD Data is copied");
        }

        public override double FreeMemory()
        {
            double freeMemory = Capacity - CurrentSize;
            return freeMemory;
        }

        public override void PrintDeviceInfo()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("=========SSD=========");
            Console.WriteLine($"Model :{Model} ");
            Console.WriteLine($"Capacity :{Capacity} ");
            Console.WriteLine($"CurrentSize :{CurrentSize} ");
            Console.WriteLine();
            Console.ResetColor();
        }


    }

    class HDD : Storage
    {

        public HDD(string model, double capacity, double currentSize) : base(model, capacity, currentSize)
        {
        }

        private static void WriteBlinkingText(string text, int delay, bool visible)
        {
            if (visible)
                Console.Write(text);
            else
                for (int i = 0; i < text.Length; i++)
                    Console.Write(" ");
            Console.CursorLeft -= text.Length;
            System.Threading.Thread.Sleep(delay);

        }
        public override void Copy(double size)
        {
            CurrentSize = CurrentSize + size;
            string txt = "Flash copy data!";
            int count1 = 20;
            while (count1 == 0)
            {
                WriteBlinkingText(txt, 500, true);
                WriteBlinkingText(txt, 500, false);
                count1--;
            }
            Thread.Sleep(4000);

            Console.WriteLine("HDD Data is copied");
        }

        public override double FreeMemory()
        {
            double freeMemory = Capacity - CurrentSize;
            return freeMemory;
        }

        public override void PrintDeviceInfo()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("=========HDD=========");
            Console.WriteLine($"Model :{Model} ");
            Console.WriteLine($"Capacity :{Capacity} ");
            Console.WriteLine($"CurrentSize :{CurrentSize} ");
            Console.WriteLine();
            Console.ResetColor();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            Storage HDD = new HDD("An EIDE Hard Disk Drive", 100, 30);
            Storage SSD = new SSD("M2 drive ", 500, 320);
            Storage Flash = new Flash(" My flash", 150, 50);

        label:
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("1.Copy Data");
            Console.WriteLine("2.Show Device Info");
            Console.WriteLine("3.Show FreeMemory");
            Console.ResetColor();
            int select = int.Parse(Console.ReadLine());
            Console.Clear();
            if (select == 1)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("1.HDD");
                Console.WriteLine("2.SSD");
                Console.WriteLine("3.Flash");
                Console.WriteLine("4.Back");
                Console.ResetColor();
                Console.Write("Do choise :");
                int select1 = int.Parse(Console.ReadLine());
                Console.Clear();
                if (select1 == 1)
                {
                    Console.WriteLine("How many data do you want to copy ?");
                    int DataSize1 = int.Parse(Console.ReadLine());
                    HDD.Copy(DataSize1);
                label1:
                    Console.WriteLine("For return back click R");
                    string returnback = Console.ReadLine();
                    if (returnback == "R" || returnback == "r")
                    {
                        Console.Clear();
                        goto label;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Again Please");
                        goto label1;
                    }


                }

                else if (select1 == 2)
                {
                    Console.WriteLine("How many data do you want to copy ?");
                    int DataSize2 = int.Parse(Console.ReadLine());
                    SSD.Copy(DataSize2);
                label2:
                    Console.WriteLine("For return back click R");
                    string returnback = Console.ReadLine();
                    if (returnback == "R" || returnback == "r")
                    {
                        Console.Clear();
                        goto label;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Again Please");
                        goto label2;
                    }
                }
                else if (select1 == 3)
                {
                    Console.WriteLine("How many data do you want to copy ?");
                    int DataSize3 = int.Parse(Console.ReadLine());
                    Flash.Copy(DataSize3);
                label3:
                    Console.WriteLine("For return back click R");
                    string returnback = Console.ReadLine();
                    if (returnback == "R" || returnback == "r")
                    {
                        Console.Clear();
                        goto label;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Again Please");
                        goto label3;
                    }
                }
                else if (select1 == 4)
                {
                    goto label;
                }
            }
            else if (select == 2)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("1.HDD");
                Console.WriteLine("2.SSD");
                Console.WriteLine("3.Flash");
                Console.WriteLine("4.Back");
                Console.ResetColor();
                Console.Write("Do choise :");
                int select2 = int.Parse(Console.ReadLine());
                Console.Clear();
                if (select2 == 1)
                {
                    HDD.PrintDeviceInfo();
                label4:
                    Console.WriteLine("For return back click R");
                    string returnback = Console.ReadLine();
                    if (returnback == "R" || returnback == "r")
                    {
                        Console.Clear();
                        goto label;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Again Please");
                        goto label4;
                    }

                }
                else if (select2 == 2)
                {
                    SSD.PrintDeviceInfo();
                label4:
                    Console.WriteLine("For return back click R");
                    string returnback = Console.ReadLine();
                    if (returnback == "R" || returnback == "r")
                    {
                        Console.Clear();
                        goto label;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Again Please");
                        goto label4;
                    }
                }
                else if (select2 == 3)
                {
                    Flash.PrintDeviceInfo();
                label5:
                    Console.WriteLine("For return back click R");
                    string returnback = Console.ReadLine();
                    if (returnback == "R" || returnback == "r")
                    {
                        Console.Clear();
                        goto label;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Again Please");
                        goto label5;
                    }
                }
                else if (select2 == 4)
                {
                    goto label;
                }
            }


            else if (select == 3)
            {

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("1.HDD");
                Console.WriteLine("2.SSD");
                Console.WriteLine("3.Flash");
                Console.WriteLine("4.Back");
                Console.ResetColor();
                Console.Write("Do choise :");
                int select3 = int.Parse(Console.ReadLine());
                Console.Clear();
                if (select3 == 1)
                {
                    double free1 = HDD.FreeMemory();
                    Console.WriteLine($"FreeMemory  :{free1} GB");

                label6:
                    Console.WriteLine("For return back click R");
                    string returnback = Console.ReadLine();
                    if (returnback == "R" || returnback == "r")
                    {
                        Console.Clear();
                        goto label;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Again Please");
                        goto label6;
                    }
                }
                else if (select3 == 2)
                {
                    double free2 = SSD.FreeMemory();
                    Console.WriteLine($"FreeMemory  :{free2} GB");

                label7:
                    Console.WriteLine("For return back click R");
                    string returnback = Console.ReadLine();
                    if (returnback == "R" || returnback == "r")
                    {
                        Console.Clear();
                        goto label;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Again Please");
                        goto label7;
                    }
                }
                else if (select3 == 3)
                {
                    double free3 = Flash.FreeMemory();
                    Console.WriteLine($"FreeMemory  :{free3} GB");
                label8:
                    Console.WriteLine("For return back click R");
                    string returnback = Console.ReadLine();
                    if (returnback == "R" || returnback == "r")
                    {
                        Console.Clear();
                        goto label;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Again Please");
                        goto label8;
                    }
                }
                else if (select3 == 4)
                {
                    goto label;
                }

            }
        }
    }
}