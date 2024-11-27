using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{
    public Transform minPoint, maxPoint;

    public GrowBlock baseGridBlock;

    private Vector2Int gridSize;

    public List<BlockRow> blockRows = new List<BlockRow>();

    public LayerMask gridBlockers;

    private void Start()
    {
        GenerateGrid();
    }

    private void GenerateGrid()
    {
        minPoint.position = new Vector3(Mathf.Round(minPoint.position.x), Mathf.Round(minPoint.position.y), 0f);
        maxPoint.position = new Vector3(Mathf.Round(maxPoint.position.x), Mathf.Round(maxPoint.position.y), 0f);

        Vector3 startPoint = minPoint.position + new Vector3(.5f, .5f, 0f);

        gridSize = new Vector2Int(Mathf.RoundToInt(maxPoint.position.x - minPoint.position.x),
            Mathf.RoundToInt(maxPoint.position.y - minPoint.position.y));

        for (int y = 0; y < gridSize.y; y++)
        {
            blockRows.Add(new BlockRow());

            for (int x = 0; x < gridSize.x; x++)
            {
                GrowBlock newBlock = Instantiate(baseGridBlock, startPoint + new Vector3(x, y, 0f), Quaternion.identity);
                newBlock.transform.SetParent(transform);

                blockRows[y].blocks.Add(newBlock);

                if (Physics2D.OverlapBox(newBlock.transform.position, new Vector2(.9f, .9f), 0f, gridBlockers))
                {
                    newBlock.theSR.sprite = null;
                    newBlock.preventUse = true;
                }
            }
        }

        baseGridBlock.gameObject.SetActive(false);
    }
}

[System.Serializable]
public class BlockRow
{
    public List<GrowBlock> blocks = new List<GrowBlock>();
}
