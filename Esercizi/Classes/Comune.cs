using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes.PersonTypes;

namespace Classes
{
    internal class Comune : EntePubblico
    {
        protected int _pilComune;
        protected string _nomeComune;

        public int PilComune { get { return _pilComune; } }
        public string NomeComune { get => _nomeComune; }
        public Comune(string nomeEnte,string nomeComune,int pilComune) : base(nomeEnte)
        {
            _pilComune = pilComune;
            _nomeComune = nomeComune;
        }

        public bool IsCitizenElegible(Citizen citizen)
        {
            //citizen.GetInfo();
            int score = 0;
            int parametri = 7;

            if (citizen == null)
                throw new ArgumentNullException();

            if (citizen.HasDebt)
                return false;
            else
                score += 30;

            if (citizen.HasServiced)
                score += 30;

            if (citizen is Student && citizen.Age >= 18 && citizen.Age <= 25 
                || citizen.IsSenior && !citizen.HasIncome)
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

            if (citizen is Student)
            {
                score += CalcolaStudente((Student)citizen); 
            }

            if (citizen is UniversityStudent)
            {
                score += CalcolaUniversitario((UniversityStudent)citizen);
            }

            if (citizen is Military)
                score += CalcMilitary((Military)citizen);

            if (citizen.ResidencePIL < 100000000)
                score += 30;

            score /= parametri;
             
            if (score >= 25)
                return true;
            else return false;
        }

        private int CalcMilitary(Military citizen)
        {
            if (citizen.YearsOfService >= 1) 
                return 30;
            return 0;
        }

        private int CalcolaStudente(Student student)
        {
            if (student.GradeMaturita >= 90)
                return 30;
            return 0;
        }

        private int CalcolaUniversitario(UniversityStudent student)
        {
            if(student.AverageUniversityGrade >= 28) 
                return 30;
            return 0;
        }
    }
}
