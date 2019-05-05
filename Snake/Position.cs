namespace Snake
{
    public class Position
    {
        public Position(int xPos, int yPos, char symbol)
        {
            XPos = xPos;
            YPos = yPos;
            Symbol = symbol;
        }

        public int XPos { get; set; }
        public int YPos { get; set; }
        public char Symbol { get; set; }
    }
}