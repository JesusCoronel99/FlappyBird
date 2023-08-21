using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundManager : MonoBehaviour
{

    [SerializeField]
    SpriteRenderer backGroundRenderer;

    [SerializeField]
    Sprite nightBackGround;
    [SerializeField]
    Sprite dayBackGround;

    [SerializeField]
    FlappyBird.PipeSpawner pipSpawner; 

    void Start()
    {
        int randomNum = Random.Range(0, 2);
        if (randomNum>0)
        {
            backGroundRenderer.sprite = dayBackGround;
            pipSpawner.SetPipeTime(true);
        }
        else
        {
            backGroundRenderer.sprite = nightBackGround;
            pipSpawner.SetPipeTime(false);
        }
    }

    
}
