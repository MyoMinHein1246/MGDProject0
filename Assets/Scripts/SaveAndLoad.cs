using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveAndLoad : MonoBehaviour
{
    [SerializeField] private Builder builder;
    [SerializeField] private UIManager uiManager;
    [SerializeField] private float delay = 0.1f;

    public void Save()
    {
        StartCoroutine(SaveCor());
    }

    public void Load()
    {
        var blocks = SaveSystem.Load();

        if (blocks == null)
        {
            Debug.LogError("Failed to load blocks.");
            return;
        }

        StartCoroutine(LoadBlocks(blocks));
    }

    private List<BlockData> GetBlockData()
    {
		if (!builder)
		{
			Debug.LogError("Failed to save blocks - builder is not found.");
			return null;
		}

        List<BlockData> blockData = new List<BlockData>();

        foreach (var block in builder.GetBlockBuiltBlocks())
        {
            blockData.Add(block.BlockData);
        }

        return blockData;
	}

    private IEnumerator SaveCor()
    {
		uiManager.UpdateUI(UIState.Saving);

        yield return null;
		yield return SaveSystem.Save(GetBlockData());

		uiManager.UpdateUI(UIState.Normal);
	}

    private IEnumerator LoadBlocks(List<BlockData> blocks)
    {
        uiManager.UpdateUI(UIState.Loading);
        builder.DeleteAll();

		var t = new WaitForSeconds(delay);

        yield return t;

		foreach (var blockData in blocks)
		{
			builder.Build(blockData);
            yield return t;
		}

        uiManager.UpdateUI(UIState.Normal);
	}
}
