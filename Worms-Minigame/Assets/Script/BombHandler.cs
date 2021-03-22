using UnityEngine;

public class BombHandler : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "a")
        {
            Destroy(gameObject);
        }
    }

}
