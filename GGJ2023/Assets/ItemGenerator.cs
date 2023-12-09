using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    public GameObject[] items;
    // Start is called before the first frame update
    void Start()
    {
        float rng = Random.Range(0f, 1f);
        if (rng > 0.35f && rng < 0.5f)
        {
            Vector2 prefabPosition = new Vector2(transform.position.x, transform.position.y - 4);
            GameObject instantiatedItem = Instantiate(items[Random.Range(0,items.Length)], prefabPosition, Quaternion.identity);

            instantiatedItem.transform.parent = transform;
        }
    }
}
