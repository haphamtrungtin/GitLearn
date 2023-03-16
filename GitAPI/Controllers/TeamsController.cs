using AutoMapper;
using GitAPI.DTO;
using GitLearn.DAL.Repositories.Interface;
using GitLearn.DAL.UnitOfWork;
using GitLearn.Data;
using GitLearn.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GitAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ITeamService _teamService;

        public TeamsController(ITeamService teamService, IMapper mapper,IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _teamService = teamService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Team>> GetById(int id)
        {
            var team = await _teamService.GetByIdAsync(id);
            var mappedTeam = _mapper.Map<TeamDTO>(team);
            if(mappedTeam is null)
            {
                return NotFound();
            }
            return Ok(mappedTeam);
        }
        [HttpGet]
        public async Task<ActionResult<List<Team>>> GetAll()
        {
            var teams = await _teamService.GetAllAsync();
            var mappedTeams = _mapper.Map<List<TeamDTO>>(teams);
            if(mappedTeams is null)
            {
                return NotFound();
            }
            return Ok(mappedTeams);
        }

        [HttpPut]
        public async Task<ActionResult<Team>> UpdateTeam(TeamDTO teamDTO)
        {
            var team = await _teamService.GetByIdAsync(teamDTO.Id);
            if(team is null)
                return NotFound();

            _mapper.Map(teamDTO, team);
            _teamService.Update(team);
            _unitOfWork.Save();
            return Ok(team);
        }

        [HttpPost]
        public async Task<ActionResult<Team>> CreateTeam(TeamDTO teamDTO)
        {
            if (teamDTO is null)
                return NotFound();
            
            var team = _mapper.Map<Team>(teamDTO);
            _teamService.Create(team);
            _unitOfWork.Save();
            return Ok(team);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Team>> DeleteTeam(int id)
        {
            var team = await _teamService.GetByIdAsync(id);
            if(team is null)
                return NotFound();
            _teamService.Delete(team);
            _unitOfWork.Save();

            return Ok(team);
        }
    }
}
