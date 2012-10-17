using System;
using System.Linq;

namespace NReplayGain
{
    /// <summary>
    /// Contains ReplayGain data for a track.
    /// </summary>
    public class TrackGain
    {
        private static FrequencyInfo[] freqInfos = new FrequencyInfo[] {
#region Frequency Infos
            new FrequencyInfo(
		        8000,
		        new double[]{ 0.53648789255105, -0.42163034350696, -0.00275953611929,  0.04267842219415, -0.10214864179676,  0.14590772289388, -0.02459864859345, -0.11202315195388, -0.04060034127000,  0.04788665548180, -0.02217936801134 },
		        new double[]{ 1, -0.25049871956020, -0.43193942311114, -0.03424681017675, -0.04678328784242,  0.26408300200955,  0.15113130533216, -0.17556493366449, -0.18823009262115,  0.05477720428674, 0.04704409688120 },
		        new double[]{ 0.94597685600279, -1.89195371200558, 0.94597685600279 },
		        new double[]{ 1, -1.88903307939452, 0.89487434461664 }
	        ),

	        new FrequencyInfo(
		        11025,
		        new double[]{ 0.58100494960553, -0.53174909058578, -0.14289799034253,  0.17520704835522,  0.02377945217615,  0.15558449135573, -0.25344790059353,  0.01628462406333,  0.06920467763959, -0.03721611395801, -0.00749618797172 },
		        new double[]{ 1, -0.51035327095184, -0.31863563325245, -0.20256413484477,  0.14728154134330,  0.38952639978999, -0.23313271880868, -0.05246019024463, -0.02505961724053,  0.02442357316099, 0.01818801111503 },
		        new double[]{ 0.95856916599601, -1.91713833199203, 0.95856916599601 },
		        new double[]{ 1, -1.91542108074780, 0.91885558323625 }
	        ),

	        new FrequencyInfo(
		        12000,
		        new double[]{ 0.56619470757641, -0.75464456939302,  0.16242137742230,  0.16744243493672, -0.18901604199609,  0.30931782841830, -0.27562961986224,  0.00647310677246,  0.08647503780351, -0.03788984554840, -0.00588215443421 },
		        new double[]{ 1, -1.04800335126349,  0.29156311971249, -0.26806001042947,  0.00819999645858,  0.45054734505008, -0.33032403314006,  0.06739368333110, -0.04784254229033,  0.01639907836189, 0.01807364323573 },
		        new double[]{ 0.96009142950541, -1.92018285901082, 0.96009142950541 },
		        new double[]{ 1, -1.91858953033784, 0.92177618768381 }
	        ),

	        new FrequencyInfo(
		        16000,
		        new double[]{ 0.44915256608450, -0.14351757464547, -0.22784394429749, -0.01419140100551,  0.04078262797139, -0.12398163381748,  0.04097565135648,  0.10478503600251, -0.01863887810927, -0.03193428438915,  0.00541907748707 },
		        new double[]{ 1, -0.62820619233671,  0.29661783706366, -0.37256372942400,  0.00213767857124, -0.42029820170918,  0.22199650564824,  0.00613424350682,  0.06747620744683,  0.05784820375801, 0.03222754072173 },
		        new double[]{ 0.96454515552826, -1.92909031105652, 0.96454515552826 },
		        new double[]{ 1, -1.92783286977036, 0.93034775234268 }
	        ),

	        new FrequencyInfo(
		        18900,
		        new double[]{0.38524531015142,  -0.27682212062067,  -0.09980181488805,   0.09951486755646,  -0.08934020156622,  -0.00322369330199,  -0.00110329090689,   0.03784509844682,   0.01683906213303,  -0.01147039862572,  -0.01941767987192 },
		        new double[]{1.00000000000000,  -1.29708918404534,   0.90399339674203,  -0.29613799017877,  -0.42326645916207,   0.37934887402200,  -0.37919795944938,   0.23410283284785,  -0.03892971758879,   0.00403009552351,   0.03640166626278 },
		        new double[]{0.96535326815829,  -1.93070653631658,   0.96535326815829 },
		        new double[]{1.00000000000000,  -1.92950577983524,   0.93190729279793 }
	        ),
	
	        new FrequencyInfo(
		        22050,
		        new double[]{ 0.33642304856132, -0.25572241425570, -0.11828570177555,  0.11921148675203, -0.07834489609479, -0.00469977914380, -0.00589500224440,  0.05724228140351,  0.00832043980773, -0.01635381384540, -0.01760176568150 },
		        new double[]{ 1, -1.49858979367799,  0.87350271418188,  0.12205022308084, -0.80774944671438,  0.47854794562326, -0.12453458140019, -0.04067510197014,  0.08333755284107, -0.04237348025746, 0.02977207319925 },
		        new double[]{ 0.97316523498161, -1.94633046996323, 0.97316523498161 },
		        new double[]{ 1, -1.94561023566527, 0.94705070426118 }
	        ),

	        new FrequencyInfo(
		        24000,
		        new double[]{ 0.30296907319327, -0.22613988682123, -0.08587323730772,  0.03282930172664, -0.00915702933434, -0.02364141202522, -0.00584456039913,  0.06276101321749, -0.00000828086748,  0.00205861885564, -0.02950134983287 },
		        new double[]{ 1, -1.61273165137247,  1.07977492259970, -0.25656257754070, -0.16276719120440, -0.22638893773906,  0.39120800788284, -0.22138138954925,  0.04500235387352,  0.02005851806501, 0.00302439095741 },
		        new double[]{ 0.97531843204928, -1.95063686409857, 0.97531843204928 },
		        new double[]{ 1, -1.95002759149878, 0.95124613669835 }
	        ),

	        new FrequencyInfo(
		        28000,
		        new double[]{ 0.23544170728267, -0.24752593505499, -0.02357512726922,  0.04300581921555, -0.00436328684724, -0.01223745945148,  0.01264711473636,  0.03748020293506, -0.03351377648226,  0.02481670382392, -0.02181613007838 },
		        new double[]{ 1, -2.22622382338735,  2.15684658231271, -1.28156172224940,  0.78149824150575, -0.95424812536282,  0.92686669115303, -0.45189545196455,  0.01130093451234,  0.10071250641644, -0.03589496549521 },
		        new double[]{ 0.97803047920656, -1.95606095841312, 0.97803047920656 },
		        new double[]{ 1, -1.95557824031504, 0.95654367651120 }
	        ),
	
	        new FrequencyInfo(
		        32000,
		        new double[]{ 0.15457299681924, -0.09331049056315, -0.06247880153653,  0.02163541888798, -0.05588393329856,  0.04781476674921,  0.00222312597743,  0.03174092540049, -0.01390589421898,  0.00651420667831, -0.00881362733839 },
		        new double[]{ 1, -2.37898834973084,  2.84868151156327, -2.64577170229825,  2.23697657451713, -1.67148153367602,  1.00595954808547, -0.45953458054983,  0.16378164858596, -0.05032077717131, 0.02347897407020 },
		        new double[]{ 0.97938932735214, -1.95877865470428, 0.97938932735214 },
		        new double[]{ 1, -1.95835380975398, 0.95920349965459 }
	        ),

	        new FrequencyInfo(
		        37800,
		        new double[]{0.08717879977844,  -0.01000374016172,  -0.06265852122368,  -0.01119328800950,  -0.00114279372960,   0.02081333954769,  -0.01603261863207,   0.01936763028546,   0.00760044736442,  -0.00303979112271,  -0.00075088605788 },
		        new double[]{1.00000000000000,  -2.62816311472146,   3.53734535817992,  -3.81003448678921,   3.91291636730132,  -3.53518605896288,   2.71356866157873,  -1.86723311846592,   1.12075382367659,  -0.48574086886890,   0.11330544663849 },
		        new double[]{0.98252400815195,  -1.96504801630391,   0.98252400815195 },
		        new double[]{1.00000000000000,  -1.96474258269041,   0.96535344991740 }
	        ),

	        new FrequencyInfo(
		        44100,
		        new double[]{ 0.05418656406430, -0.02911007808948, -0.00848709379851, -0.00851165645469, -0.00834990904936,  0.02245293253339, -0.02596338512915,  0.01624864962975, -0.00240879051584,  0.00674613682247, -0.00187763777362 },
		        new double[]{ 1, -3.47845948550071,  6.36317777566148, -8.54751527471874,  9.47693607801280, -8.81498681370155,  6.85401540936998, -4.39470996079559,  2.19611684890774, -0.75104302451432, 0.13149317958808 },
		        new double[]{ 0.98500175787242, -1.97000351574484, 0.98500175787242 },
		        new double[]{ 1, -1.96977855582618, 0.97022847566350 }
	        ),

	        new FrequencyInfo(
		        48000,
		        new double[]{ 0.03857599435200, -0.02160367184185, -0.00123395316851, -0.00009291677959, -0.01655260341619,  0.02161526843274, -0.02074045215285,  0.00594298065125,  0.00306428023191,  0.00012025322027,  0.00288463683916 },
		        new double[]{ 1, -3.84664617118067,  7.81501653005538,-11.34170355132042, 13.05504219327545,-12.28759895145294,  9.48293806319790, -5.87257861775999,  2.75465861874613, -0.86984376593551, 0.13919314567432 },
		        new double[]{ 0.98621192462708, -1.97242384925416, 0.98621192462708 },
		        new double[]{ 1, -1.97223372919527, 0.97261396931306 }
	        )
#endregion
        };

