using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockPool : MonoBehaviour
{
    public List<GameObject> blocks = new List<GameObject>();
    [SerializeField] GameManager gm;
    [SerializeField] GameObject blockOb;
    [SerializeField] float columns;
    [SerializeField] float rows;
    [SerializeField] Vector3 topPos;

    void Start()
    {
        CreateBlocks();
    }

    void CreateBlocks()
    {
        float x;
        float y = topPos.y;
        Vector3 pos;
        Color randCol;
        for (int i = 0; i < rows; i++)
        {
            x = topPos.x - ((blockOb.transform.localScale.x + 0.1f) * (columns / 2)) + (blockOb.transform.localScale.x / 2);
            for (int j = 0; j < columns; j++)
            {
                pos = new Vector3(x, y, 0);
                randCol = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 255);
                GameObject newBlock = Instantiate(blockOb, pos, Quaternion.identity, transform);
                blocks.Add(newBlock);
                newBlock.name = "Block";
                newBlock.GetComponent<SpriteRenderer>().color = randCol;
                x += newBlock.transform.localScale.x + 0.1f;
            }
            y -= blockOb.transform.localScale.y + 0.1f;
        }
    }
}
