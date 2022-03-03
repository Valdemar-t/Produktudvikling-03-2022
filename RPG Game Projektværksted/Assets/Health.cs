using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int startHealth;
    int currentHealth;
    // Start is called before the first frame update
    public void Start()
    {
        currentHealth = startHealth;
    }

    // Update is called once per frame
    public void Update()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("AttPoint"))
        {
            collision.gameObject.GetComponent()
        }
    }
}
