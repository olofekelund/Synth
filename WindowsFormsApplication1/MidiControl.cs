using System;
using NAudio.Midi;

namespace WindowsFormsApplication1
{
	public class MidiKeyPressedEventArgs : EventArgs
	{
		public int noteNumber {	get; set;	}
	}
	public class MidiControl
	{
		public MidiIn midiIn;
		
		public event EventHandler<MidiKeyPressedEventArgs> MidiKeyPressed;

		public MidiControl(int device)
		{
			midiIn = new MidiIn(device);
		}
		
		public void startDeviceListener()
		{
			midiIn.Start();

			midiIn.MessageReceived += new EventHandler<MidiInMessageEventArgs>(midiIn_MessageReceived);
		}

		public void midiIn_MessageReceived(object sender, MidiInMessageEventArgs e)
		{
			// Exit if the MidiEvent is null or is the AutoSensing command code  
			if (e.MidiEvent != null && e.MidiEvent.CommandCode == MidiCommandCode.AutoSensing)
			{
				return;
			}

			if (e.MidiEvent.CommandCode == MidiCommandCode.NoteOn)
			{
				NoteOnEvent ne = (NoteOnEvent)e.MidiEvent;
				
				OnMidiKeyPressed(ne.NoteNumber);
			}
		}

		protected virtual void OnMidiKeyPressed(int n)
		{
			if (MidiKeyPressed != null)
				MidiKeyPressed(this, new MidiKeyPressedEventArgs() { noteNumber = n });
		}
			

		public string[] GetMIDIInDevices()
		{
			// Get a list of devices  
			string[] returnDevices = new string[MidiIn.NumberOfDevices];
			

			// Get the product name for each device found  
			for (int device = 0; device < MidiIn.NumberOfDevices; device++)
			{
				returnDevices[device] = MidiIn.DeviceInfo(device).ProductName;
				Console.WriteLine(returnDevices[device]);
			}
			
			return returnDevices;
		}
	}
}