        private int sampleSize;
        internal GainData gainData;

        private double[] lInPreBuf;
        private CPtr<double> lInPre;
        private double[] lStepBuf;
        private CPtr<double> lStep;
        private double[] lOutBuf;
        private CPtr<double> lOut;

        private double[] rInPreBuf;
        private CPtr<double> rInPre;
        private double[] rStepBuf;
        private CPtr<double> rStep;
        private double[] rOutBuf;
        private CPtr<double> rOut;

        private long sampleWindow;
        private long totSamp;
        private double lSum;
        private double rSum;
        private int freqIndex;

        public TrackGain(int sampleRate, int sampleSize)
        {
            this.sampleSize = sampleSize;
            this.gainData = new GainData();

            this.lInPreBuf = new double[ReplayGain.MAX_ORDER * 2];
            this.lStepBuf = new double[ReplayGain.MAX_SAMPLES_PER_WINDOW + ReplayGain.MAX_ORDER];
            this.lOutBuf = new double[ReplayGain.MAX_SAMPLES_PER_WINDOW + ReplayGain.MAX_ORDER];
            this.rInPreBuf = new double[ReplayGain.MAX_ORDER * 2];
            this.rStepBuf = new double[ReplayGain.MAX_SAMPLES_PER_WINDOW + ReplayGain.MAX_ORDER];
            this.rOutBuf = new double[ReplayGain.MAX_SAMPLES_PER_WINDOW + ReplayGain.MAX_ORDER];

            this.freqIndex = freqInfos.IndexOf(i => i.SampleRate == sampleRate);
            if (this.freqIndex == -1)
            {
                throw new Exception("Invalid sample frequency.");
            }
            this.sampleWindow = (int)Math.Ceiling(sampleRate * ReplayGain.RMS_WINDOW_TIME);

            this.lInPre = new CPtr<double>(lInPreBuf, ReplayGain.MAX_ORDER);
            this.lStep = new CPtr<double>(lStepBuf, ReplayGain.MAX_ORDER);
            this.lOut = new CPtr<double>(lOutBuf, ReplayGain.MAX_ORDER);
            this.rInPre = new CPtr<double>(rInPreBuf, ReplayGain.MAX_ORDER);
            this.rStep = new CPtr<double>(rStepBuf, ReplayGain.MAX_ORDER);
            this.rOut = new CPtr<double>(rOutBuf, ReplayGain.MAX_ORDER);
        }

