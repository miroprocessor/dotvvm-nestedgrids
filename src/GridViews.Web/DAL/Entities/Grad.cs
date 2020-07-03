using System.ComponentModel.DataAnnotations;

namespace GridViews.Web.DAL.Entities
{
    public class Grad
    {
        [Key]
        public int Id { get; set; }

        public int StudentId { get; set; }
        public string Subject { get; set; }
        public string Month { get; set; }
        public decimal Score { get; set; }

        public virtual Student Student { get; set; }
    }
}