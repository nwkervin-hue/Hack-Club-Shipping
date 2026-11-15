using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private GameObject Player;
    public float speed = 2f; // Adjust the speed as needed
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        if (Vector2.Distance(Player.transform.position, transform.position) < 10f)
        {
            Player.GetComponent<playercontroller>().Death();
        }
        transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("bullet"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
