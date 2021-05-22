using CommanderGQL.Models;
using HotChocolate;
using HotChocolate.Types;

namespace CommanderGQL.GraphQL
{
  public class Subscription
  {
    [Subscribe]
    [Topic]
    public Platform OnPlatfromAdded([EventMessage] Platform platform)
    {
      return platform;

    }
  }
}