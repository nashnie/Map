using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneAssetsManager : MonoBehaviour
{
    public List<Player> playerList;
    public List<UnitFrameView> unitFrameViewList;
    public Dictionary<long, UnitFrameView> unitFrameViewMap;

    public void Awake()
    {
        playerList = new List<Player>();
        unitFrameViewList = new List<UnitFrameView>();
        unitFrameViewMap = new Dictionary<long, UnitFrameView>();

        AddPlayer();
    }

    private void AddPlayer()
    {
        Debug.Log("AddPlayer...");
        Player player = new Player();
        BaseUnitInfo info = new BaseUnitInfo();
        //TODO copy data from server and config
        player.Init(info);

        GameObject unitFrameShell = GameObject.CreatePrimitive(PrimitiveType.Cube);
        UnitFrameView unitFrameView = unitFrameShell.AddComponent<UnitFrameView>();
        unitFrameView.myInfo = info;

        playerList.Add(player);
        unitFrameViewList.Add(unitFrameView);
        unitFrameViewMap.Add(info.id, unitFrameView);
    }

    public void OnDestroy()
    {
        for (int i = 0; i < playerList.Count; i++)
        {
            Player player = playerList[i];
            player.Destroy();
        }
        for (int i = 0; i < unitFrameViewList.Count; i++)
        {
            UnitFrameView unitFrameView = unitFrameViewList[i];
            unitFrameView.Destroy();
        }
        unitFrameViewMap.Clear();
        unitFrameViewList = null;
        unitFrameViewMap = null;
        playerList = null;
    }
}
