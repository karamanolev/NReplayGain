using System;
using System.Linq;

namespace NReplayGain
{
    class ReplayGain
    {
        public const int STEPS_PER_DB = 100;
        public const int MAX_DB = 120;
        public const int MAX_SAMPLE_VALUE = 32768;
        public static double FACTOR_24BIT = ((double)MAX_SAMPLE_VALUE / 0x800000);

        public const int YULE_ORDER = 10;
        public const int BUTTER_ORDER = 2;
        public const int MAX_ORDER = YULE_ORDER > BUTTER_ORDER ? YULE_ORDER : BUTTER_ORDER;

        public const double PINK_REF = 64.82;
        public const double RMS_WINDOW_TIME = 0.050;
        public const double RMS_PERCENTILE = 0.95;
        public const int MAX_SAMP_FREQ = 48000;
        public const int MAX_SAMPLES_PER_WINDOW = (int)(MAX_SAMP_FREQ * RMS_WINDOW_TIME + 1);

        public static double AnalyzeResult(int[] array)
        {
            int elems = array.Sum();
            if (elems == 0)
            {
                throw new Exception("Not enough samples!");
            }

            int upper = (int)Math.Ceiling(elems * (1.0 - ReplayGain.RMS_PERCENTILE));
            int i = array.Length;
            while (i-- > 0)
            {
                if ((upper -= array[i]) <= 0)
                    break;
            }

            return ReplayGain.PINK_REF - (double)i / (double)ReplayGain.STEPS_PER_DB;
        }
    }
}
