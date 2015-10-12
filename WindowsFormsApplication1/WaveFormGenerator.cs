using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAudio.Wave
{
	class WaveFormGenerator : SynthModule
	{
		int sample = 0;
		public float Frequency { get; set; }
		public WaveFormProvider.WaveForm waveForm { get; set; }
		private int sampleRate;
		private const float tau = (float)(2 * Math.PI);

		public WaveFormGenerator()
		{
			sampleRate = 44100;
			waveForm = WaveFormProvider.WaveForm.Sin;
		}

		public void Read(float[] buffer, int offset, int sampleCount)
		{
			float samplesPerPeriod = sampleRate / Frequency;
			int sampleOffset;

			switch (waveForm)
			{
				case WaveFormProvider.WaveForm.Triangle:
					sampleOffset = sample + ((int)samplesPerPeriod / 4);

					break;
				case WaveFormProvider.WaveForm.Saw:
					sampleOffset = sample + ((int)samplesPerPeriod / 2);

					break;

				default:
					sampleOffset = 0;
					break;
			}

			for (int n = 0; n < sampleCount; n++)
			{
				switch (waveForm)
				{
					case WaveFormProvider.WaveForm.Sin:
						buffer[n + offset] = (float)(Math.Sin((tau * Frequency * sample) / sampleRate));
						break;

					case WaveFormProvider.WaveForm.Square:
						buffer[n + offset] = (sample % samplesPerPeriod >= samplesPerPeriod / 2) ? 1 : -1;
						break;

					case WaveFormProvider.WaveForm.Triangle:

						buffer[n + offset] = (sampleOffset % samplesPerPeriod >= samplesPerPeriod / 2)
							? 2 - 2 * (sampleOffset % (samplesPerPeriod / 2) / (samplesPerPeriod / 2)) - 1
							: 2 * ((sampleOffset % (samplesPerPeriod / 2)) / (samplesPerPeriod / 2)) - 1;
						break;

					case WaveFormProvider.WaveForm.Saw:
						buffer[n + offset] = ((((sample + (samplesPerPeriod / 2)) % samplesPerPeriod) / samplesPerPeriod) * 2 - 1);
						break;

					default:
						break;
				}
				sample++;

				if (sample >= sampleRate) sample = 0;
			}
		}
	}
}
