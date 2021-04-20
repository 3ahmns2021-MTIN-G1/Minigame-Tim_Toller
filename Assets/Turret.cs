using UnityEngine;

public class Turret : MonoBehaviour
{
    //Dieses Script hängt am Turret Prefab. Ich wollte das Turret und TurretManager script trennen.
    public float fireRate;
    private float timeStamp;

    public GameObject projectilePrefab;
    public Vector3 shootForce;
    public Transform spawnPoint;

    void Update()
    {
        //Schaut ob der Cooldown vorbei ist
        if (timeStamp < Time.time)
        {
            timeStamp = Time.time + fireRate;

            //Erstelle das Projektil
            GameObject projectile = Instantiate(projectilePrefab, spawnPoint.position, spawnPoint.rotation);

            //Add Force
            projectile.GetComponent<Rigidbody>().AddRelativeForce(shootForce, ForceMode.Impulse);

            //Serstöre die Projectiles nach 5 Sekunden damit mein PC nicht stirbt
            Destroy(projectile, 5);
        }
    }
}
