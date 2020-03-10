using UnityEngine;

public class SpinCandidateData
{
    public int MapIndex => mapIndex;
    public Sprite Sprite => sprite;
    
    
    private readonly int mapIndex;
    public readonly Sprite sprite;

    public SpinCandidateData(int mapIndex, Sprite sprite)
    {
        this.mapIndex = mapIndex;
        this.sprite = sprite;
    }
}