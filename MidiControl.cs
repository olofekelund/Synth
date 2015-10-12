using System;
using NAudio.Midi;

namespace AudioInterface
{
	public class MidiControl
	{
		public MidiIn midiIn;
		private bool monitoring;
		private int midiInDevice;

		public MidiControl()
		{
			monitoring = false;
			midiInDevice = 0;
		}
		
		public string[] GetMIDIInDevices()
		{
			// Get a list of devices  
			string[] returnDevices = new string[MidiIn.NumberOfDevices];
			

			// Get the product name for each device found  
			for (int device = 0; device < MidiIn.NumberOfDevices; device++)
			{
				returnDevices[device] = MidiIn.DeviceInfo(device).ProductName;
				Consonle.WriteLine(returnDevices[device]);
			}


			return returnDevices;
		}
	}
}

