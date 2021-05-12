using System;

namespace university_binary_tree_v2
{
    class Program
    {
        static void Main(string[] args)
        {
            Position rectorPosition = new Position();
            rectorPosition.Name = "Rector";
            rectorPosition.Salary = 1000;
            rectorPosition.RentPercent = 20;
            rectorPosition.RentValue = (rectorPosition.Salary * rectorPosition.RentPercent) / 100;

            Position vicFinPosition = new Position();
            vicFinPosition.Name = "Vicerector financiero";
            vicFinPosition.Salary = 750;
            vicFinPosition.RentPercent = 10;
            vicFinPosition.RentValue = (vicFinPosition.Salary * vicFinPosition.RentPercent) / 100;

            Position contadorPosition = new Position();
            contadorPosition.Name = "Contador";
            contadorPosition.Salary = 500;
            contadorPosition.RentPercent = 25;
            contadorPosition.RentValue = (contadorPosition.Salary * contadorPosition.RentPercent) / 100;

            Position jefeFinPosition = new Position();
            jefeFinPosition.Name = "Jefe financiero";
            jefeFinPosition.Salary = 610;
            jefeFinPosition.RentPercent = 5;
            jefeFinPosition.RentValue = (jefeFinPosition.Salary * jefeFinPosition.RentPercent) / 100;

            Position secFin1Position = new Position();
            secFin1Position.Name = "Secretaria financiera 1";
            secFin1Position.Salary = 350;
            secFin1Position.RentPercent = 30;
            secFin1Position.RentValue = (secFin1Position.Salary * secFin1Position.RentPercent) / 100;

            Position secFin2Position = new Position();
            secFin2Position.Name = "Secretaria financiera 2";
            secFin2Position.Salary = 310;
            secFin2Position.RentPercent = 25;
            secFin2Position.RentValue = (secFin2Position.Salary * secFin2Position.RentPercent) / 100;

            Position vicAcadPosition = new Position();
            vicAcadPosition.Name = "Vicerector academico";
            vicAcadPosition.Salary = 780;
            vicAcadPosition.RentPercent = 20;
            vicAcadPosition.RentValue = (vicAcadPosition.Salary * vicAcadPosition.RentPercent) / 100;

            Position jefeRegPosition = new Position();
            jefeRegPosition.Name = "Jefe de registro";
            jefeRegPosition.Salary = 640;
            jefeRegPosition.RentPercent = 10;
            jefeRegPosition.RentValue = (jefeRegPosition.Salary * jefeRegPosition.RentPercent) / 100;

            Position sectReg2Position = new Position();
            sectReg2Position.Name = "Secretaria de registro 2";
            sectReg2Position.Salary = 360;
            sectReg2Position.RentPercent = 15;
            sectReg2Position.RentValue = (sectReg2Position.Salary * sectReg2Position.RentPercent) / 100;

            Position sectReg1Position = new Position();
            sectReg1Position.Name = "Secretaria de registro 1";
            sectReg1Position.Salary = 400;
            sectReg1Position.RentPercent = 30;
            sectReg1Position.RentValue = (sectReg1Position.Salary * sectReg1Position.RentPercent) / 100;

            Position asist2Position = new Position();
            asist2Position.Name = "Asistente 2";
            asist2Position.Salary = 170;
            asist2Position.RentPercent = 20;
            asist2Position.RentValue = (asist2Position.Salary * asist2Position.RentPercent) / 100;

            Position mensajeroPosition = new Position();
            mensajeroPosition.Name = "Mensajero";
            mensajeroPosition.Salary = 90;
            mensajeroPosition.RentPercent = 10;
            mensajeroPosition.RentValue = (mensajeroPosition.Salary * mensajeroPosition.RentPercent) / 100;

            Position asist1Position = new Position();
            asist1Position.Name = "Asistente 1";
            asist1Position.Salary = 250;
            asist1Position.RentPercent = 15;
            asist1Position.RentValue = (asist1Position.Salary * asist1Position.RentPercent) / 100;


            UniversityTree universityTree = new UniversityTree();
            universityTree.CreatePosition(null, rectorPosition, null);
            universityTree.CreatePosition(universityTree.Root, vicFinPosition, rectorPosition.Name);

            universityTree.CreatePosition(universityTree.Root, contadorPosition, vicFinPosition.Name);
            universityTree.CreatePosition(universityTree.Root, secFin1Position, contadorPosition.Name);
            universityTree.CreatePosition(universityTree.Root, secFin2Position, contadorPosition.Name);

            universityTree.CreatePosition(universityTree.Root, jefeFinPosition, vicFinPosition.Name);

            universityTree.CreatePosition(universityTree.Root, vicAcadPosition, rectorPosition.Name);
            universityTree.CreatePosition(universityTree.Root, jefeRegPosition, vicAcadPosition.Name);
            universityTree.CreatePosition(universityTree.Root, sectReg2Position, jefeRegPosition.Name);
            universityTree.CreatePosition(universityTree.Root, sectReg1Position, jefeRegPosition.Name);
            universityTree.CreatePosition(universityTree.Root, asist2Position, sectReg1Position.Name);
            universityTree.CreatePosition(universityTree.Root, mensajeroPosition, asist2Position.Name);

            universityTree.CreatePosition(universityTree.Root, asist1Position, sectReg1Position.Name);
                     

            Console.WriteLine("{0,25} {1,6} {2,6} {3,8}", "Position", "  Salary", "  %Rent", "  Rent Value\n");
            universityTree.PrintTree(universityTree.Root);

            Console.WriteLine("");

            float totalSalary = universityTree.AddSalaries(universityTree.Root);
            Console.WriteLine($"    Total salaries : {totalSalary}");

            float higherLeft = universityTree.HigherSalary(universityTree.Root.Left);
            float higherRight = universityTree.HigherSalary(universityTree.Root.Right);
            //Verificar el salario mas alto y se imprime
            if (higherLeft >= higherRight)
            {
                Console.WriteLine($"\n 1) The higher salary is: {higherLeft} ");
            }
            else
            {
                Console.WriteLine($"\n 1) The higher salary is: {higherRight} ");
            }
            //Imprimir promedio de salarios
            Console.WriteLine($"\n 2) The average of salaries is: " +
                $"{totalSalary / universityTree.Count(universityTree.Root)} ");
            PositionNode position = universityTree.SearchNode(universityTree.Root, jefeFinPosition.Name);
            //Imprimir salario medio
            Console.WriteLine($"\n 3) The average salaries from position {position.Position.Name}" + 
                $" is: {universityTree.AddSalaries(position) / universityTree.Count(position)}");
            //Imprimir impuestos totales
            Console.WriteLine($"\n 4) The total rents are: {universityTree.AddRents(universityTree.Root)}");

            Console.ReadLine();

            
        }
    }
}
