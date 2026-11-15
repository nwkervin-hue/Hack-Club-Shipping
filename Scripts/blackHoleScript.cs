using UnityEngine;

public class blackHoleScript : MonoBehaviour
{
    private gunScript gunScript;
    private GameObject Player;
    public float Pullforce = 10f; // Adjust the force magnitude as needed
    public float pullDiminishing = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        gunScript = GameObject.FindWithTag("gun").GetComponent<gunScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        Vector2 direction = (Player.transform.position - transform.position).normalized;
        float distance = Vector2.Distance(Player.transform.position, transform.position);
        float forceMagnitude = -1 * Pullforce / (distance * distance * pullDiminishing); // Adjust the force magnitude as needed
        Vector2 force = direction * forceMagnitude;

        Player.GetComponent<Rigidbody2D>().AddForce(force);
        foreach (GameObject bullet in gunScript.bullets)
        {
            if (bullet != null)
            {
                Vector2 bulletDirection = (bullet.transform.position - transform.position).normalized;
                float bulletDistance = Vector2.Distance(bullet.transform.position, transform.position);
                float bulletForceMagnitude = -1 *Pullforce / (bulletDistance * bulletDistance * pullDiminishing); // Adjust the force magnitude as needed
                Vector2 bulletForce = bulletDirection * bulletForceMagnitude;

                bullet.GetComponent<Rigidbody2D>().AddForce(bulletForce);
            }
        }
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");

        foreach (GameObject enemy in enemies)
        {
            Vector2 enemyDirection = (Player.transform.position - transform.position).normalized;
            float enemyDistance = Vector2.Distance(Player.transform.position, transform.position);
            float enemyForceMagnitude = -1 * Pullforce / (enemyDistance * enemyDistance * pullDiminishing); // Adjust the force magnitude as needed
            Vector2 enemyForce = enemyDirection * enemyForceMagnitude;
            Vector3 enemyPosition = enemy.transform.position;
            enemy.transform.position = new Vector3(enemyPosition.x + enemyForce.x * Time.fixedDeltaTime, enemyPosition.y + enemyForce.y * Time.fixedDeltaTime, enemyPosition.z);
        }
    }
}
