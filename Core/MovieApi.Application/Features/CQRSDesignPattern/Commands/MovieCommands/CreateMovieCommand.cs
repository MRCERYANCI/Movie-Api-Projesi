using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Commands.MovieCommands
{
    public class CreateMovieCommand
    {
        public string Title { get; set; }
        public string CoverImageUrl { get; set; }
        public decimal Rating { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }  //Film Süresi
        public DateTime ReleaseDate { get; set; }  //Film Çıkış Tarihi
        public string CreatedYear { get; set; }
        public int CategoryId { get; set; }
        public bool Status { get; set; }
    }
}
