using Assets.Scripts.Services;
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
    /// The instance of an object that implements <see cref="IPlayerModel"/>
    /// that this object is the view for
    /// </summary>
    public IPlayerModel Model { get; set; }

    /// <summary>
    /// Update the player's avatar with its <see cref="IPlayerModel"/>
    /// </summary>
    private void Update()
    {
        transform.position = TypeConverter.WGVector3ToVector3(Model.Position);
    }

    /// <summary>
    /// Fired when a player object position changes
    /// </summary>
    public event EventHandler<OnPlayerPositionChangedEventArgs> OnPlayerPositionChanged;
}
