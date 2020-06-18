using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml.Serialization;

namespace Game.Box
{
    [Serializable]
    public class PrefabList
    {
        private static PrefabList instance = null;
        /// <summary>
        /// 预置列表实例
        /// </summary>
        public static PrefabList Instance
        {
            get
            {
                if (instance == null)
                {
                    if (File.Exists(PrefabPath))
                    {
                        XmlSerializer xs = new XmlSerializer(typeof(PrefabList));
                        using (FileStream fs = new FileStream(PrefabPath, FileMode.OpenOrCreate))
                        {
                            instance = xs.Deserialize(fs) as PrefabList;
                            if (instance == null) instance = new PrefabList();
                        }
                    }
                    else
                    {
                        instance = new PrefabList();
                    }
                }
                return instance;
            }
        }
        private static string prefabPath;
        private static string PrefabPath
        {
            get
            {
                if (prefabPath == null)
                {
                    prefabPath = Path.Combine(PathManager.PrefabFolder, "prefab.xml");
                }
                return prefabPath;
            }
        }

        public List<BoxItem> CurPrefabList = new List<BoxItem>();

        private PrefabList() { }
        /// <summary>
        /// 保存预置
        /// </summary>
        public void SavePrefab()
        {
            XmlSerializer xs = new XmlSerializer(typeof(PrefabList));
            using (FileStream fs = new FileStream(PrefabPath, File.Exists(PrefabPath) ? FileMode.Truncate : FileMode.CreateNew))
            {
                xs.Serialize(fs, this);
            }
        }
    }
}
