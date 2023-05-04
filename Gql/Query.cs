using HotChocolate.Authorization;

namespace Gql;

public class Query
{
    [Authorize]
    public Book GetBook() => new Book();
}
