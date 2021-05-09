using System;
using System.Collections.Generic;
using System.Text;

namespace SIRRC.Base.UIEventHandler.Action
{
    public abstract class AbstractActionBuilder : IActionBuilder
    {
        private BuilderLocker _locker = new BuilderLocker(BuilderStatus.Available, false);

        public virtual BuilderLocker Locker { get => _locker; set => _locker = value; }

        public abstract IAction BuildAlternativeActionWhenFactoryIsLock(string keyTag);

        public abstract IAction BuildMainAction(string keyTag);

        public void UpdateBuilderStatus(BuilderStatus status)
        {
            if(status == BuilderStatus.ActionBuilding ||
                status == BuilderStatus.Unavailable ||
                status == BuilderStatus.ActionBuildingButCanDispose)
            {
                Locker.IsLock = true;
            }
            else
            {
                Locker.IsLock = false;
            }
            Locker.Status = status;
        }
    }
}