        public void AnalyzeSamples(int[] leftSamples, int[] rightSamples)
        {
            if (leftSamples.Length != rightSamples.Length)
            {
                throw new ArgumentException("leftSamples must be as big as rightSamples");
            }

            int numSamples = leftSamples.Length;

            double[] leftDouble = new double[numSamples];
            double[] rightDouble = new double[numSamples];

            if (this.sampleSize == 16)
            {
                for (int i = 0; i < numSamples; ++i)
                {
                    leftDouble[i] = leftSamples[i];
                    rightDouble[i] = rightSamples[i];
                }
            }
            else if (this.sampleSize == 24)
            {
                for (int i = 0; i < numSamples; ++i)
                {
                    leftDouble[i] = leftSamples[i] * ReplayGain.FACTOR_24BIT;
                    rightDouble[i] = rightSamples[i] * ReplayGain.FACTOR_24BIT;
                }
            }

            double tmpPeak;
            for (int i = 0; i < numSamples; ++i)
            {
                tmpPeak = leftDouble[i] >= 0 ? leftDouble[i] : -leftDouble[i];
                if (tmpPeak > this.gainData.PeakSample) this.gainData.PeakSample = tmpPeak;

                tmpPeak = rightDouble[i] >= 0 ? rightDouble[i] : -rightDouble[i];
                if (tmpPeak > this.gainData.PeakSample) this.gainData.PeakSample = tmpPeak;
            }

            this.AnalyzeSamples(new CPtr<double>(leftDouble), new CPtr<double>(rightDouble));
        }

