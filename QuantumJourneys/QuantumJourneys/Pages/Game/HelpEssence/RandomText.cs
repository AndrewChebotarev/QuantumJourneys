//Класс с функцие получения случайного текста
//--------------------------------------------------------------------------------------------------------------------------------------
using System.Linq;

namespace QuantumJourneys.Pages.Game.HelpFunction
{

    //----------------------------------------------------------------------------------------------------------------------------------
    public class RandomText
    {
        //--------------------------------------------------------------------------------------------------------------------------------------

        private int randomCounterText = 0;
        private Random rnd_Number = new();

        private List<(int, int)> numberSelectedRandomText = new();

        //--------------------------------------------------------------------------------------------------------------------------------------
        public string GetRandomText(string[][] randomText)
        {
            int value = rnd_Number.Next(0, GetNumberLineInText(randomText) - 1);
            string receivedText = randomText[randomCounterText][value];
            randomCounterText++;
            return receivedText;
        }
        private int GetNumberLineInText(string[][] randomText) => randomText[randomCounterText].Count();
        //----------------------------------------------------------------------------------------------------------------------------------
        public string GetRandomText(int numberLine, string[][] variationText)
        {
            int value = rnd_Number.Next(0, GetNumberLineInText(numberLine, variationText) - 1);

            while (numberSelectedRandomText.Contains((numberLine, value))) value = rnd_Number.Next(0, GetNumberLineInText(numberLine, variationText) - 1);
            numberSelectedRandomText.Add((numberLine, value));

            string receivedText = variationText[numberLine][value];
            return receivedText;
        }
        private int GetNumberLineInText(int numberLine, string[][] randomText) => randomText[numberLine].Count();
        //----------------------------------------------------------------------------------------------------------------------------------
    }
    //----------------------------------------------------------------------------------------------------------------------------------
}
//--------------------------------------------------------------------------------------------------------------------------------------
