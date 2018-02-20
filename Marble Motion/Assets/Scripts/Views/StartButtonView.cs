using MarbleMotionBackEnd.Interfaces;
using MarbleMotionBackEnd.EventArgs;
using System;
using System.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButtonView : MonoBehaviour, IStartButtonView
{
    public event EventHandler<StartButtonClickedEventArgs> OnClicked = (sender, e) => { };

    // Update is called once per frame
    void Update () {
		
	}
}
