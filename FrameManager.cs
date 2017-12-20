using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRuby.Threading;
using System;

/// <summary>
/// FrameManager
/// Nash
/// </summary>
public class FrameManager : MonoBehaviour
{
    private static FrameManager instance;
    private SceneAssetsManager sceneAssetsManager;

    public static FrameManager Instance
    {
        get
        {
            return instance;
        }
    }

    public static long currentNetworkFrame { get; protected set; }


    private bool isRunning = false;
    private void Awake()
    {
        instance = this;
    }

    public void StartGame()
    {
        Debug.Log("StartGame...");
        isRunning = true;
        sceneAssetsManager = gameObject.AddComponent<SceneAssetsManager>();
    }

    public void EndGame()
    {
        Debug.Log("EndGame...");
        isRunning = false;
        Destroy(sceneAssetsManager);
        sceneAssetsManager = null;
    }

    public void FireUnitFrameInfo(UnitFrameInfo unitInfo)
    {
        UnitFrameView unitFrameView = sceneAssetsManager.unitFrameViewMap[unitInfo.id];
        unitFrameView.AddFrameInfo(unitInfo);
    }

    void FixedUpdate()
    {
        if (isRunning)
        {
            currentNetworkFrame++;
            EZThread.ExecuteInBackground(DoFixedUpdate, UpdateUnitFrameInfo);
        }
    }

    private void UpdateUnitFrameInfo(object obj)
    {
        for (int i = 0; i < sceneAssetsManager.playerList.Count; i++)
        {
            Player player = sceneAssetsManager.playerList[i];
            UnitFrameView unitFrameView = sceneAssetsManager.unitFrameViewMap[player.myInfo.id];
            unitFrameView.AddFrameInfo(player.unitFrameInfo);
        }
    }

    private object DoFixedUpdate()
    {
        for (int i = 0; i < sceneAssetsManager.playerList.Count; i++)
        {
            Player player = sceneAssetsManager.playerList[i];
            player.DoFixedUpdate();
        }
        return null;
    }

    void Update()
    {
        if (isRunning)
        {
            for (int i = 0; i < sceneAssetsManager.unitFrameViewList.Count; i++)
            {
                UnitFrameView unitFrameView = sceneAssetsManager.unitFrameViewList[i];
                unitFrameView.DoUpdate();
            }
        }
    }
}
