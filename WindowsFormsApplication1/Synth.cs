using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using NAudio.Wave;


namespace WindowsFormsApplication1
{
  class Synth
  {
    private DirectSoundOut waveOut;
    private WaveFormProvider waveFormProvider = new WaveFormProvider();
    private Boolean playing = false;
		private int midiDeviceNumber = 0;

		public Synth()
		{
			MidiControl midiControl = new MidiControl(midiDeviceNumber);
			midiControl.startDeviceListener();
			midiControl.MidiKeyPressed += MidiControl_MidiKeyPressed;

			waveFormProvider.SetWaveFormat(44100, 1); // 44.1 kHz mono
			waveFormProvider.setAmplitude(0.1f);
			waveFormProvider.setFrequency(500);
			waveFormProvider.setWaveForm(WaveFormProvider.WaveForm.Saw);
			      
      waveOut = new DirectSoundOut(50);
      waveOut.Init(waveFormProvider);
		}

		private void MidiControl_MidiKeyPressed(object source, MidiKeyPressedEventArgs args)
		{
			Console.WriteLine("Midi key pressed: " + args.noteNumber);
		}

		public void StartStopSineWave()
    {
      if (!playing)
      {
        waveOut.Play();
        playing = true;
			}
      else
      {
        waveOut.Stop();
        playing = false;
      }
    }
        
    public void setFrequency(float f)
    {
			waveFormProvider.setFrequency(f);
    }

    ~Synth()
    {
      if (playing) waveOut.Stop();
      waveOut.Dispose();
      waveOut = null;
    }
  }
}
