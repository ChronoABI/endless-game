using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{
    [SerializeField]GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        float Difference = player.transform.position.x - transform.position.x;
        Debug.Log(Difference);
        if (Difference > 100)
        {
            Destroy(this.gameObject);
        }
    }
}
