using System;
using System.Collections.Generic;

namespace Classes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Citizen citizen1 = new Citizen(false, true, false,false, 21, 95, 29, 0, 737084);
            Citizen citizen2 = new Citizen(true, true, false,false, 24, 98, 30, 1, 6001000);
            Citizen citizen3 = new Citizen(false, true, false,true, 35, 88, 30, 2, 7004800);
            Citizen citizen4 = new Citizen(true, false, false,false, 71, 95, 21, 0, 9008000);
            Citizen citizen5 = new Citizen(true, false, false, true, 44, 68, 18, 2, 100000001);
            Citizen citizen6 = new Citizen(false, false, false, true, 41, 75, 22, 3, 1800300);
            List<Citizen> list = new List<Citizen>();
            list.Add(citizen1);
            list.Add(citizen2);
            list.Add(citizen3);
            list.Add(citizen4);
            list.Add(citizen5);
            list.Add(citizen6);

            foreach (Citizen citizen in list)
            {
                Console.WriteLine($"is citizen elegible: {IsCitizenElegible(citizen)}");
            }
            Console.Read();
        }

        public static bool IsCitizenElegible(Citizen citizen)
        {
            int score = 0;
            int parametri = 9;

            if (citizen == null) 
                throw new ArgumentNullException();
                
            if(citizen.HasDebt)
                return false;
            
            if(!citizen.HasDebt)
            {
                score += 30;
            }

            if (citizen.IsStudent)
                score += 30;

            if(citizen.HasServiced)
                score += 30;

            if (citizen.Age >= 18 && citizen.Age <= 25 && citizen.IsStudent || citizen.Age > 60 && !citizen.HasIncome)
                score += 30;
            else score += 15;



            switch (citizen.ChildCount)
            {
                case 0:
                    score += 0;
                    break;
                case 1:
                    score += 20;
                    break;
                case 2:
                    score += 25;
                    break;
                case >= 3:
                    score += 30;
                    break;
            }

            if(citizen.GradeMaturita >= 90)
                score += 30;
            else if(citizen.GradeMaturita <= 89 && citizen.GradeMaturita>= 60)
                score += 20;

            if (citizen.AverageUniversityGrade >= 28)
                score += 30;
            else if (citizen.AverageUniversityGrade >= 18)
                score += 15;

            if (!citizen.HasIncome) 
                score += 30;

            if (citizen.ResidencePIL < 100000000) 
                score += 30;

            score /= parametri;

            if (score >= 25)
                return true;
            else return false;
            
        }
    }
}
