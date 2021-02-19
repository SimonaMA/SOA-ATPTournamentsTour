using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ATPTournamentsTour.TournamentsList.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ATPTournamentsTour.TournamentsList.Controllers
{
    [Route("api/tournaments")]
    [ApiController]
    public class TournamentsController : ControllerBase
    {
        private readonly ITournamentRepository _tournamentsRepository;
        private readonly IMapper _mapper;

        public TournamentsController(ITournamentRepository tournamentsRepository, IMapper mapper)
        {
            _tournamentsRepository = tournamentsRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.TournamentDto>>> Get(
            [FromQuery] Guid categoryId)
        {
            var result = await _tournamentsRepository.GetTournaments(categoryId);
            return Ok(_mapper.Map<List<Models.TournamentDto>>(result));
        }

        [HttpGet("{tournamentId}")]
        public async Task<ActionResult<Models.TournamentDto>> GetById(Guid tournamentId)
        {
            var result = await _tournamentsRepository.GetTournamentById(tournamentId);
            return Ok(_mapper.Map<Models.TournamentDto>(result));
        }
    }
}