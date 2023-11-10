namespace QuantumJourneys.StructAndEnum.MainCharacter.SelectionOfСharacteristics
{
    public class SelectedStatCharacter
    {
        public int SelectedStat(int oldValue, string leftOrRight)
        {
            if (leftOrRight == "right")
                return oldValue switch
                {
                    0 => 1,
                    1 => 2,
                    2 => 3,
                    3 => 3,
                    _ => 1
                };

            else
                return oldValue switch
                {
                    0 => 0,
                    1 => 0,
                    2 => 1,
                    3 => 2,
                    _ => 1
                };
        }
    }
}
