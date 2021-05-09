
using SIRRC.Base.MVVM.ViewModel;

namespace SIRRC.Base.UIEventHandler.Action
{
    public interface IViewModelCommandExecuter : ICommandExecuter
    {
        BaseViewModel ViewModel { get; }
    }
}
