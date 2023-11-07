using System;

namespace Classes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
        }

        public bool IsCitizenElegible(Citizen citizen)
        {
            int score = 0;
            int parametri = 13;

            if(citizen == null|| citizen.HasDebt)
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

            switch (citizen.ChildCount)
            {
                case 0:
                    score += 0;
                    break;
                case 1:
                    score += 8;
                    break;
                case 2:
                    score += 16;
                    break;
                case 3:
                    score += 24;
                    break;
                case >= 4:
                    score += 30;
                    break;
            }

            if(citizen.GradeMaturita > 90)
                score += 30;

            if (citizen.AverageUniversityGrade > 28)
                score += 30;

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
