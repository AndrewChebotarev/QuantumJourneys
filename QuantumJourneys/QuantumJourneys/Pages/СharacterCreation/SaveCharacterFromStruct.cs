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
#if DEBUG
            MyLogger.logger.LogInformation("Начало записи данных нового персонажа.");
#endif
            this.сharacterСharacteristics = сharacterСharacteristics;
            CheckCharacterFile();
            SetCurrentCharacter();
#if DEBUG
            MyLogger.logger.LogInformation("Конец записи данных нового персонажа.");
#endif
        }
        //----------------------------------------------------------------------------------------------------------------------------------
        private void CheckCharacterFile()
        {
#if DEBUG
            MyLogger.logger.LogInformation("Проверка существования файла характеристик персонажа.");
#endif
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
#if DEBUG
            MyLogger.logger.LogInformation($"В файл записаны данные - {сharacterСharacteristics.img}, {сharacterСharacteristics.gender}," +
                $"{сharacterСharacteristics.eyeColor}, {сharacterСharacteristics.hairColor}, {сharacterСharacteristics.mentality}, " +
                $"{сharacterСharacteristics.profession}, {сharacterСharacteristics.character}, {сharacterСharacteristics.strength}," +
                $"{сharacterСharacteristics.agiluty}, {сharacterСharacteristics.intelligence}, {сharacterСharacteristics.fortune}," +
                $"{сharacterСharacteristics.characterName}.");
#endif
        }
        //----------------------------------------------------------------------------------------------------------------------------------
    }
    //--------------------------------------------------------------------------------------------------------------------------------------
}
//------------------------------------------------------------------------------------------------------------------------------------------
