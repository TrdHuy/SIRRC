using System;
using System.Collections.Generic;
using System.Text;

namespace SIRRC.Base.UIEventHandler.Action
{
    public interface IActionBuilder
    {
        IAction BuildAlternativeActionWhenFactoryIsLock(string keyTag);

        IAction BuildMainAction(string keyTag);

        void UpdateBuilderStatus(BuilderStatus status = BuilderStatus.Default);

        BuilderLocker Locker { get; set; }
    }

    public class BuilderLocker
    {
        public BuilderStatus Status;
        public bool IsLock;

        public BuilderLocker(BuilderStatus status, bool key)
        {
            Status = status;
            IsLock = key;
        }
    }

    public enum BuilderStatus
    {
        Default = 0,

        ActionBuilding = 1,

        Unavailable = 2,

        Available = 3,

        ActionBuildingButCanDispose = 4,
    }
}
