using System;
using System.Windows.Forms;
using AmmPlayer.PlayerItems;
using AmmPlayer.Players.TypedPlayers;
using MetroFramework;

namespace AmmPlayer.Players
{
    public class PlayerFactory
    {
        public static IPlayer Play(TrackInfo trackInfo)
        {
            if (trackInfo.TrackType == MediaType.Musical)
            {
                return new MusicalPlayer();
            }
            else if (trackInfo.TrackType == MediaType.Text)
            {
                return new TextPlayer();
            }
            else
            {
                throw new Exception("Unknown file type.");
            }
        }
    }
}