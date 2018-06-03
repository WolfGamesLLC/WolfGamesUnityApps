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
//        transform.position = TypeConverter.WGVector3ToVector3(Model.Position);
    }

    /// <summary>
    /// Fire the <see cref="OnLoad"/> event
    /// </summary>
    public void RunOnLoadEvent()
    {
        OnLoad(this, new OnPlayerLoadEventArgs());
    }

    /// <summary>
    /// Fired when a player object needs to be loaded from storage
    /// </summary>
    public event EventHandler<OnPlayerLoadEventArgs> OnLoad;

    /// <summary>
    /// Method used to allow the <see cref="IPlayerController"/> to set the view's position
    /// with the <see cref="IPlayerModel"/> data
    /// </summary>
    /// <param name="">The <see cref="IPlayerModel"/> that contains the new position</param>
    public void SetPosition(IPlayerModel playerModel)
    {
        transform.position = TypeConverter.WGVector3ToVector3(playerModel.Position);
    }
}
