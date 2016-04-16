using System;

namespace RobotCleaner
{
    class Program
    {


        static void Main(string[] args)
        {
            RobotCleanerLib.RobotCleaner robot = RobotCleanerLib.RobotCleanerFactory.CreateHashSet(10, 10, -100000, 100000);

            int x = -10;
            x = Math.Abs(x);

            Console.WriteLine("teste");
            Console.ReadLine();

            //long value = places.LongLength;

            //int numberOfTestes = int.Parse(Console.ReadLine());
            //string position = Console.ReadLine();

            //int x = int.Parse(position.Split(' ')[0]);
            //int y = int.Parse(position.Split(' ')[1]);

            ////robot = new RobotCleanerLib.RobotCleaner(places, x, y, 100000, 200000, 200000);

            //string command = string.Empty;
            //string direction = string.Empty;
            //int steps = 0;

            //for (int i = 0; i < numberOfTestes; i++)
            //{
            //    command = Console.ReadLine();

            //    direction = command.Split(' ')[0];
            //    steps = int.Parse(command.Split(' ')[1]);

            //    robot.Clean(direction, steps);
            //}

            //Console.WriteLine(robot.PlacesCleaned);
        }


    }
}
