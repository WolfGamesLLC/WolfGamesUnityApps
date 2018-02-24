using MarbleMotionBackEnd.Interfaces;
using MarbleMotionBackEnd.EventArgs;
using System;
using System.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButtonView : MonoBehaviour, IStartButtonView
{
    /// <summary>
    /// Event for mapping actions to the OnClicked event
    /// </summary>
    public event EventHandler<StartButtonClickedEventArgs> OnClicked = (sender, e) => { };

    /// <summary>
    /// Method used to allow unity to run the OnClicked event
    /// </summary>
    public void RunOnClickedEvent()
    {
        OnClicked(this, new StartButtonClickedEventArgs());
	}
}
