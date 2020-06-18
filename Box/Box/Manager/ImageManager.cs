using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

namespace Game.Box
{
    /// <summary>
    /// 资源图片管理器
    /// </summary>
    public class ImageManager
    {
        private static ImageManager instance = null;
        public static ImageManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ImageManager();
                }
                return instance;
            }
        }
        private ImageManager()
        {
            string imgFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "img");
            if (!Directory.Exists(imgFolder)) return;
            foreach (string filePath in Directory.GetFiles(imgFolder))
            {
                try
                {
                    imgDict[Path.GetFileNameWithoutExtension(filePath)] = Image.FromFile(filePath);
                }
                catch { }
            }
        }
        private Image emptyImage = new Bitmap(1, 1);
        private Dictionary<string, Image> imgDict = new Dictionary<string, Image>();
        /// <summary>
        /// 根据名称获取图片
        /// </summary>
        /// <param name="key">图片名称</param>
        /// <returns>图片名称对应图片，没有则返回空Image</returns>
        public Image this[string key]
        {
            get
            {
                if (imgDict.ContainsKey(key)) return imgDict[key];
                return emptyImage;
            }
        }
        /// <summary>
        /// 已存在图片的名称集合
        /// </summary>
        public List<string> ImgKeys
        {
            get
            {
                return new List<string>(imgDict.Keys);
            }
        }
    }
}
