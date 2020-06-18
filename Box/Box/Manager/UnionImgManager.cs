using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml.Serialization;

namespace Game.Box
{
    /// <summary>
    /// ͼƬ�ϳ�Ч��������
    /// </summary>
    public class UnionImgManager:IEnumerable<UnionItem>
    {
        private static UnionImgManager _instance;
        public static UnionImgManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UnionImgManager();
                }
                return _instance;
            }
        }

        private static string unionImgPath;
        /// <summary>
        /// �ϳ�Ч���ļ�����·��
        /// </summary>
        private static string UnionImgPath
        {
            get
            {
                if (unionImgPath == null)
                {
                    unionImgPath = Path.Combine(PathManager.UnionImgFolder, "UnionSettings.xml");
                }
                return unionImgPath;
            }
        }

        private List<UnionItem> unionItemList = new List<UnionItem>();
        private UnionImgManager()
        {
            if (!File.Exists(UnionImgPath)) return;
            XmlSerializer xs = new XmlSerializer(typeof(List<UnionItem>));
            using (Stream stream = new FileStream(UnionImgPath, FileMode.Open))
            {
                unionItemList = xs.Deserialize(stream) as List<UnionItem>;
            }
        }
        public void Add(UnionItem item)
        {
            unionItemList.Add(item);
        }
        public UnionItem AddNew()
        {
            UnionItem item = new UnionItem();
            unionItemList.Add(item);
            return item;
        }
        public void Remove(UnionItem item)
        {
            this.unionItemList.Remove(item);
        }
        public UnionItem this[int index]
        {
            get
            {
                return this.unionItemList[index];
            }
        }
        public int Count
        {
            get { return this.unionItemList.Count; }
        }
        /// <summary>
        /// ����ϳ�Ч�����õ�xml
        /// </summary>
        public void Save()
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<UnionItem>));
            using (Stream stream = new FileStream(UnionImgPath, File.Exists(UnionImgPath) ? FileMode.Truncate : FileMode.CreateNew))
            {
                xs.Serialize(stream, unionItemList);
            }
        }
        /// <summary>
        /// ���ݺϳ�Դ���Һϳɽ��
        /// </summary>
        /// <param name="sources">�ϳ�Դ����</param>
        /// <returns>�ϳ�Դ��Ӧ�ϳɽ�����û���򷵻�null</returns>
        public UnionItem GetUnionItem(params string[] sources)
        {
            foreach (UnionItem unionItem in unionItemList)
            {
                bool matched = true;
                foreach (string source in sources)
                {
                    if (!unionItem.SourceList.Contains(source))
                    {
                        matched = false;
                        break;
                    }
                }
                if (matched) return unionItem;
            }
            return null;
        }

        #region IEnumerable<UnionItem> ��Ա

        public IEnumerator<UnionItem> GetEnumerator()
        {
            return this.unionItemList.GetEnumerator();
        }

        #endregion

        #region IEnumerable ��Ա

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.unionItemList.GetEnumerator();
        }

        #endregion
    }
    /// <summary>
    /// �ϳ���
    /// </summary>
    [Serializable]
    public class UnionItem
    {
        private List<string> sourceList = new List<string>();
        /// <summary>
        /// �ϳ���Դ
        /// </summary>
        public List<string> SourceList
        {
            get
            {
                return sourceList;
            }
            set
            {
                this.sourceList = value;
            }
        }
        private List<string> unionResultList = new List<string>();
        /// <summary>
        /// �ϳɽ��
        /// </summary>
        public List<string> UnionResultList
        {
            get { return unionResultList; }
            set { unionResultList = value; }
        }
        /// <summary>
        /// ��Ӻϳ�Դ
        /// </summary>
        /// <param name="source">�ϳ�Դ����</param>
        public UnionItem AddSource(string source)
        {
            if (sourceList.Contains(source)) return this;
            sourceList.Add(source);
            return this;
        }
        /// <summary>
        /// �Ƴ��ϳ�Դ
        /// </summary>
        /// <param name="source">�ϳ�Դ����</param>
        public UnionItem RemoveSource(string source)
        {
            sourceList.Remove(source);
            return this;
        }
        /// <summary>
        /// ��Ӻϳɽ��
        /// </summary>
        /// <param name="unionResult">�ϳɽ������</param>
        public UnionItem AddUnionResult(string unionResult)
        {
            if (this.unionResultList.Contains(unionResult)) return this;
            unionResultList.Add(unionResult);
            return this;
        }
        /// <summary>
        /// �Ƴ��ϳɽ��
        /// </summary>
        /// <param name="unionResult">�ϳɽ������</param>
        public UnionItem RemoveUnionResult(string unionResult)
        {
            unionResultList.Remove(unionResult);
            return this;
        }
    }
}
