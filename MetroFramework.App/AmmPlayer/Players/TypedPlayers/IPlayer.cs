using AmmPlayer.PlayerItems;

namespace AmmPlayer.Players.TypedPlayers
{
    public interface IPlayer
    {
        void PlayAsync(TrackInfo trackInfo);

        void Stop();

        void Pause();

        void Resume();
    }
}