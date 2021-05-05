using System.Collections.Generic;

namespace BlackJack.Repositories
{
    public class Rank : IRank
    {
        private readonly int _value;

        private Dictionary<int, string> ValueMappings { get; } = new Dictionary<int, string>
        {
            {10, "J"},
            {11, "Q"},
            {12, "K"},
            {13, "A"}
        };

        public Rank(int value)
        {
            _value = value;
        }

        public int GetValue() =>  _value;

        public override string ToString()
        {
            return ValueMappings.ContainsKey(_value) ? ValueMappings[_value] : _value.ToString();
        }
    }
}
