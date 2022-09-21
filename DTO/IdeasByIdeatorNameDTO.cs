using BackendInnovation.Models;

namespace BackendInnovation.DTO
{
    public class IdeasByIdeatorNameDTO
    {
        public string Name { get; set; }
        public List<Idea> Ideas { get; set; }
       
    }
}
