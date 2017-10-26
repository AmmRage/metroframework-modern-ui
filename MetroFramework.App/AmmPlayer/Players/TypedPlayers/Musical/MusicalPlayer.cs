using System.Collections.ObjectModel;
using AmmPlayer.PlayerItems;
using CSCore;
using CSCore.Codecs;
using CSCore.CoreAudioAPI;
using CSCore.SoundOut;

namespace AmmPlayer.Players.TypedPlayers
{
    public class MusicalPlayer: IPlayer
    {
        private readonly ObservableCollection<MMDevice> _devices = new ObservableCollection<MMDevice>();

        private ISoundOut _soundOut;

        private IWaveSource _waveSource;

        public MusicalPlayer()
        {
            using (var mmdeviceEnumerator = new MMDeviceEnumerator())
            {
                using (var mmdeviceCollection = mmdeviceEnumerator.EnumAudioEndpoints(DataFlow.Render, DeviceState.Active))
                {
                    foreach (var device in mmdeviceCollection)
                    {
                        this._devices.Add(device);
                    }
                }
            }
            this._soundOut = new WasapiOut() { Latency = 100, Device = this._devices[0] };
        }

        public void PlayAsync(TrackInfo trackInfo)
        {
            if (this._waveSource != null)
            {
                this._waveSource.Dispose();
            }

            if (this._soundOut.PlaybackState == PlaybackState.Playing)
            {
                Stop();
            }

            this._waveSource = CodecFactory.Instance.GetCodec(trackInfo.Fullname)
                .ToSampleSource()
                .ToMono()
                .ToWaveSource();
            this._soundOut.Initialize(this._waveSource);
            this._soundOut.Play();
        }

        public void Stop()
        {
            this._soundOut.Stop();
        }

        public void Pause()
        {
            this._soundOut.Pause();
        }

        public void Resume()
        {
            this._soundOut.Resume();
        }

        ~MusicalPlayer()
        {
            try
            {
                if (this._soundOut != null)
                {
                    this._soundOut.Dispose();
                    this._soundOut = null;
                }
                if (this._waveSource != null)
                {
                    this._waveSource.Dispose();
                    this._waveSource = null;
                }
            }
            catch
            {
            }
        }
    }
}