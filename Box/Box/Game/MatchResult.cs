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
        /// Ŀ������
        /// </summary>
        public uint TargetCount
        {
            get { return targetCount; }
            set { targetCount = value; }
        }
        /// <summary>
        /// ���Ӹ���
        /// </summary>
        public uint BoxCount
        {
            get { return boxCount; }
            set { boxCount = value; }
        }
        /// <summary>
        /// �Ƶ�Ŀ������
        /// </summary>
        public uint MatchedCount
        {
            get { return matchedCount; }
            set { matchedCount = value; }
        }
        /// <summary>
        /// �Ƿ�ͨ��
        /// </summary>
        public bool IsComplete
        {
            get { return matchedCount >= targetCount; }
        }

    }
}
