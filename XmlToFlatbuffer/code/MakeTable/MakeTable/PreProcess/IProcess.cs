using System;
using System.Collections.Generic;
using System.Text;

namespace MakeTable
{
    interface IProcess
    {
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="param"></param>
        void Init(object param);

        /// <summary>
        /// 处理流程业务
        /// </summary>
        void Start();

        /// <summary>
        /// 结束流程
        /// </summary>
        void End();
    }
}
