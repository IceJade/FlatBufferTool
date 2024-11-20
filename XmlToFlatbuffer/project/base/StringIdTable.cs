// <auto-generated>
//  automatically generated by table tool, do not modify
// </auto-generated>
using System;
using System.Text;
using UnityEngine.Networking;
using UnityEngine;
using System.Collections.Generic;
using System.IO;
using GameFramework;

namespace Chanto.Table
{
	public class StringIdTable : BaseTable
    {
        protected override void LoadIndex()
        {
            if (row_index != null && row_index.Count > 0)
            {
                return;
            }

            int offset = 4;

            byte[] buffers = null;

#if USE_TABLE_ASSET_BUNDLE_MODE
#if UNITY_EDITOR
            buffers = File.ReadAllBytes(this.GetIndexFile());
#else
            if (TableManager.Instance.DataTableAssets.ContainsKey(this.GetIndexFileName()))
            {
                buffers = TableManager.Instance.DataTableAssets[this.GetIndexFileName()];
            }
#endif
#else
            
            var filepath = GetIndexFile();
            if (Log.IsFlatBuffer())
                Log.Info($">>>> flatbuffer -- stringid: loadindex: {filepath}");
#if UNITY_ANDROID && !UNITY_EDITOR
            // 循环次数记录, 防止死循环
            int loopCount = 0;

            using (UnityWebRequest request = UnityWebRequest.Get(filepath))
            {
                request.SendWebRequest();
                Debug.Log(string.Format("flatbuffer request path : {0}", request.url));
                while (!request.downloadHandler.isDone)
                {
                    if (request.isNetworkError || request.isHttpError)
                    {
                        Log.Error("Load {0} fail, error mssage : {1}", request.url, request.error);
                        return;
                    }

                    // 循环最大时间设置为5分钟, 防止死循环
                    if (loopCount > loopTimeOutCount)
                    {
                        Log.Error("Load table {0} time out.", filepath);
                        return;
                    }

                    loopCount++;

                    System.Threading.Thread.Sleep(sleepInterval);
                }

                buffers = request.downloadHandler.data;
            }
#else
            try
            {
                if (File.Exists(filepath))
                {
                    // string text = File.ReadAllText(filepath);
                    buffers = File.ReadAllBytes(filepath);
                }
            }
            catch(Exception e)
            {
                Log.Error("Read table {0} exception, error msg : {1}", filepath, e.Message);
            }
#endif
#endif

            if (null == buffers)
                return;

            if (buffers.Length <= offset)
                return;

            int count = BitConverter.ToInt32(buffers, offset);
            if (count <= 0)
                return;

            int length = 0;
            int index = 0;
            int hashcode = 0;
            string id;

            offset += 4;

            // 字典初始化并且直接设置成count
            row_index = new Dictionary<int, int>(count);

            for (int i = 0; i < count; i++)
            {
                length = BitConverter.ToInt32(buffers, offset);
                offset += 4;

                id = Encoding.UTF8.GetString(buffers, offset, length);
                offset += length;
                
                index = BitConverter.ToUInt16(buffers, offset);
                offset += 2;

                hashcode = id.GetHashCode();

                if (!this.row_index.ContainsKey(hashcode))
                    this.row_index.Add(hashcode, index);
            }
        }
    }
}