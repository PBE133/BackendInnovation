using BackendInnovation.Models;

namespace BackendInnovation.Requests
{
    public class IdeaRequestDTO
    {
        public Ideator Ideator { get; set; }
        public Idea Idea { get; set; }
        public Segment Segment { get; set; }
    }
}
