using System;
using System.Collections.Generic;
using System.Text;

namespace SIRRC.Base.UIEventHandler.Action.Executer
{
    public interface INavigationCommandExecuter : ICommandExecuter
    {
        /// <summary>
        /// 
        /// </summary>
        bool PreviewGoToNewSource();
    }
}
