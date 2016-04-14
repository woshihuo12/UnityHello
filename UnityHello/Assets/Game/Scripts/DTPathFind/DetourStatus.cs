using dtStatus = System.UInt32;

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
        public const uint DT_INVALID_PARAM = 1 << 3;
        public const uint DT_BUFFER_TOO_SMALL = 1 << 4;
        public const uint DT_OUT_OF_NODES = 1 << 5;
        public const uint DT_PARTIAL_RESULT = 1 << 6;

        public static bool dtStatusSucceed(dtStatus status)
        {
            return (status & DT_SUCCESS) != 0;
        }

        public static bool dtStatusFailed(dtStatus status)
        {
            return (status & DT_FAILURE) != 0;
        }

        public static bool dtStatusInProgress(dtStatus status)
        {
            return (status & DT_IN_PROGRESS) != 0;
        }

        public static bool dtStatusDetail(dtStatus status, uint detail)
        {
            return (status & detail) != 0;
        }
    }
}