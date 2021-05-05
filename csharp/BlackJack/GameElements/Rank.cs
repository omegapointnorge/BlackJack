using System.Collections.Generic;

namespace BlackJack.GameElements
{
    public class Rank : IRank
    {
        private RankValue _value;

        private Dictionary<RankValue, string> ValueMappings { get; } = new Dictionary<RankValue, string>
        {
            {RankValue.Jack, "J"},
            {RankValue.Queen, "Q"},
            {RankValue.King, "K"},
            {RankValue.Ace, "A"}
        };

        public Rank(int value)
        {
            _value = (RankValue)value;
        }

        public Rank(RankValue rank)
        {
            _value = rank;
        }

        public int GetValue()
        {
            if (_value == RankValue.Ace) return 11;
            return (int)_value > 10 ? 10 : (int)_value;
        }

        public RankValue GetRankValue() => _value;

        public void SetValue(int value) => _value = (RankValue)value;

        public override string ToString()
        {
            return ValueMappings.ContainsKey(_value) ? ValueMappings[_value] : ((int)_value).ToString();
        }
    }
}
