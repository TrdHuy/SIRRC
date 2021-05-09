using SIRRC.Base.Logger;
using SIRRC.Base.MVVM.ViewModel;
using SIRRC.Base.UIEventHandler.Action;
using SIRRC.Base.UIEventHandler.Action.Factory;
using SIRRC.Base.UIEventHandler.Helpers;
using SIRRC.Base.UIEventHandler.Listener;
using System.Collections.Generic;

namespace SIRRC.Base.UIEventHandler.Listener
{
    public class KeyActionListener : IActionListener
    {
        private IActionExecuteHelper _actionExecuterHelper;
        private IActionFactory _actionFactory; 

        public KeyActionListener(IActionFactory actionFactory, IActionExecuteHelper actionExecuteHelper)
        {
            _actionExecuterHelper = actionExecuteHelper;
            _actionFactory = actionFactory;
        }

        #region Onkey and execute action field
        public IAction OnKey(string windowTag, string keyFeature, object dataTransfer)
        {
            IAction action = GetKeyActionType(windowTag, keyFeature);
            return action;
        }

        public IAction OnKey(string windowTag, string keyFeature, object dataTransfer, BuilderStatus status)
        {
            IAction action = GetKeyActionAndLockFactory(windowTag, keyFeature, status);
            return action;
        }

        public IAction OnKey(BaseViewModel viewModel, ILogger logger, string windowTag, string keyFeature, object dataTransfer)
        {
            IAction action = GetKeyActionType(windowTag, keyFeature, viewModel, logger);
            return action;
        }

        public IAction OnKey(BaseViewModel viewModel, ILogger logger, string windowTag, string keyFeature, object dataTransfer, BuilderStatus status)
        {
            IAction action = GetKeyActionAndLockFactory(windowTag, keyFeature, status, viewModel, logger);
            return action;
        }

        #endregion

        private IAction GetKeyActionType(string windowTag
            , string keytag
            , BaseViewModel viewModel = null
            , ILogger logger = null)
        {
            return GetAction(keytag, windowTag, viewModel, logger);
        }

        private IAction GetKeyActionAndLockFactory(string windowTag
            , string keytag
            , BuilderStatus status = BuilderStatus.Default
            , BaseViewModel viewModel = null
            , ILogger logger = null)
        {
            var action = GetAction(keytag, windowTag, viewModel, logger);
            _actionFactory.UpdateBuilderStatus(windowTag, status);

            return action;
        }

        private IAction GetAction(string keyTag
            , string builderID
            , BaseViewModel viewModel = null
            , ILogger logger = null)
        {
            IAction action;
            try
            {
                action = _actionExecuterHelper.GetActionInCache(builderID, keyTag);
            }
            catch
            {
                action = null;
            }

            if (action == null)
            {
                action = _actionFactory.CreateAction(builderID, keyTag, viewModel, logger);
            }

            return action;
        }

    }
}
