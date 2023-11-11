//Класс для сохранения созданного персонажа
//------------------------------------------------------------------------------------------------------------------------------------------
namespace QuantumJourneys.Pages.СharacterCreation
{
    //--------------------------------------------------------------------------------------------------------------------------------------
    public class SaveCharacterFromStruct
    {
        //----------------------------------------------------------------------------------------------------------------------------------

        private СharacterСharacteristics сharacterСharacteristics;
        static private string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        //----------------------------------------------------------------------------------------------------------------------------------
        public SaveCharacterFromStruct(СharacterСharacteristics сharacterСharacteristics)
        {
            this.сharacterСharacteristics = сharacterСharacteristics;
            CheckCharacterFile();
            SetCurrentCharacter();
        }
        //----------------------------------------------------------------------------------------------------------------------------------
        private void CheckCharacterFile()
        {
            if (!File.Exists(Path.Combine(folderPath, "character.txt")))
            {
                using (FileStream fs = File.Create(Path.Combine(folderPath, "character.txt"))) { }
            }
        }
        //----------------------------------------------------------------------------------------------------------------------------------
        private void SetCurrentCharacter()
        {
            using (StreamWriter writer = new StreamWriter(Path.Combine(folderPath, "character.txt")))
            {
                writer.WriteLine((int)сharacterСharacteristics.img);
                writer.WriteLine((int)сharacterСharacteristics.gender);
                writer.WriteLine((int)сharacterСharacteristics.eyeColor);
                writer.WriteLine((int)сharacterСharacteristics.hairColor);
                writer.WriteLine((int)сharacterСharacteristics.mentality);
                writer.WriteLine((int)сharacterСharacteristics.profession);
                writer.WriteLine((int)сharacterСharacteristics.character);
                writer.WriteLine(сharacterСharacteristics.strength);
                writer.WriteLine(сharacterСharacteristics.agiluty);
                writer.WriteLine(сharacterСharacteristics.intelligence);
                writer.WriteLine(сharacterСharacteristics.fortune);
                writer.WriteLine(сharacterСharacteristics.characterName);
            }
        }
        //----------------------------------------------------------------------------------------------------------------------------------
    }
    //--------------------------------------------------------------------------------------------------------------------------------------
}
//------------------------------------------------------------------------------------------------------------------------------------------
