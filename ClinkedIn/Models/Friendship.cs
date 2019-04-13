
namespace ClinkedIn.Models
{
    public class Friendship
    {
        public int ClinkerOneId { get; set; }
        public int ClinkerTwoId { get; set; }
        public int Id { get; set; }

        public Friendship(int clinkerOneId, int clinkerTwoId)
        {
            ClinkerOneId = clinkerOneId;
            ClinkerTwoId = clinkerTwoId;
        }
    }

}

    
