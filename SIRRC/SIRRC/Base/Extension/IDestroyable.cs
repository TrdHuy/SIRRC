using System;
using System.Collections.Generic;
using System.Text;

namespace SIRRC.Base.Extension
{
    public interface IDestroyable
    {
        /// <summary>
        /// destroy callback method when an object is unloaded or destroyed
        /// </summary>
        void OnDestroy();

    }
}
