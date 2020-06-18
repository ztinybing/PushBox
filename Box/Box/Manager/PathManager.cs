using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Game.Box
{
    public static class PathManager
    {
        private static string stageMapFolder = null;
        /// <summary>
        /// 关卡文件保存目录
        /// </summary>
        public static string StageMapFolder
        {
            get
            {
                if (stageMapFolder == null)
                {
                    stageMapFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "StageMapFolder");
                    if (!Directory.Exists(stageMapFolder))
                    {
                        try
                        {
                            Directory.CreateDirectory(stageMapFolder);
                        }
                        catch { }
                    }
                }
                return stageMapFolder;
            }
        }

        private static string stateSaveFolder = null;
        /// <summary>
        /// 及时存档保存目录
        /// </summary>
        public static string StateSaveFolder
        {
            get 
            {
                if (stateSaveFolder == null)
                { 
                    stateSaveFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "State");
                    if (!Directory.Exists(stateSaveFolder))
                    {
                        try
                        {
                            Directory.CreateDirectory(stateSaveFolder);
                        }
                        catch { }
                    }
                }
                return stateSaveFolder;
            }
        }
        private static string prefabFolder = null;
        /// <summary>
        /// 预置体保存目录
        /// </summary>
        public static string PrefabFolder
        {
            get 
            {
                if (prefabFolder == null)
                {
                    prefabFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Prefab");
                    if (!Directory.Exists(prefabFolder))
                    {
                        try
                        {
                            Directory.CreateDirectory(prefabFolder);
                        }
                        catch { }
                    }
                }
                return prefabFolder;
            }
        }

        private static string unionImgFolder;
        /// <summary>
        /// 图片合成效果保存目录
        /// </summary>
        public static string UnionImgFolder
        {
            get
            {
                if (unionImgFolder == null)
                {
                    unionImgFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "UnionImg");
                    if (!Directory.Exists(unionImgFolder))
                    {
                        try
                        {
                            Directory.CreateDirectory(unionImgFolder);
                        }
                        catch { }
                    }
                }
                return unionImgFolder;
            }
        }


    }
}
