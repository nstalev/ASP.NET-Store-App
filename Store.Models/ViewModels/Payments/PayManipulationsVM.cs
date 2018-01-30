namespace Store.Models.ViewModels.Payments
{
    public class PayManipulationsVM
    {
        public string Description { get; set; }

        public int Amount { get; set; }

        public string ManipulationDate { get; set; }

        public int TimeNeeded { get; set; }

        public string Category { get; set; }

    }
}
