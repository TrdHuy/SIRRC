using SIRRC.Base.Logger;
using SIRRC.Base.MVVM.ViewModel;
using System.Collections.Generic;

namespace SIRRC.Base.UIEventHandler.Action.Factory
{
    public abstract class AbstractActionFactory : IActionFactory
    {
        protected Dictionary<string, IActionBuilder> _builders { get; set; }

        public AbstractActionFactory()
        {
            _builders = new Dictionary<string, IActionBuilder>();
        }

        public Dictionary<string, IActionBuilder> Builders { get => _builders; }

        public abstract IAction CreateAction(string builderID, string keyID, BaseViewModel viewModel = null, ILogger logger = null);

        public void UpdateBuilderStatus(string builderID, BuilderStatus status)
        {
            _builders[builderID].UpdateBuilderStatus(status);

        }
        public void RegisterBuilder(string builderID, IActionBuilder builder)
        {
            if (!_builders.ContainsKey(builderID))
            {
                _builders.Add(builderID, builder);
            }
        }
    }
}
