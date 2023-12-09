using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GapSetter : MonoBehaviour
{
    public GameObject[] platforms;
    public float[] initialXScale;
    public ScoreKeeper scoreKeeper;

    // Start is called before the first frame update
    void Start()
    {
       for (int i = 0; i < platforms.Length; i++) 
        {
            initialXScale[i] = platforms[i].transform.localScale.x;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0;i < platforms.Length;i++) 
        {
            
        }
    }
}
