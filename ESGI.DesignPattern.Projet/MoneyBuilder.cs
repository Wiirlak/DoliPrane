namespace ESGI.DesignPattern.Projet
{
    public class MoneyBuilder
    {
        private decimal _value;
        
        public MoneyBuilder WithValue(int value)
        {
            _value = value;
            return this;
        }
        
        public MoneyBuilder WithValue(decimal value)
        {
            _value = value;
            return this;
        }
        
        public Money Build()
        {
            return new Money(_value);
        }
    }
}