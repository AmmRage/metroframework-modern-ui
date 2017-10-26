using System;
using System.IO;
using System.Speech.Synthesis;
using System.Speech.AudioFormat;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AmmPlayer.PlayerItems;
using JiebaNet.Segmenter;


namespace AmmPlayer.Players.TypedPlayers
{
    public class TextPlayer: IPlayer, IDisposable
    {
        private static Regex reg = new Regex(@"第[一两二三四五六七八九零十百千万]+章", RegexOptions.Compiled);

        private static JiebaSegmenter segmenter = new JiebaSegmenter();

        private SpeechSynthesizer Speaker;

        public TextPlayer()
        {
            this.Speaker = new SpeechSynthesizer
            {
                Rate = 0,
                Volume = 100,
            };
        }

        public void Stop()
        {
            continuePlay = false;
            Speaker.SpeakAsyncCancelAll();
        }

        public void Pause()
        {
            this.Speaker.Pause();
        }

        public void Resume()
        {
            this.Speaker.Resume();
        }

        private bool continuePlay = false;

        public void PlayAsync(TrackInfo trackInfo)
        {
            if (this.Speaker.State == SynthesizerState.Speaking)
            {
                Stop();
            }
            continuePlay = true;
            Task.Factory.StartNew(() =>
            {
                using (var sr = File.OpenText(trackInfo.Fullname))
                {
                    while (!sr.EndOfStream && continuePlay)
                    {
                        var line = sr.ReadLine();
                        var segments = segmenter.Cut(line);
                        this.Speaker.SpeakAsync(string.Join(" ", segments).Replace("丨", ""));
                    }
                }
            });    
        }

        public void Dispose()
        {
            try
            {
            }
            catch
            {
            }
        }
    }
}