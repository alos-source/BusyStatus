using System;
using NAudio.CoreAudioApi;
using NAudio.CoreAudioApi.Interfaces;

public class BusyLight
{
    private MMDeviceEnumerator deviceEnumerator;
    private MMDevice device;

    public BusyLight()
    {
        // Initialize WASAPI
        deviceEnumerator = new MMDeviceEnumerator();
        device = deviceEnumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);
        device.AudioSessionManager.OnSessionCreated += OnSessionCreated;
    }

    private void OnSessionCreated(object sender, IAudioSessionControl newSession)
    {
        newSession.RegisterAudioSessionNotification(new AudioSessionEvents());
    }

    private class AudioSessionEvents : IAudioSessionEvents
    {
        public void OnStateChanged(AudioSessionState state)
        {
            if (state == AudioSessionState.AudioSessionStateActive)
            {
                Console.WriteLine("A new audio session is active.");
                // Additional logic to determine if this is a call
            }
        }

        public int OnDisplayNameChanged(string displayName, ref Guid eventContext)
        {
            throw new NotImplementedException();
        }

        public int OnIconPathChanged(string iconPath, ref Guid eventContext)
        {
            throw new NotImplementedException();
        }

        public int OnSimpleVolumeChanged(float volume, bool isMuted, ref Guid eventContext)
        {
            throw new NotImplementedException();
        }

        public int OnChannelVolumeChanged(uint channelCount, IntPtr newVolumes, uint channelIndex, ref Guid eventContext)
        {
            throw new NotImplementedException();
        }

        public int OnGroupingParamChanged(ref Guid groupingId, ref Guid eventContext)
        {
            throw new NotImplementedException();
        }

        int IAudioSessionEvents.OnStateChanged(AudioSessionState state)
        {

            if (state == AudioSessionState.AudioSessionStateActive)
            {
                Console.WriteLine("A new audio session is active.");
                // Additional logic to determine if this is a call
            }
//            if (state == AudioSessionState.AudioSessionStateInactive) 
  //          {
    //            Console.WriteLine("A new audio session is inactive.");
      //      }
            return 0;
            //throw new NotImplementedException();


        }

        public int OnSessionDisconnected(AudioSessionDisconnectReason disconnectReason)
        {
            throw new NotImplementedException();
        }

        // Implement other IAudioSessionEvents methods as needed.
    }

    public static void Main()
    {
        BusyLight busyLight = new BusyLight();
        Console.WriteLine("Monitoring audio sessions...");
        Console.ReadLine(); // Keep the application running to monitor events.
    }
}
