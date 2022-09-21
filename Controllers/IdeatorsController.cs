using BackendInnovation.DTO;
using BackendInnovation.Models;
using BackendInnovation.Requests;
using BackendInnovation.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackendInnovation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdeatorsController : ControllerBase
    {

        //Create an object for IIdeaService Interface
        private readonly IIdeatorService _ideatorService;

        public IdeatorsController(IIdeatorService service)
        {
            this._ideatorService = service;
        }

        // GET: api/<IdeatorController>/Ideator
        [HttpGet]
        public ActionResult<List<Ideator>> Get()
        {
            return _ideatorService.GetIdeator();
        }


        [HttpGet("Display_Ideas")]
        public ActionResult<List<Idea>> FetchOnlyIdeas()
        {
            return _ideatorService.FetchIdeas();
        }
        /*
                // GET api/<IdeatorController>/1
                [HttpGet("{id}")]
                public ActionResult<Ideator> Get(string id)
                {
                    var ExistingIdeator = _ideatorService.Get(id);

                    if (ExistingIdeator == null)
                    {
                        return NotFound($"Idea with Id = {id} not found");
                    }
                    return ExistingIdeator;
                }
        */
        

        // GET api/<IdeatorController>/name
        [HttpGet("{name}")]
        public ActionResult<IdeasByIdeatorNameDTO> Get(string name)
        
        {
            var ExistingIdeator = _ideatorService.GetIdeasByIdeatorName(name);

            if (ExistingIdeator == null)
            {
                return NotFound($"Idea with name = {name} not found");
            }
            return ExistingIdeator;
        }
        






        // POST: api/<IdeasController>
        [HttpPost]
        public ActionResult<Ideator> Post([FromBody] IdeaRequestDTO ideaRequestDTO)
        {
            _ideatorService.Create(ideaRequestDTO);
            return CreatedAtAction(nameof(Get), new { id = ideaRequestDTO.Ideator.Id }, ideaRequestDTO);
        }


    }
}
