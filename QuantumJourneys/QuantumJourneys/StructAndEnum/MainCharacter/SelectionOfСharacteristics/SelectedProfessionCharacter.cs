//Класс для работы с профессией персонажа игрока
//------------------------------------------------------------------------------------------------------------------------------------------
namespace QuantumJourneys.StructAndEnum.MainCharacter.SelectionOfСharacteristics
{
    //--------------------------------------------------------------------------------------------------------------------------------------
    public class SelectedProfessionCharacter
    {
        //----------------------------------------------------------------------------------------------------------------------------------
        private Dictionary<ProfessionEnum, string> ProfessionDictonary_Ru = new()
        {
            { ProfessionEnum.Teacher, "Учитель" },
            { ProfessionEnum.Programmer, "Программист" },
            { ProfessionEnum.Doctor, "Врач"},
            { ProfessionEnum.Engineer, "Инженер"},
            { ProfessionEnum.Accountant, "Бухгалтер"},
            { ProfessionEnum.Manager, "Менеджер"},
            { ProfessionEnum.Advocate, "Адвокат"},
            { ProfessionEnum.Salesman, "Продавец"},
            { ProfessionEnum.Comedian, "Комик"}
        };
        private Dictionary<ProfessionEnum, string> ProfessionDictonary_En = new()
        {
            { ProfessionEnum.Teacher, "Teacher" },
            { ProfessionEnum.Programmer, "Programmer" },
            { ProfessionEnum.Doctor, "Doctor"},
            { ProfessionEnum.Engineer, "Engineer"},
            { ProfessionEnum.Accountant, "Accountant"},
            { ProfessionEnum.Manager, "Manager"},
            { ProfessionEnum.Advocate, "Advocate"},
            { ProfessionEnum.Salesman, "Salesman"},
            { ProfessionEnum.Comedian, "Comedian"}
        };
        //----------------------------------------------------------------------------------------------------------------------------------
        public ProfessionEnum SelectedProfession(ProfessionEnum profession, string leftOrRight)
        {
            if (leftOrRight == "right")
                return profession switch
                {
                    ProfessionEnum.Teacher => ProfessionEnum.Programmer,
                    ProfessionEnum.Programmer => ProfessionEnum.Doctor,
                    ProfessionEnum.Doctor => ProfessionEnum.Engineer,
                    ProfessionEnum.Engineer => ProfessionEnum.Accountant,
                    ProfessionEnum.Accountant => ProfessionEnum.Manager,
                    ProfessionEnum.Manager => ProfessionEnum.Advocate,
                    ProfessionEnum.Advocate => ProfessionEnum.Salesman,
                    ProfessionEnum.Salesman => ProfessionEnum.Comedian,
                    ProfessionEnum.Comedian => ProfessionEnum.Teacher,
                    _ => ProfessionEnum.Teacher
                };

            else
                return profession switch
                {
                    ProfessionEnum.Teacher => ProfessionEnum.Comedian,
                    ProfessionEnum.Comedian => ProfessionEnum.Salesman,
                    ProfessionEnum.Salesman => ProfessionEnum.Advocate,
                    ProfessionEnum.Advocate => ProfessionEnum.Manager,
                    ProfessionEnum.Manager => ProfessionEnum.Accountant,
                    ProfessionEnum.Accountant => ProfessionEnum.Engineer,
                    ProfessionEnum.Engineer => ProfessionEnum.Doctor,
                    ProfessionEnum.Doctor => ProfessionEnum.Programmer,
                    ProfessionEnum.Programmer => ProfessionEnum.Teacher,
                    _ => ProfessionEnum.Teacher
                };
        }
        //----------------------------------------------------------------------------------------------------------------------------------
        public string NewTextProfession(string language, ProfessionEnum profession)
        {
            if (language == "Ru") return ProfessionDictonary_Ru[profession];
            else if (language == "En") return ProfessionDictonary_En[profession];
            else return ProfessionDictonary_En[profession];
        }
        //----------------------------------------------------------------------------------------------------------------------------------
    }
    //--------------------------------------------------------------------------------------------------------------------------------------
}
//------------------------------------------------------------------------------------------------------------------------------------------
