namespace ESGI.DesignPattern.Projet
{
    public class CheckoutBuilder
    {
        private IRepository _repository;
        
        public CheckoutBuilder WithRepository(IRepository repository)
        {
            _repository = repository;
            return this;
        }

        public Checkout Build()
        {
            return new Checkout(_repository);
        }
    }
}