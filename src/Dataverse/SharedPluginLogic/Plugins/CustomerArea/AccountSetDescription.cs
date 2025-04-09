using DataverseLogic.CustomerArea;
using Microsoft.Extensions.DependencyInjection;
using System.Linq.Expressions;

namespace Dataverse.Plugins.CustomerArea;

public class AccountSetDescription : Plugin
{
    public AccountSetDescription()
    {
        RegisterPluginStep<Account>(
            EventOperation.Create,
            ExecutionStage.PreOperation,
            provider => provider.GetRequiredService<IAccountService>().SetAccountDescriptionOnCreate());

        RegisterPluginStep<Account>(
            EventOperation.Update,
            ExecutionStage.PreOperation,
            provider => provider.GetRequiredService<IAccountService>().SetAccountDescriptionOnUpdate())
            .AddFilteredAttributes(filterAttributes)
            .AddImage(ImageType.PreImage, imageAttributes);
    }

    private readonly Expression<Func<Account, object?>>[] filterAttributes =
    {
        x => x.Name,
        x => x.Description,
    };

    private readonly Expression<Func<Account, object?>>[] imageAttributes =
    {
        x => x.Name,
        x => x.Description,
    };
}