using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] short lives = 3;
    Mods mods;
    // Start is called before the first frame update
    void Start()
    {
        mods = GetComponent<Mods>();
    }

    // Update is called once per frame
  

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            if (!mods.ModesChangeDamage())
            {
                lives--;
                Debug.Log(lives);

            }
        }
    }
}
