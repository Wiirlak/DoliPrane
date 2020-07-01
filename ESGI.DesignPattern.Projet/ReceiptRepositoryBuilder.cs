namespace ESGI.DesignPattern.Projet
{
    public class ReceiptRepositoryBuilder
    {
       
        public ReceiptRepository Build()
        {
            return new ReceiptRepository();
        }
    }
}