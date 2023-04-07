using Core.Entities.Abstract;

namespace Entities.DTOs
{
    public class RestaurantClaimDetailsDto : IDto
    {
        public string OperationClaimName { get; set; }
        public string RestaurantName { get; set; }
    }
}
