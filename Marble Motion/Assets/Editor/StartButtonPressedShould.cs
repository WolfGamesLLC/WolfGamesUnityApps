﻿using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class StartButtonPressedShould {

	[Test]
	public void StartButtonPressedShouldSimplePasses() {
        // Use the Assert class to test conditions.
        Assert.Fail();
	}

	// A UnityTest behaves like a coroutine in PlayMode
	// and allows you to yield null to skip a frame in EditMode
	[UnityTest]
	public IEnumerator StartButtonPressedShouldWithEnumeratorPasses() {
		// Use the Assert class to test conditions.
		// yield to skip a frame
		yield return null;

        Assert.Fail();
    }
}
