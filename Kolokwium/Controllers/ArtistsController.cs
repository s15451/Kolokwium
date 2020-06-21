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
                            .OrderByDescending(a => a.PerformanceDate)
                            .ToList();

            return Ok(result);
        }

        [HttpPost]
        public IActionResult UpdatePerformance(PerformanceDateUpdateRequest request) 
        {
            var db = _artistsDbContext;

            var EventTimes = db.Events
                               .Join(db.ArtistsEvents, Event => Event.IdEvent, ArtistEvent => ArtistEvent.IdEvent, (Event, ArtistEvent) => new
                               {
                                   idEvent = Event.IdEvent,
                                   StartDate = Event.StartDate,
                                   EndDate = Event.EndDate,
                                   PerformanceDate = ArtistEvent.PerformanceDate
                               })
                               .Where(e => e.idEvent.Equals(request.IdEvent) &&
                                            e.StartDate < request.PerformanceDate && e.EndDate > request.PerformanceDate)
                               .Select(e => new
                               {
                                   IdEvent = e.idEvent,
                                   StartDate = e.StartDate,
                                   EndDate = e.EndDate,
                                   PerformanceDate = e.PerformanceDate
                               })
                               .ToList();

            if (EventTimes.Count.Equals(0)) 
            {
                return BadRequest("No such event exists");
            }

            var artistEvent = db.ArtistsEvents
                                .Where(ae => ae.IdArtist.Equals(request.IdArtist) && ae.IdEvent.Equals(request.IdEvent))
                                .Select(ae => new
                                {
                                    IdArtist = ae.IdArtist,
                                    IdEvent = ae.IdEvent,
                                    PerformanceDate = ae.PerformanceDate
                                });
                                

            return Ok();
        }

    }
}