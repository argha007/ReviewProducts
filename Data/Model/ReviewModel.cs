namespace Data.Model
{
    public class ReviewModel
    {
        public int Id { get; set; }
        public int Score { get; set; }
        public int ProductId { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public bool IsRecommended { get; set; }
    }
}
