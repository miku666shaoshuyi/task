using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHearts : MonoBehaviour
{
    public int maxheart;
    public int heart;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void DamagePlayer(int damage)
    {
        heart -= damage;
        if (heart <= 0)
        {
            Destroy(gameObject);
        }
    }
}
