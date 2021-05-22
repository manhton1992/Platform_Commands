using CommanderGQL.Data;
using HotChocolate;
using System.Threading.Tasks;
using CommanderGQL.GraphQL.Platforms;
using CommanderGQL.Models;
using HotChocolate.Data;
using CommanderGQL.GraphQL.Commands;
using HotChocolate.Subscriptions;
using System.Threading;
using Microsoft.EntityFrameworkCore;

namespace CommanderGQL.GraphQL
{
  public class Mutation
  {
    [UseDbContext(typeof(AppDbContext))]
    public async Task<AddPlatformPayload> AddPlatformAsync(
      AddPlatformInput input,
      [ScopedService] AppDbContext context
      // ,
      // [Service] ITopicEventSender eventSender,
      // CancellationToken cancellationToken
      )
    {

      var platform = new Platform
      {
        Name = input.name
      };

      context.Platforms.Add(platform);
      await context.SaveChangesAsync();
      
      // await context.SaveChangesAsync(cancellationToken);
      // await eventSender.SendAsync(nameof(Subscription.OnPlatfromAdded), platform, cancellationToken);

      return new AddPlatformPayload(platform);
    }

    [UseDbContext(typeof(AppDbContext))]
    public async Task<AddCommandPayload> AddCommandAsync(AddCommandInput input,
    [ScopedService] AppDbContext context)
    {
      var command = new Command
      {
        HowTo = input.HowTo,
        CommandLine = input.CommandLine,
        PlatformId = input.PlatformId
      };

      context.Commands.Add(command);
      await context.SaveChangesAsync();

      return new AddCommandPayload(command);
    }
  }
}
