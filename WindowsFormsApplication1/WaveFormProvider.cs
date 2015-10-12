using System;

namespace NAudio.Wave
{
	public class WaveFormProvider : WaveProvider32
	{
		private WaveFormGenerator waveFormGenerator;
		private VolumeControl volumeControl;
		// private Filter filter;
		private int sampleRate;
		public int sample = 0;
		public WaveForm waveForm = WaveForm.Saw;
		private const float tau = (float)(2 * Math.PI);

		public WaveFormProvider()
    {
			sampleRate = WaveFormat.SampleRate;
			waveFormGenerator = new WaveFormGenerator();
			// filter = new Filter();
			volumeControl = new VolumeControl(0.5f);
		}

		public void setAmplitude(float a)
		{
			volumeControl.amplitude = a;
		}

		public void setFrequency(float f)
		{
			waveFormGenerator.Frequency = f;
		}

		public void setWaveForm(WaveForm waveForm)
		{
			waveFormGenerator.waveForm = waveForm;
		}

    public override int Read(float[] buffer, int offset, int sampleCount)
    {
			waveFormGenerator.Read(buffer, offset, sampleCount);
			volumeControl.Read(buffer, offset, sampleCount);

			return sampleCount;
    }

		public enum WaveForm
		{
			Sin,
			Square,
			Triangle,
			Saw,
		}
	}
}