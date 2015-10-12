using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAudio.Wave
{
	interface SynthModule
	{
		void Read(float[] buffer, int offset, int sampleCount);
  }
}
