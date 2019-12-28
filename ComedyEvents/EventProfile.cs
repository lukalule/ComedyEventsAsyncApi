using AutoMapper;
using ComedyEvents.Dto;
using ComedyEvents.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComedyEvents
{
    public class EventProfile : Profile
    {
        public EventProfile()
        {
            CreateMap<Event, EventDto>();
            CreateMap<Event[], EventDto[]>();
        }
    }
}
