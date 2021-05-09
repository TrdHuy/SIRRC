using SIRRC.Base.Logger;
using SIRRC.Base.MVVM.ViewModel;

namespace SIRRC.Base.UIEventHandler.Action.Factory
{
    public class BaseActionFactory : AbstractActionFactory
    {
        public override IAction CreateAction(string builderID, string keyID, BaseViewModel viewModel = null, ILogger logger = null)
        {

            //try to get the registered builder
            IActionBuilder builder = null;
            try
            {
                builder = _builders[builderID];
            }
            catch
            {
                return null;
            }

            // Build the action
            if (!builder.Locker.IsLock)
            {
                return builder.BuildMainAction(keyID);
            }
            else
            {
                return builder.BuildAlternativeActionWhenFactoryIsLock(keyID);
            }
        }

    }
}
