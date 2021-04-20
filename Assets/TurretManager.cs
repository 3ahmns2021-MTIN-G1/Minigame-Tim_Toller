using UnityEngine;

public class TurretManager : MonoBehaviour
{
    //Dieses Script hängt am TurretManager (ein Empty GameObject). Ich wollte das Turret und TurretManager script trennen.
    public int towerAmount;
    public GameObject towerPrefab;
    public GameObject projectilePrefab;

    //Auf welcher Höhe die Turrets Platziert sein sollen 
    public float y;

    void Start()
    {
        for (int i = 0; i < towerAmount; i++)
        {
            //erstelle das Turret GameObject
            GameObject tower = Instantiate(towerPrefab);


            Vector3 euler = transform.eulerAngles;
            euler.y = Random.Range(0, 360);

            float x = Random.Range(-5, 5);
            float z = Random.Range(-5, 5);

            tower.gameObject.transform.eulerAngles = euler;
            tower.gameObject.transform.position = new Vector3(x, y, z);
        }
    }



}
