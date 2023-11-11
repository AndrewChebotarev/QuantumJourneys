﻿//Класс для загрузки из файла предыдущий игры
//------------------------------------------------------------------------------------------------------------------------------------------
namespace QuantumJourneys.Pages.NewOrLoadGameSolo
{
    //--------------------------------------------------------------------------------------------------------------------------------------
    public class LoadGameSoloPage
    {
        //----------------------------------------------------------------------------------------------------------------------------------

        private СharacterСharacteristics сharacterСharacteristics;
        static private string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        //----------------------------------------------------------------------------------------------------------------------------------
        public bool CheckOldGame() => File.Exists(Path.Combine(folderPath, "character.txt"));
        //----------------------------------------------------------------------------------------------------------------------------------
        public СharacterСharacteristics GetCurrentCharacterToStruct()
        {
            сharacterСharacteristics = new();

            using (StreamReader reader = new StreamReader(Path.Combine(folderPath, "character.txt")))
            {
                GetCharacterCharacteristicsImg(reader.ReadLine());
                GetCharacterCharacteristicsGender(reader.ReadLine());
                GetCharacterCharacteristicsEyeColor(reader.ReadLine());
                GetCharacterCharacteristicsHairColor(reader.ReadLine());
                GetCharacterCharacteristicsMentality(reader.ReadLine());
                GetCharacterCharacteristicsProfession(reader.ReadLine());
                GetCharacterCharacteristicsCharacter(reader.ReadLine());
                GetCharacterCharacteristicsStrength(reader.ReadLine());
                GetCharacterCharacteristicsAgiluty(reader.ReadLine());
                GetCharacterCharacteristicsIntelligence(reader.ReadLine());
                GetCharacterCharacteristicsFortune(reader.ReadLine());
                GetCharacterCharacteristicsName(reader.ReadLine());
            }

            return сharacterСharacteristics;
        }
        //----------------------------------------------------------------------------------------------------------------------------------
        public void GetCharacterCharacteristicsImg(string img)
        {
            switch (img)
            {
                case "0":
                    сharacterСharacteristics.img = ImgCharacterEnum.FemaleBrownGinger;
                    break;
                case "1":
                    сharacterСharacteristics.img = ImgCharacterEnum.FemaleBrownBlack;
                    break;
                case "2":
                    сharacterСharacteristics.img = ImgCharacterEnum.FemaleBrownBlonde;
                    break;
                case "3":
                    сharacterСharacteristics.img = ImgCharacterEnum.FemaleBlueGinger;
                    break;
                case "4":
                    сharacterСharacteristics.img = ImgCharacterEnum.FemaleBlueBlack;
                    break;
                case "5":
                    сharacterСharacteristics.img = ImgCharacterEnum.FemaleBlueBlonde;
                    break;
                case "6":
                    сharacterСharacteristics.img = ImgCharacterEnum.FemaleGreenGinger;
                    break;
                case "7":
                    сharacterСharacteristics.img = ImgCharacterEnum.FemaleGreenBlack;
                    break;
                case "8":
                    сharacterСharacteristics.img = ImgCharacterEnum.FemaleGreenBlonde;
                    break;
                case "9":
                    сharacterСharacteristics.img = ImgCharacterEnum.MaleBrownGinger;
                    break;
                case "10":
                    сharacterСharacteristics.img = ImgCharacterEnum.MaleBrownBlack;
                    break;
                case "11":
                    сharacterСharacteristics.img = ImgCharacterEnum.MaleBrownBlonde;
                    break;
                case "12":
                    сharacterСharacteristics.img = ImgCharacterEnum.MaleBlueGinger;
                    break;
                case "13":
                    сharacterСharacteristics.img = ImgCharacterEnum.MaleBlueBlack;
                    break;
                case "14":
                    сharacterСharacteristics.img = ImgCharacterEnum.MaleBlueBlonde;
                    break;
                case "15":
                    сharacterСharacteristics.img = ImgCharacterEnum.MaleGreenGinger;
                    break;
                case "16":
                    сharacterСharacteristics.img = ImgCharacterEnum.MaleGreenBlack;
                    break;
                case "17":
                    сharacterСharacteristics.img = ImgCharacterEnum.MaleGreenBlonde;
                    break;
                default:
                    сharacterСharacteristics.img = ImgCharacterEnum.FemaleBrownGinger;
                    break;
            }
        }
        public void GetCharacterCharacteristicsGender(string gender)
        {
            switch (gender)
            {
                case "0":
                    сharacterСharacteristics.gender = GenderEnum.Female;
                    break;
                case "1":
                    сharacterСharacteristics.gender = GenderEnum.Male;
                    break;
                default:
                    сharacterСharacteristics.gender = GenderEnum.Female;
                    break;
            }
        }
        public void GetCharacterCharacteristicsEyeColor(string eyeGender)
        {
            switch (eyeGender)
            {
                case "0":
                    сharacterСharacteristics.eyeColor = EyeColorEnum.Brown;
                    break;
                case "1":
                    сharacterСharacteristics.eyeColor = EyeColorEnum.Blue;
                    break;
                case "2":
                    сharacterСharacteristics.eyeColor = EyeColorEnum.Green;
                    break;
                default:
                    сharacterСharacteristics.eyeColor = EyeColorEnum.Brown;
                    break;
            }
        }
        public void GetCharacterCharacteristicsHairColor(string hairColor)
        {
            switch (hairColor)
            {
                case "0":
                    сharacterСharacteristics.hairColor = HairColorEnum.Ginger;
                    break;
                case "1":
                    сharacterСharacteristics.hairColor = HairColorEnum.Black;
                    break;
                case "2":
                    сharacterСharacteristics.hairColor = HairColorEnum.Blonde;
                    break;
                default:
                    сharacterСharacteristics.hairColor = HairColorEnum.Ginger;
                    break;
            }
        }
        public void GetCharacterCharacteristicsMentality(string mentality)
        {
            switch (mentality)
            {
                case "0":
                    сharacterСharacteristics.mentality = MentalityEnum.Technical;
                    break;
                case "1":
                    сharacterСharacteristics.mentality = MentalityEnum.Humanitarian;
                    break;
                case "2":
                    сharacterСharacteristics.mentality = MentalityEnum.Universal;
                    break;
                default:
                    сharacterСharacteristics.mentality = MentalityEnum.Technical;
                    break;
            }
        }
        public void GetCharacterCharacteristicsProfession(string profession)
        {
            switch (profession)
            {
                case "0":
                    сharacterСharacteristics.profession = ProfessionEnum.Teacher;
                    break;
                case "1":
                    сharacterСharacteristics.profession = ProfessionEnum.Programmer;
                    break;
                case "2":
                    сharacterСharacteristics.profession = ProfessionEnum.Doctor;
                    break;
                case "3":
                    сharacterСharacteristics.profession = ProfessionEnum.Engineer;
                    break;
                case "4":
                    сharacterСharacteristics.profession = ProfessionEnum.Accountant;
                    break;
                case "5":
                    сharacterСharacteristics.profession = ProfessionEnum.Manager;
                    break;
                case "6":
                    сharacterСharacteristics.profession = ProfessionEnum.Advocate;
                    break;
                case "7":
                    сharacterСharacteristics.profession = ProfessionEnum.Salesman;
                    break;
                case "8":
                    сharacterСharacteristics.profession = ProfessionEnum.Comedian;
                    break;
                default:
                    сharacterСharacteristics.profession = ProfessionEnum.Teacher;
                    break;
            }
        }
        public void GetCharacterCharacteristicsCharacter(string character)
        {
            switch (character)
            {
                case "0":
                    сharacterСharacteristics.character = СharacterEnum.Choleric;
                    break;
                case "1":
                    сharacterСharacteristics.character = СharacterEnum.Melancholic;
                    break;
                case "2":
                    сharacterСharacteristics.character = СharacterEnum.Phlegmatic;
                    break;
                case "3":
                    сharacterСharacteristics.character = СharacterEnum.Sanguine;
                    break;
                default:
                    сharacterСharacteristics.character = СharacterEnum.Choleric;
                    break;
            }
        }
        public void GetCharacterCharacteristicsStrength(string strength)
        {
            сharacterСharacteristics.strength = Convert.ToInt32(strength);
        }
        public void GetCharacterCharacteristicsAgiluty(string agiluty)
        {
            сharacterСharacteristics.agiluty = Convert.ToInt32(agiluty);
        }
        public void GetCharacterCharacteristicsIntelligence(string intelligence)
        {
            сharacterСharacteristics.intelligence = Convert.ToInt32(intelligence);
        }
        public void GetCharacterCharacteristicsFortune(string fortune)
        {
            сharacterСharacteristics.fortune = Convert.ToInt32(fortune);
        }
        public void GetCharacterCharacteristicsName(string characterName)
        {
            сharacterСharacteristics.characterName = characterName;
        }
        //----------------------------------------------------------------------------------------------------------------------------------
    }
    //--------------------------------------------------------------------------------------------------------------------------------------
}
//------------------------------------------------------------------------------------------------------------------------------------------
