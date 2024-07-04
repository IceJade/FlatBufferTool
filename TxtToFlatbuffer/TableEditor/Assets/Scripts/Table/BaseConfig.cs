// <auto-generated>
//  automatically generated by table tool, do not modify
// </auto-generated>
using System;
using System.Collections.Generic;
using System.IO;
using FlatBuffers;
using UnityEngine;

namespace LF
{
	public class BaseConfig : BaseTable
    {
        #region Framework Method

        protected override void LoadTable()
        {
            if (this.IsLoaded())
                return;

            if (this.IsLoading())
            {
                Debug.LogWarningFormat("the table {0} is loading, please wait...", this.GetTableFileName());
                return;
            }

            byte[] buffers = null;

#if UNITY_EDITOR
            buffers = File.ReadAllBytes(this.GetTableFile());
#else
            if (ConfigManager.Instance.DataTableAssets.ContainsKey(this.GetTableFileName()))
            {
                buffers = ConfigManager.Instance.DataTableAssets[this.GetTableFileName()];
            }
            else
            {
                Debug.LogErrorFormat("The file {0} is not load, please check config assetbundle", this.GetTableFileName());
                return;
            }
#endif

            if (null != buffers)
            {
                this.InitTable(new ByteBuffer(buffers));
            }
            else
            {
                this.load_state = E_LoadState.Fail;
            }

            this.LoadIndex();
        }

        protected override void LoadIndex()
        {
            if (null != row_index && row_index.Count > 0)
                return;

            int offset = 4;

            byte[] buffers = null;

#if UNITY_EDITOR
            buffers = File.ReadAllBytes(this.GetIndexFile());
#else
            if (ConfigManager.Instance.DataTableAssets.ContainsKey(this.GetIndexFileName()))
            {
                buffers = ConfigManager.Instance.DataTableAssets[this.GetIndexFileName()];
            }
            else
            {
                Debug.LogErrorFormat("The file {0} is not load, please check config assetbundle", this.GetIndexFileName());
            }
#endif

            if (null == buffers)
                return;

            if (buffers.Length <= offset)
                return;

            int count = BitConverter.ToInt32(buffers, offset);
            if (count <= 0)
                return;

            int id = 0;
            int index = 0;

            offset += 4;

            // 字典初始化并且直接设置成count
            row_index = new Dictionary<int, int>(count);
            for (int i = 0; i < count; i++)
            {
                id = BitConverter.ToInt32(buffers, offset);
                offset += 4;

                index = BitConverter.ToUInt16(buffers, offset);
                offset += 2;

                if (!this.row_index.ContainsKey(id))
                    this.row_index.Add(id, index);
            }
        }

        protected override string GetTableFile()
        {
            return Path.Combine("./Assets/Shelter/Config/", this.GetDataFileName());
        }

        protected override string GetIndexFile()
        {
            return Path.Combine("./Assets/Shelter/Config/ids", this.GetIndexFileName() + ".bytes");
        }

        #endregion Framework Method
    }
}