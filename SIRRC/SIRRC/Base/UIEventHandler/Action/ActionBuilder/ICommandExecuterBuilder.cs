using SIRRC.Base.Logger;
using SIRRC.Base.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIRRC.Base.UIEventHandler.Action
{
    public interface ICommandExecuterBuilder : IActionBuilder
    {
        ICommandExecuter BuildCommandExecuter(string keyTag, ILogger logger = null);

        IViewModelCommandExecuter BuildViewModelCommandExecuter(string keyTag, BaseViewModel viewModel, ILogger logger = null);


        ICommandExecuter BuildAlternativeCommandExecuterWhenBuilderIsLock(string keyTag, ILogger logger = null);

        IViewModelCommandExecuter BuildAlternativeViewModelCommandExecuterWhenBuilderIsLock(string keyTag, BaseViewModel viewModel, ILogger logger = null);

    }
}
