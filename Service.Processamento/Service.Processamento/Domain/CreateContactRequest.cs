namespace Service.Processamento.Domain
{
    public class CreateContactRequest
    {
        public string? Name { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }

        public string? CodeRegion { get; set; }

        public string? FeedbackMessage { get; set; }
    }
}
