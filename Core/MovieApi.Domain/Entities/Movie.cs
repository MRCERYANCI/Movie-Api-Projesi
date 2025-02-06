using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Domain.Entities
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string CoverImageUrl { get; set; }
        public decimal Rating { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }  //Film Süresi
        public DateTime ReleaseDate { get; set; }  //Film Çıkış Tarihi
        public string CreatedYear { get; set; }
        public bool Status { get; set; }


        //Category - Moview Tablosu Arası İlişki
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        //Movie - Review Tablosu Arası İlişki
        public ICollection<Review> Reviews { get; set; }
    }
}
