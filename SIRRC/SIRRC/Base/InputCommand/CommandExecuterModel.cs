using SIRRC.Base.Extension;
using SIRRC.Base.UIEventHandler.Action;
using SIRRC.Base.UIEventHandler.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SIRRC.Base.InputCommand
{
    public class CommandExecuterModel : ICommand, IDestroyable, ICancelable
    {
        public event EventHandler CanExecuteChanged;
        public event NotifyIsCompletedChangedHandler CompletedChanged;
        public event NotifyIsCanceledChangedHandler CanceledChanged;

        private Func<object, ICommandExecuter> _getCommandExecuterFunc;
        private ICommandExecuter _commandExecuterCache;

        protected CommandExecuteHelper CommandExecuteHelper { get; set; }

        protected virtual ICommandExecuter CommandExecuterCache
        {
            get
            {
                return _commandExecuterCache;
            }
            set
            {
                _commandExecuterCache = value;
            }
        }

        public bool IsCompleted
        {
            get
            {
                return CommandExecuterCache == null ? throw new NullReferenceException("Current cache is null") : CommandExecuterCache.IsCompleted;
            }
        }

        public bool IsCaneled
        {
            get
            {
                return CommandExecuterCache == null ? throw new NullReferenceException("Current cache is null") : CommandExecuterCache.IsCanceled;
            }
        }

        public CommandExecuterModel(Func<object, ICommandExecuter> getCommandExecuterFunc,
            CommandExecuteHelper cmdExeHelper)
        {
            _getCommandExecuterFunc = getCommandExecuterFunc;
            CommandExecuteHelper = cmdExeHelper;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (CommandExecuterCache != null)
            {
                CommandExecuterCache.IsCompletedChanged -= OnCommandExecuterCompletedChanged;
                CommandExecuterCache.IsCanceledChanged -= OnCommandExecuterCanceledChanged;
            }

            CommandExecuterCache = _getCommandExecuterFunc?.Invoke(parameter);

            if (CommandExecuterCache != null)
            {
                CommandExecuterCache.IsCompletedChanged += OnCommandExecuterCompletedChanged;
                CommandExecuterCache.IsCanceledChanged += OnCommandExecuterCanceledChanged;
            }

            ExetcuteAction(parameter);
        }

        private void OnCommandExecuterCompletedChanged(object sender, ExecuterStatusArgs arg)
        {
            CompletedChanged?.Invoke(sender, arg);
        }

        private void OnCommandExecuterCanceledChanged(object sender, ExecuterStatusArgs arg)
        {
            CanceledChanged?.Invoke(sender, arg);
        }

        public void OnDestroy()
        {
            if (CommandExecuterCache != null)
            {
                CommandExecuterCache.OnDestroy();
            }
        }

        public void OnCancel()
        {
            if (CommandExecuterCache != null)
            {
                CommandExecuterCache.OnCancel();
            }
        }

        protected virtual void ExetcuteAction(object dataTransfer)
        {
            if (CommandExecuterCache == null)
            {
                return;
            }
            CommandExecuteHelper.ExecuteAction(CommandExecuterCache, dataTransfer);
        }
    }
}
