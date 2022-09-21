using BackendInnovation.DTO;
using BackendInnovation.Models;
using BackendInnovation.Requests;

namespace BackendInnovation.Services
{
    public interface IIdeatorService
    {
        List<Ideator> GetIdeator();
        Ideator GetIdeator(string id);
        List<Idea> FetchIdeas();
        IdeaRequestDTO Create(IdeaRequestDTO ideaRquestDTO);
        void Update(string id, Ideator ideator);
        //List<IdeasByIdeatorNameDTO> GetIdeasByIdeatorName(string name);
        public IdeasByIdeatorNameDTO GetIdeasByIdeatorName(string name);
        List<IdeaRequestDTO> GetAll();

        // List<Idea> GetIdeas();

        // List<Segment> GetSegments();

    }
}
