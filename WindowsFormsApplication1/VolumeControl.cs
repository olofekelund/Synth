using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAudio.Wave
{
	class VolumeControl : SynthModule
	{
		public float amplitude { get; set; }

		public VolumeControl(float a)
		{
			amplitude = a;
		}

		public void Read(float[] buffer, int offset, int sampleCount)
		{
			for (int n = 0; n < sampleCount; n++)
			{
				buffer[n] = buffer[n] * amplitude;
			}
		}
	}
}
