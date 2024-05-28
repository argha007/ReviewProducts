using System.ComponentModel.DataAnnotations;

namespace Data.Model
{
    public class ReviewForProductModel
    {
        public int ProductId { get; set; }
        public ScoreValues Score { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public bool IsRecommended { get; set; }

        public ReviewModel ToReviewModel()
        {
            return new ReviewModel
            {
                ProductId = this.ProductId,
                Score = (int)this.Score,
                Title = this.Title,
                Comment = this.Comment,
                IsRecommended = this.IsRecommended
            };
        }

        public enum ScoreValues
        {
            [Display(Name = "0")]
            Zero,
            [Display(Name = "1")]
            One,
            [Display(Name = "2")]
            Two,
            [Display(Name = "3")]
            Three,
            [Display(Name = "4")]
            Four,
            [Display(Name = "5")]
            Five
        }
    }
}
