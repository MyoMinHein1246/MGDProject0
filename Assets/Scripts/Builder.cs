using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Builder : MonoBehaviour
{
    [SerializeField] private Block blockPrefab;
    [SerializeField] private MinMax width;
    [SerializeField] private MinMax height;

    private Dictionary<Vector2, Block> builtBlocks = new Dictionary<Vector2, Block>();
    
    public void Build(BlockData blockData)
    {
        if (builtBlocks.ContainsKey(blockData.coord))
        {
            print($"Already built at {blockData.coord}.");
            return;
        }

        if (!IsInside(blockData.coord))
        {
            print("Outside of the grid.");
            return;
        }

        var block = Instantiate(blockPrefab, blockData.coord, Quaternion.identity);
        block.Set(blockData);

        builtBlocks.Add(blockData.coord, block);

        print($"Built at {block.transform.position} using {blockData.color}.");
    }

    public void DeleteAt(Vector2 coord)
    {
        if (builtBlocks.TryGetValue(coord, out var block))
        {
            builtBlocks.Remove(coord);
            Destroy(block.gameObject);
        }
    }

    public void DeleteAll()
    {
        foreach (var block in builtBlocks.Values)
        {
            Destroy(block.gameObject);
        }

        builtBlocks.Clear();
    }

	public bool IsInside(Vector3 pos)
    {
        return pos.x < width.max && pos.x > width.min
            && pos.y < height.max && pos.y > height.min;
    }

    public Dictionary<Vector2, Block> GetBlockBuiltBlocks() => builtBlocks;
}
