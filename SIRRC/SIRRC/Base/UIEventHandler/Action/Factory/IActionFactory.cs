using SIRRC.Base.Logger;
using SIRRC.Base.MVVM.ViewModel;
using System.Collections.Generic;

namespace SIRRC.Base.UIEventHandler.Action.Factory
{
    public interface IActionFactory
    {
        Dictionary<string, IActionBuilder> Builders { get; }

        IAction CreateAction(string builderID, string keyID, BaseViewModel viewModel = null, ILogger logger = null);

        void UpdateBuilderStatus(string builderID, BuilderStatus status);

        void RegisterBuilder(string builderID, IActionBuilder builder);
    }
}