        private static double Sqr(double d)
        {
            return d * d;
        }

        private void FilterYule(CPtr<double> input, CPtr<double> output, long nSamples, double[] aKernel, double[] bKernel)
        {
            while (nSamples-- != 0)
            {
                output[0] = 1e-10  /* 1e-10 is a hack to avoid slowdown because of denormals */
                  + input[0] * bKernel[0]
                  - output[-1] * aKernel[1]
                  + input[-1] * bKernel[1]
                  - output[-2] * aKernel[2]
                  + input[-2] * bKernel[2]
                  - output[-3] * aKernel[3]
                  + input[-3] * bKernel[3]
                  - output[-4] * aKernel[4]
                  + input[-4] * bKernel[4]
                  - output[-5] * aKernel[5]
                  + input[-5] * bKernel[5]
                  - output[-6] * aKernel[6]
                  + input[-6] * bKernel[6]
                  - output[-7] * aKernel[7]
                  + input[-7] * bKernel[7]
                  - output[-8] * aKernel[8]
                  + input[-8] * bKernel[8]
                  - output[-9] * aKernel[9]
                  + input[-9] * bKernel[9]
                  - output[-10] * aKernel[10]
                  + input[-10] * bKernel[10];
                ++output;
                ++input;
            }
        }

        private void FilterButter(CPtr<double> input, CPtr<double> output, long nSamples, double[] aKernel, double[] bKernel)
        {
            while (nSamples-- != 0)
            {
                output[0] =
                   input[0] * bKernel[0]
                 - output[-1] * aKernel[1]
                 + input[-1] * bKernel[1]
                 - output[-2] * aKernel[2]
                 + input[-2] * bKernel[2];
                ++output;
                ++input;
            }
        }

