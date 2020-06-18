using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Box
{
    public struct MatchResult
    {
        uint targetCount;
        uint boxCount;
        uint matchedCount;
        /// <summary>
        /// 目标点个数
        /// </summary>
        public uint TargetCount
        {
            get { return targetCount; }
            set { targetCount = value; }
        }
        /// <summary>
        /// 箱子个数
        /// </summary>
        public uint BoxCount
        {
            get { return boxCount; }
            set { boxCount = value; }
        }
        /// <summary>
        /// 推到目标点个数
        /// </summary>
        public uint MatchedCount
        {
            get { return matchedCount; }
            set { matchedCount = value; }
        }
        /// <summary>
        /// 是否通关
        /// </summary>
        public bool IsComplete
        {
            get { return matchedCount >= targetCount; }
        }

    }
}
