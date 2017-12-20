using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
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

    private void Awake()
    {
        instance = this;
    }

    public void StartGame()
    {
        sceneAssetsManager = gameObject.AddComponent<SceneAssetsManager>();
    }

    public void EndGame()
    {
        GameObject.Destroy(sceneAssetsManager);
        sceneAssetsManager = null;
    }

    public void FireUnitFrameInfo(UnitFrameInfo unitInfo)
    {
        UnitFrameView unitFrameView = sceneAssetsManager.unitFrameViewMap[unitInfo.id];
        unitFrameView.AddFrameInfo(unitInfo);
    }

    void FixedUpdate()
    {
        //todo multiple thread
        for (int i = 0; i < sceneAssetsManager.playerList.Count; i++)
        {
            Player player = sceneAssetsManager.playerList[i];
            player.DoFixedUpdate();
        }
    }

    void Update()
    {
        for (int i = 0; i < sceneAssetsManager.unitFrameViewList.Count; i++)
        {
            UnitFrameView unitFrameView = sceneAssetsManager.unitFrameViewList[i];
            unitFrameView.DoUpdate();
        }
    }
}
