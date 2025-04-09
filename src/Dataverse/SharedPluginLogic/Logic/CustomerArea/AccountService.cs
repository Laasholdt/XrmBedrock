using Microsoft.Xrm.Sdk;
using SharedContext.Dao;

namespace DataverseLogic.CustomerArea;

public class AccountService : IAccountService
{
    private readonly IPluginExecutionContext pluginContext;
    private readonly IAdminDataverseAccessObjectService adminDao;
    private readonly IUserDataverseAccessObjectService dao;
    private readonly ITracingService tracingService;

    public AccountService(
        IPluginExecutionContext pluginContext,
        IAdminDataverseAccessObjectService adminDao,
        IUserDataverseAccessObjectService dao,
        ITracingService tracingService)
    {
        this.pluginContext = pluginContext;
        this.adminDao = adminDao;
        this.dao = dao;
        this.tracingService = tracingService;
    }

    public void SetAccountDescriptionOnCreate()
    {
        var target = pluginContext.GetTarget<Account>();

        // Some operation that uses AdminDao
        adminDao.RetrieveFirstOrDefault(xrm => xrm.AccountSet
            .Where(a => a.Id == target.Id)
            .Select(a => new { a.Name, a.Description }));

        SetDescription(target);

        tracingService.Trace($"Account '{target.Name}' created successfully.");
    }

    public void SetAccountDescriptionOnUpdate()
    {
        var target = pluginContext.GetTarget<Account>();
        var preImage = pluginContext.GetTargetMergedWithPreImage<Account>();

        // Some operation that uses Dao
        dao.RetrieveFirstOrDefault(xrm => xrm.AccountSet
            .Where(a => a.Id == target.Id)
            .Select(a => new { a.Name, a.Description }));

        SetDescription(target, preImage);

        tracingService.Trace($"Account '{target.Name}' updated successfully.");
    }

    private static void SetDescription(Account account, Account? preImage = null)
    {
        account.Description = $"{account.Name ?? preImage?.Name}\n\n{account.Description ?? preImage?.Description}";
    }
}