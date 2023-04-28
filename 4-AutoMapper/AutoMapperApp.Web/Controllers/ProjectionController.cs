using AutoMapper;
using AutoMapperApp.Web.DTOs;
using AutoMapperApp.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutoMapperApp.Web.Controllers
{
    public class ProjectionController : Controller
    {
        private readonly IMapper _mapper;

        public ProjectionController(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(EventDateDTO eventDateDTO)
        {
            EventDate eventDate = _mapper.Map<EventDate>(eventDateDTO);
            ViewBag.date = eventDate.Date.ToShortDateString();
            return View();
        }
    }
}
