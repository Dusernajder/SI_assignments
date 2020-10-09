namespace CreateClass
{
    public class Room
    {
        private int _number;

        public int Number
        {
            get => _number;
            set => _number = value;
        }

        public Room(int roomNumber)
        {
            _number = roomNumber;
        }

        public override string ToString()
        {
            return $"{Number}";
        }
    }
}