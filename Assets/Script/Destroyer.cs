using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Part")
        {

            Debug.Log("Destroyed");
            Destroy(other.gameObject);
        }
    }
}
