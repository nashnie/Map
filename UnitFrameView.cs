using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// unit view
/// Nash
/// </summary>
public class UnitFrameView : MonoBehaviour
{
    public BaseUnitInfo myInfo;
    public UnitFrameInfo frameInfo;
    public List<UnitFrameInfo> frameInfoList;

    private List<Vector3> baseFrameVector3List;
    private List<long> baseFrameVector3IndexList;
    private List<float> baseFrameQuaternionList;

    private int delayGap = 1;

    public static readonly int defaultDelayGap = 1;

    public void AddFrameInfo(UnitFrameInfo frameInfo)
    {
        frameInfoList.Add(frameInfo);
    }

    void Start()
    {
        frameInfoList = new List<UnitFrameInfo>();

        baseFrameVector3List = new List<Vector3>();
        baseFrameQuaternionList = new List<float>();
        baseFrameVector3IndexList = new List<long>();

        delayGap = defaultDelayGap;
    }

    protected virtual void InitHUD()
    {
        //TODO shadow bloodbar ect...
    }

    public virtual void InitCharacter()
    {
        //TODO Instantiate Character
    }

    public void DoUpdate()
    {
        //lerp position and rotation
        //play effect 
        //etc..
    }

    public void Clear()
    {
        frameInfoList.Clear();
        baseFrameVector3List.Clear();
        baseFrameVector3IndexList.Clear();
        baseFrameQuaternionList.Clear();

        delayGap = defaultDelayGap;
    }

    public void Destroy()
    {
        //TODO cache
        Clear();
    }
}
