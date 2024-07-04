using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

/// <summary>
/// 预处理类,在处理表格之前处理业务
/// </summary>
namespace MakeTable
{
    class ProcessManager : Process<ProcessManager>
    {
        private List<IProcess> processes = new List<IProcess>();

        private bool isInited = false;

        public void Startup(string[] args)
        {
            // 不开启预处理
            if (!CommonData._is_startup_preprocess)
                return;

            Log.Print("---------------------------------------------------------------------------------------");
            Log.Print("启动流程...");

            if (!isInited)
            {
                // 注册流程
                this.RegisterProcess();

                // 初始化流程
                this.Init(args);
            }

            // 处理流程
            this.Start();
        }

        /// <summary>
        /// 结束处理流程
        /// </summary>
        public void EndProcess()
        {
            // 不开启预处理
            if (!CommonData._is_startup_preprocess)
                return;

            Log.Print("---------------------------------------------------------------------------------------");
            Log.Print("结束流程...");

            this.End();
        }

        public override void Init(object param)
        {
            for (int i = 0; i < processes.Count; i++)
                processes[i].Init(param);

            this.isInited = true;
        }

        public override void Start()
        {
            for (int i = 0; i < processes.Count; i++)
                processes[i].Start();
        }

        public override void End()
        {
            for (int i = 0; i < processes.Count; i++)
                processes[i].End();
        }

        protected override string GetProcessName()
        {
            return "ProcessManager";
        }

        public void RegisterProcess()
        {
            if (null != processes && processes.Count > 0)
                return;

            processes.Add(SpriteAtlasProcess.Instance);
        }
    }
}
