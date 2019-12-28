using AutoMapper;
using ComedyEvents.Dto;
using ComedyEvents.Models;
using ComedyEvents.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ComedyEvents.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventRepository _repository;
        private readonly IMapper _mapper;

        public EventsController(IEventRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<EventDto[]>> Get(bool includeGigs = false)
        {
            try
            {
                var results =  await _repository.GetEvents(includeGigs);
                var mappedEntities = _mapper.Map<EventDto[]>(results);


                //ventDto[] eventDtos = new EventDto[results.Length];
                
                //for (int i = 0; i < results.Length; i++)
                //{
                //    var result = results[i];
                //    eventDtos[i] = new EventDto()
                //    {
                //        EventId = result.EventId,
                //        EventDate = result.EventDate,
                //        EventName = result.EventName,  
                //        Venue = new VenueDto()
                //        {
                //            VenueId = result.Venue.VenueId,
                //            City = result.Venue.City,
                //            Seating = result.Venue.Seating,
                //            ServesAlcohol = result.Venue.ServesAlcohol,
                //            State = result.Venue.State,
                //            Street = result.Venue.Street,
                //            VenueName = result.Venue.VenueName,
                //            ZipCode = result.Venue.ZipCode
                //        },                        
                        
                //    };
                //    if (includeGigs)
                //    {
                //        //var gigs = result.Gigs.ToAsyncEnumerable();
                //        //await gigs.ForEachAsync((gig, j) =>
                //        //{
                //        //    Debug.WriteLine(gig.GigHeadline + " LMAO");
                //        //});
                //        var gigsList = result.Gigs.ToList();
                //        var gigDtoList = new List<GigDto>();
                //        foreach (var gig in gigsList)
                //        {
                //            gigDtoList.Add(new GigDto()
                //            {
                //                Comedian = new ComedianDto()
                //                {
                //                    ComedianId = gig.Comedian.ComedianId,
                //                    FirstName = gig.Comedian.FirstName,
                //                    LastName = gig.Comedian.LastName,
                //                    ContactPhone = gig.Comedian.ContactPhone
                //                },
                //                GigHeadline = gig.GigHeadline,
                //                GigId = gig.GigId,
                //                GigLengthInMinutes = gig.GigLengthInMinutes,                                
                //            });
                //        }
                //        eventDtos[i].Gigs = gigDtoList;
                //    }
                //}
                return Ok(mappedEntities);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        //public async IAsyncEnumerable<GigDto> fetchGigDtosAsync(Event e)
        //{
        //    foreach (var gig in e.Gigs)
        //    {
        //        await smtn
        //        GigDto gigDto = new GigDto()
        //        {                    
        //            ComedianId = gig.Comedian.ComedianId,
        //            GigHeadline = gig.GigHeadline,
        //            GigId = gig.GigId,
        //            GigLengthInMinutes = gig.GigLengthInMinutes
        //        };
        //        yield return gigDto;
        //    }
        //}

    }
}
