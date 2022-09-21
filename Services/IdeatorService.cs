using BackendInnovation.DatabaseSettings;
using BackendInnovation.DTO;
using BackendInnovation.Models;
using BackendInnovation.Requests;
using MongoDB.Driver;
using System.Collections.Generic;

namespace BackendInnovation.Services
{
    public class IdeatorService : IIdeatorService
    {
        //Create attribute
        private readonly IMongoCollection<Ideator> _ideator;
        private readonly IMongoCollection<Idea> _ideas;
        private readonly IMongoCollection<Segment> _segment;
        // Connect database

        public IdeatorService(IBackendDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _ideator = database.GetCollection<Ideator>(settings.IdeaCollectionName);
            _ideas = database.GetCollection<Idea>("Ideas");
            _segment = database.GetCollection<Segment>("Segments");

        }
        public IdeaRequestDTO Create(IdeaRequestDTO ideaRquestDTO)
        {
            _ideator.InsertOne(ideaRquestDTO.Ideator);
            ideaRquestDTO.Idea.IdeatorId = ideaRquestDTO.Ideator.Id.ToString();
            _ideas.InsertOne(ideaRquestDTO.Idea);
            ideaRquestDTO.Segment.IdeaId = ideaRquestDTO.Idea.Id.ToString();
            _segment.InsertOne(ideaRquestDTO.Segment);
            return ideaRquestDTO;

        }

        public List<Idea> FetchIdeas()
        {
            return _ideas.Find(_ => true).ToList();
        }

        //Service for ideators
        public List<Ideator> GetIdeator()
        {
            return _ideator.Find(ideator => true).ToList();
        }

        public Ideator GetIdeator(string id)
        {
            return _ideator.Find(ideator => ideator.Id.ToString() == id).FirstOrDefault();
        }

        public IdeasByIdeatorNameDTO GetIdeasByIdeatorName(string name)
        {
            var foundIdeator = _ideator.Find(_ => _.Name == name).First();
            List<Idea> ideas = new List<Idea>();
            IdeasByIdeatorNameDTO ideasByIdeatorNameDTO = new IdeasByIdeatorNameDTO();

            if (foundIdeator is not null)
            {
                ideas = _ideas.Find(_ => _.IdeatorId == foundIdeator.Id.ToString()).ToList();
                return new IdeasByIdeatorNameDTO()
                {
                    Ideas = ideas,
                    Name = foundIdeator.Name
                };
            }
            return ideasByIdeatorNameDTO;

        }

        public void Update(string id, Ideator ideator)
        {
            throw new NotImplementedException();
        }

        public List<IdeaRequestDTO> GetAll()
        {
            return null;
        }
        /*
        public List<IdeaRequestDTO> GetAll()
        {
            var ideator = _ideator.Find(_ => true).ToList();
            var ideas = _ideas.Find(_ => true).ToList();
            var segments = _segment.Find(_ => true).ToList();
            var _getall = 

            if (_getall == true)
            {
                _getall = ideator.Concat
            }
        }

        */

        /*
       public List<Idea> GetIdeas()
       {
           return _ideas.Find(_ => true).ToList(); 
       }

       public List<Segment> GetSegments()
       {
           return _segment.Find(_ => true).ToList();
       }
*/
    }
}
