namespace AFS.Payment.BusinessObjects
{
    public class CreditCard
    {
        private readonly string _number;
        private readonly string _card;
        private readonly string _type;
        private readonly bool? _valid;

        public CreditCard(string number, string card, string type, bool? valid)
        {
            _number = number;
            _card = card;
            _type = type;
            _valid = valid;
        }
    }
}