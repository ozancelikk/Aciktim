using Core.Entities.Concrete.DBEntities;
using System.Collections.Generic;

namespace Core.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
        AccessToken CreateTokenForUser(User user, List<OperationClaim> claims);
        AccessToken CreateTokenForCustomer(Customer customer, List<OperationClaim> claims);
        AccessToken CreateTokenForRestaurant(Restaurant restaurant, List<OperationClaim> claims);
    }
}
