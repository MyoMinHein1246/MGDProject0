using UnityEngine;

[System.Serializable]
public struct BlockData
{
    public Color color;
    public Vector2 coord;

    public BlockData (Color color, Vector2 coord)
    {
        this.color = color;
        this.coord = coord;
    }
}