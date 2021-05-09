using SIRRC.Base.Logger;
using SIRRC.Base.MVVM.ViewModel;
using SIRRC.Base.UIEventHandler.Action;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIRRC.Base.UIEventHandler.Listener
{
    interface IActionListener
    {
        /// <summary>
        /// Thực hiện hành động click vao 1 button
        /// </summary>
        /// <typeparam name="windowTag">là chuỗi key để xác định window nào đang gọi</typeparam>
        /// <typeparam name="keyFeature">là chuỗi key để xác định đó là feature gì</typeparam>
        /// <typeparam name="obj">data transfer giữa các class</typeparam>
        IAction OnKey(string windowTag, string keyFeature, object obj);

        /// <summary>
        /// Thực hiện hành động click vao 1 button
        /// </summary>
        /// <typeparam name="windowTag">là chuỗi key để xác định window nào đang gọi</typeparam>
        /// <typeparam name="keyFeature">là chuỗi key để xác định đó là feature gì</typeparam>
        /// <typeparam name="obj">data transfer giữa các class</typeparam>
        /// <typeparam name="status">trạng thái hiện tại của builder</typeparam>
        IAction OnKey(string windowTag, string keyFeature, object obj, BuilderStatus status);

        /// <summary>
        /// Thực hiện hành động click vao 1 button
        /// </summary>
        /// <typeparam name="viewModel">view model đang gọi onkey</typeparam>
        /// <typeparam name="windowTag">là chuỗi key để xác định window nào đang gọi</typeparam>
        /// <typeparam name="logger">ghi log</typeparam>
        /// <typeparam name="keyFeature">là chuỗi key để xác định đó là feature gì</typeparam>
        /// <typeparam name="obj">data transfer giữa các class</typeparam>
        IAction OnKey(BaseViewModel viewModel, ILogger logger, string windowTag, string keyFeature, object obj);

        /// <summary>
        /// Thực hiện hành động click vao 1 button
        /// </summary>
        /// <typeparam name="viewModel">view model đang gọi onkey</typeparam>
        /// <typeparam name="logger">ghi log</typeparam>
        /// <typeparam name="obj">data transfer giữa các class</typeparam>
        /// <typeparam name="status">trạng thái hiện tại của builder</typeparam>
        IAction OnKey(BaseViewModel viewModel, ILogger logger, string windowTag, string keyFeature, object obj, BuilderStatus status);
    }
}
