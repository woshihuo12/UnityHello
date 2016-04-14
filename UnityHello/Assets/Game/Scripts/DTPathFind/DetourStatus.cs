using UnityEngine;
using System.Collections;

namespace DTPathFind
{
    public class DetourStatus
    {
        public const uint DT_FAILURE = 1u << 31;
        public const uint DT_SUCCESS = 1u << 30;
        public const uint DT_IN_PROGRESS = 1u << 29;

        public const uint DT_STATUS_DETAIL_MASK = 0x0ffffff;
        public const uint DT_WRONG_MAGIC = 1 << 0;
        public const uint DT_WRONG_VERSION = 1 << 1;
        public const uint DT_OUT_OF_MEMORY = 1 << 2;

    }
}