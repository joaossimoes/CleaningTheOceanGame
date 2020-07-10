using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStrip : MonoBehaviour
{
    [SerializeField] GameObject blocks;
    [SerializeField] float speed = 1.0f;


    Vector3 movePos;
    float blocksPos;
    public int blocksInLine = 0;

    void Start()
    {
        blocksPos = blocks.transform.position.y;        
    }

    
    void Update()
    {
        if ( blocksInLine <= 0)
        {
            movePos = new Vector3(blocks.transform.position.x, blocksPos - 1, blocks.transform.position.z);
            if (blocks.transform.position != movePos)
            {
                Vector3 newPos = Vector3.MoveTowards(blocks.transform.position, movePos, speed * Time.deltaTime);
                blocks.transform.position = newPos;
            }
            else
            {
                blocksPos = blocksPos - 1;
            }
        }
    }

    public void AddBlockToLine()
    {
        blocksInLine++;
    }

    public void SubtractBlockFromLine()
    {
        blocksInLine--;
    }
  
}
