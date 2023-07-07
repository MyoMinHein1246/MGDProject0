using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sr;

    public BlockData BlockData {  get; private set; }

    public void Set(BlockData blockData)
    {
        sr.color = blockData.color;

        this.BlockData = blockData;
    }
}
