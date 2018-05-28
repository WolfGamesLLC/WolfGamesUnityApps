using MarbleMotionBackEnd.EventArgs;
using MarbleMotionBackEnd.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The player's view object
/// </summary>
public class PlayerView : MonoBehaviour , IPlayerView
{
    /// <summary>
    /// Fired when a player object position changes
    /// </summary>
    public event EventHandler<PlayerPositionChangedEventArgs> OnPlayerPositionChanged;
}
