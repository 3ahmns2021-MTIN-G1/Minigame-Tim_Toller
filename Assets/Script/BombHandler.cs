using UnityEngine;

public class BombHandler : MonoBehaviour
{
    public GameObject particle;
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            Vector3 pos = transform.position;

            pos.y += 2f;
            GameObject partGo = Instantiate(particle, pos, Quaternion.identity) as GameObject;
            partGo.SetActive(true);
            Destroy(partGo, 2f);
            Destroy(gameObject);
        }
    }


}
