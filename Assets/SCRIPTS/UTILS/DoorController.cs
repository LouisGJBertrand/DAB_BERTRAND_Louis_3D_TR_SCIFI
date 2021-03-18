using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class DoorController : Listner
{

    public Transform Transform;

    public Vector3 InitialOffset = Vector3.zero;

    public Vector3 TargetOffset = new Vector3(0, 2, 0);

    public Vector3 ActualOffset;

    private Vector3 TransformPosition;

    public bool IsOpened = false;
    public bool LastOpenState = false;

    public bool IsLockedInPosition = false;

    private Stopwatch OpenedStateStopwatch;
    public float OpenedStateDuration;

    private Vector3 velocity = Vector3.zero;
    private float OpeningDelta;

    public AudioSource DoorSoundEmitter;
    public AudioClip DoorSoundClip;

    public float DoorOpeningSpeedMultiplier = 0.5f;

    public void Start()
    {
        TransformPosition = Transform.position;

        ActualOffset = IsOpened ? TargetOffset : InitialOffset;

        OpenedStateStopwatch = new Stopwatch();
        LastOpenState = IsOpened;
        Transform.position = TransformPosition + ActualOffset;
    }

    public void Update()
    {

        if(IsLockedInPosition)
        { return; }

        if (ActualOffset == InitialOffset)
        {
            LastOpenState = false;
        }
        else
        if (ActualOffset == TargetOffset)
        {

            if (!OpenedStateStopwatch.IsRunning)
            {

                OpenedStateStopwatch.Reset();
                OpenedStateStopwatch.Start();

            }

            if (OpenedStateStopwatch.IsRunning && OpenedStateStopwatch.Elapsed.TotalSeconds >= (double) OpenedStateDuration)
            {
                DoorSoundEmitter.PlayOneShot(DoorSoundClip);
                OpenedStateStopwatch.Stop();
                IsOpened = false;
            }
            else
            {
                LastOpenState = true;
            }
        }

        if (IsOpened != LastOpenState)
        {

            var a = ActualOffset;
            var b = IsOpened ? TargetOffset : InitialOffset;
            float t = 0.1f * DoorOpeningSpeedMultiplier;
            ActualOffset = a + (b - a) * t;
            //ActualOffset = Vector3.SmoothDamp(current: ActualOffset, target: IsOpened ? TargetOffset : InitialOffset, currentVelocity: ref velocity, smoothTime: 1.0f, maxSpeed: Mathf.Infinity, deltaTime: OpeningDelta);

            if (Math.Abs((TargetOffset - ActualOffset).x) <= 0.0001 || Math.Abs((InitialOffset + ActualOffset).x) <= 0.0001)
                ActualOffset.x = (float)Math.Round(ActualOffset.x, 3);

            if (Math.Abs((TargetOffset - ActualOffset).y) <= 0.0001 || Math.Abs((InitialOffset + ActualOffset).y) <= 0.0001)
                ActualOffset.y = (float)Math.Round(ActualOffset.y, 3);

            if (Math.Abs((TargetOffset - ActualOffset).z) <= 0.0001 || Math.Abs((InitialOffset + ActualOffset).z) <= 0.0001)
                ActualOffset.z = (float)Math.Round(ActualOffset.z, 3);

            //ActualOffset = Vector3.Lerp(IsOpened ? TargetOffset : InitialOffset, ActualOffset, 1.0f);
        }

        Transform.position = TransformPosition + ActualOffset;

    }

    public override void OnGameObjectEvent(object sender, GameBojectEventArgs e)
    {
        if (IsLockedInPosition)
            return;

        if (ActualOffset != InitialOffset)
            return;

        if (IsOpened)
            return;

        DoorSoundEmitter.PlayOneShot(DoorSoundClip);
        IsOpened = true;

    }

}
