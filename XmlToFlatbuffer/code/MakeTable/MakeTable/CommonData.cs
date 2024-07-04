using System;
using System.Collections.Generic;
using System.Text;

namespace MakeTable
{
    class CommonData
    {
        /// <summary>
        /// 是否递归生成flatbuffer
        /// </summary>
        public static bool _is_recursive_flatbuffer = false;

        /// <summary>
        /// 是否只生成图集数据
        /// </summary>
        public static bool _is_gen_spriteatlas_only = false;

        /// <summary>
        /// 是否只生成单条flatbuffer数据
        /// </summary>
        public static bool _is_gen_single_flatbuffer = false;

        /// <summary>
        /// 是否启动预处理
        /// </summary>
        public static bool _is_startup_preprocess = false;

        /// <summary>
        /// 生成文件的根目录
        /// </summary>
        public static string _gen_root_path = null;
    }
}
