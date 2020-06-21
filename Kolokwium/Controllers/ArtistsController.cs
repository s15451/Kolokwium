using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kolokwium.Models;
using Kolokwium.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium.Controllers
{
    [Route("api/artists")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        private readonly ArtistsDbContext _artistsDbContext;

        public ArtistsController(ArtistsDbContext artistsDbContext)
        {
            _artistsDbContext = artistsDbContext;
        }

        [HttpGet]
        public IActionResult GetArtists(int idArtist)
        {
            var db = _artistsDbContext;

            var result = db.Artists
                            .Where(a => a.IdArtist.Equals(idArtist))
                            .Join(db.ArtistsEvents, Artist => Artist.IdArtist, ArtistEvent => ArtistEvent.IdArtist, (Artist, ArtistEvent) => new
                            {
                                idArtist = Artist.IdArtist,
                                Nickname = Artist.Nickname,
                                PerformanceDate = ArtistEvent.PerformanceDate
                            })
                            .Select(a => new
                            {
                                Nickname = a.Nickname,
                                PerformanceDate = a.PerformanceDate
                            })
                            .OrderByDescending(a => a.PerformanceDate);

            return Ok(result);
        }

        [HttpPost]
        public IActionResult UpdatePerformance(PerformanceDateUpdateRequest request) 
        {
            var db = _artistsDbContext;


            return Ok();
        }

    }
}