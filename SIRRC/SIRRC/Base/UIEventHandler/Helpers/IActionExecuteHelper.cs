using SIRRC.Base.UIEventHandler.Action;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIRRC.Base.UIEventHandler.Helpers
{
    public interface IActionExecuteHelper
    {
        /// <summary>
        /// Get action in the cacche if it exist
        /// </summary>
        /// <param name="actionID"></param>
        /// <param name="builderID"></param>
        /// <returns></returns>
        IAction GetActionInCache(string builderID, string keyID);

        /// <summary>
        /// Check a specific action is finished (included completed case and canceled case)
        /// </summary>
        /// <param name="actionID"></param>
        /// <param name="builderID"></param>
        /// <returns></returns>
        bool IsActionFinished(string actionID, string builderID);

        void CancelAllAction();

        bool IsAllBuilderActionsFinished(string builderID);

        ExecuteStatus ExecuteAlterAction(IAction action, object dataTransfer);

        ExecuteStatus ExecuteAction(IAction action, object dataTransfer);
    }
}