        private void AnalyzeSamples(CPtr<double> leftSamples, CPtr<double> rightSamples)
        {
            int numSamples = leftSamples.Length;

            CPtr<double> curLeft;
            CPtr<double> curRight;
            long batchSamples = numSamples;
            long curSamples;
            long curSamplePos = 0;

            if (numSamples < ReplayGain.MAX_ORDER)
            {
                Array.Copy(leftSamples.Array, 0, this.lInPreBuf, ReplayGain.MAX_ORDER, numSamples);
                Array.Copy(rightSamples.Array, 0, this.rInPreBuf, ReplayGain.MAX_ORDER, numSamples);
            }
            else
            {
                Array.Copy(leftSamples.Array, 0, this.lInPreBuf, ReplayGain.MAX_ORDER, ReplayGain.MAX_ORDER);
                Array.Copy(rightSamples.Array, 0, this.rInPreBuf, ReplayGain.MAX_ORDER, ReplayGain.MAX_ORDER);
            }

            while (batchSamples > 0)
            {
                curSamples = batchSamples > this.sampleWindow - this.totSamp ? this.sampleWindow - this.totSamp : batchSamples;
                if (curSamplePos < ReplayGain.MAX_ORDER)
                {
                    curLeft = this.lInPre + curSamplePos;
                    curRight = this.rInPre + curSamplePos;
                    if (curSamples > ReplayGain.MAX_ORDER - curSamplePos)
                        curSamples = ReplayGain.MAX_ORDER - curSamplePos;
                }
                else
                {
                    curLeft = leftSamples + curSamplePos;
                    curRight = rightSamples + curSamplePos;
                }

                FilterYule(curLeft, this.lStep + this.totSamp, curSamples, freqInfos[this.freqIndex].AYule, freqInfos[this.freqIndex].BYule);
                FilterYule(curRight, this.rStep + this.totSamp, curSamples, freqInfos[this.freqIndex].AYule, freqInfos[this.freqIndex].BYule);

                FilterButter(this.lStep + this.totSamp, this.lOut + this.totSamp, curSamples, freqInfos[this.freqIndex].AButter, freqInfos[this.freqIndex].BButter);
                FilterButter(this.rStep + this.totSamp, this.rOut + this.totSamp, curSamples, freqInfos[this.freqIndex].AButter, freqInfos[this.freqIndex].BButter);

                curLeft = this.lOut + this.totSamp;                   // Get the squared values
                curRight = this.rOut + this.totSamp;

                for (long i = curSamples % 16; i-- != 0; )
                {
                    this.lSum += Sqr(curLeft[0]);
                    ++curLeft;
                    this.rSum += Sqr(curRight[0]);
                    ++curRight;
                }

                for (long i = curSamples / 16; i-- != 0; )
                {
                    this.lSum += Sqr(curLeft[0])
                          + Sqr(curLeft[1])
                          + Sqr(curLeft[2])
                          + Sqr(curLeft[3])
                          + Sqr(curLeft[4])
                          + Sqr(curLeft[5])
                          + Sqr(curLeft[6])
                          + Sqr(curLeft[7])
                          + Sqr(curLeft[8])
                          + Sqr(curLeft[9])
                          + Sqr(curLeft[10])
                          + Sqr(curLeft[11])
                          + Sqr(curLeft[12])
                          + Sqr(curLeft[13])
                          + Sqr(curLeft[14])
                          + Sqr(curLeft[15]);
                    curLeft += 16;
                    this.rSum += Sqr(curRight[0])
                          + Sqr(curRight[1])
                          + Sqr(curRight[2])
                          + Sqr(curRight[3])
                          + Sqr(curRight[4])
                          + Sqr(curRight[5])
                          + Sqr(curRight[6])
                          + Sqr(curRight[7])
                          + Sqr(curRight[8])
                          + Sqr(curRight[9])
                          + Sqr(curRight[10])
                          + Sqr(curRight[11])
                          + Sqr(curRight[12])
                          + Sqr(curRight[13])
                          + Sqr(curRight[14])
                          + Sqr(curRight[15]);
                    curRight += 16;
                }

                batchSamples -= curSamples;
                curSamplePos += curSamples;
                this.totSamp += curSamples;
                if (this.totSamp == this.sampleWindow)
                {
                    // Get the Root Mean Square (RMS) for this set of samples
                    double val = ReplayGain.STEPS_PER_DB * 10.0 * Math.Log10((this.lSum + this.rSum) / this.totSamp * 0.5 + 1.0e-37);
                    int ival = (int)val;
                    if (ival < 0) ival = 0;
                    if (ival >= this.gainData.Accum.Length) ival = this.gainData.Accum.Length - 1;
                    this.gainData.Accum[ival]++;
                    this.lSum = this.rSum = 0.0;

                    if (this.totSamp > int.MaxValue)
                    {
                        throw new OverflowException("Too many samples! Change to long and recompile!");
                    }

                    Array.Copy(this.lOutBuf, (int)this.totSamp, this.lOutBuf, 0, ReplayGain.MAX_ORDER);
                    Array.Copy(this.rOutBuf, (int)this.totSamp, this.rOutBuf, 0, ReplayGain.MAX_ORDER);
                    Array.Copy(this.lStepBuf, (int)this.totSamp, this.lStepBuf, 0, ReplayGain.MAX_ORDER);
                    Array.Copy(this.rStepBuf, (int)this.totSamp, this.rStepBuf, 0, ReplayGain.MAX_ORDER);

                    this.totSamp = 0;
                }
                if (this.totSamp > this.sampleWindow)
                {
                    // somehow I really screwed up: Error in programming! Contact author about totsamp > sampleWindow
                    throw new Exception("Gain analysis error!");
                }
            }

            if (numSamples < ReplayGain.MAX_ORDER)
            {
                Array.Copy(this.lInPreBuf, numSamples, this.lInPreBuf, 0, ReplayGain.MAX_ORDER - numSamples);
                Array.Copy(this.rInPreBuf, numSamples, this.rInPreBuf, 0, ReplayGain.MAX_ORDER - numSamples);
                Array.Copy(leftSamples.Array, leftSamples.Index, this.lInPreBuf, ReplayGain.MAX_ORDER - numSamples, numSamples);
                Array.Copy(rightSamples.Array, rightSamples.Index, this.rInPreBuf, ReplayGain.MAX_ORDER - numSamples, numSamples);
            }
            else
            {
                Array.Copy(leftSamples.Array, leftSamples.Index + numSamples - ReplayGain.MAX_ORDER, this.lInPreBuf, 0, ReplayGain.MAX_ORDER);
                Array.Copy(rightSamples.Array, rightSamples.Index + numSamples - ReplayGain.MAX_ORDER, this.rInPreBuf, 0, ReplayGain.MAX_ORDER);
            }
        }

        /// <summary>
        /// Returns the normalization gain for the track in decibels.
        /// </summary>
        public double GetGain()
        {
            return ReplayGain.AnalyzeResult(this.gainData.Accum);
        }

        /// <summary>
        /// Returns the peak title value, normalized to the [0,1] interval.
        /// </summary>
        public double GetPeak()
        {
            return this.gainData.PeakSample / ReplayGain.MAX_SAMPLE_VALUE;
        }
    }
}