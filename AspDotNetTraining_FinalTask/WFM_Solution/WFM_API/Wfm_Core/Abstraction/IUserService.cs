using WFM_API.Wfm_Core.ViewModel;
using WFM_API.Wfm_DomainModel;

namespace WFM_API.Wfm_Core.Abstraction
{
    public interface IUserService
    {
        User GetById(int id);
        AuthenticateResponse Authenticate(AuthenticateRequest model);
    }
}
