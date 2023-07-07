using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Builder : MonoBehaviour
{
    [SerializeField] private Block blockPrefab;
    [SerializeField] private MinMax width;
    [SerializeField] private MinMax height;

    private List<Block> builtBlocks = new List<Block>();
    
    public void Build(BlockData blockData)
    {
        if (ExistsAt(blockData.coord))
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

        builtBlocks.Add(block);

        print($"Built at {block.transform.position} using {blockData.color}.");
    }

    public void DeleteAt(Vector2 coord)
    {
		for (int i = 0; i < builtBlocks.Count; i++)
		{
            if (builtBlocks[i].BlockData.coord == coord)
            {
                Delete(builtBlocks[i]);
                break;
            }
        }
    }

    public void DeleteAll()
    {
        for (int i = 0; i <  builtBlocks.Count; i++)
        {
            Delete(builtBlocks[i]);
        }

        builtBlocks.Clear();
    }

	public void Delete(Block block)
	{
        if (block)
		    Destroy(block.gameObject);
	}

    public bool ExistsAt(Vector2 coord)
    {
        for (int i = 0; i < builtBlocks.Count; i++)
        {
            if (builtBlocks[i].BlockData.coord == coord)
            {
                return true;
            }
        }

        return false;
    }

	public bool IsInside(Vector3 pos)
    {
        return pos.x < width.max && pos.x > width.min
            && pos.y < height.max && pos.y > height.min;
    }

    public List<Block> GetBlockBuiltBlocks() => builtBlocks;
}
