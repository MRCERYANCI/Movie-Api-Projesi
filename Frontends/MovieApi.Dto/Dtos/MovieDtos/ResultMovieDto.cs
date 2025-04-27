using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Dto.Dtos.MovieDtos
{
    public class ResultMovieDto
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
        public int CategoryId { get; set; }
    }
}
