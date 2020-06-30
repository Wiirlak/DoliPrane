namespace ESGI.DesignPattern.Projet
{
    public class ReceiptBuilder
    {
        private Money _amount;
        private Money _tax;
        private Money _total;
        
        public ReceiptBuilder WithAmount(Money amount)
        {
            _amount = amount;
            return this;
        }
        
        public ReceiptBuilder WithTax(Money tax)
        {
            _tax = tax;
            return this;
        }
        
        public ReceiptBuilder WithTotal(Money total)
        {
            _total = total;
            return this;
        }

        public Receipt Build()
        {
            return new Receipt(_amount, _tax, _total);
        }
    }
    
    
}