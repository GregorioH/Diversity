using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomProps : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        switch (Random.Range(0, 3))
        {
            case 0:
                Instantiate(Resources.Load<GameObject>("Props/" + "Barril"), gameObject.transform.position, gameObject.transform.rotation);
                break;
            case 1:
                Instantiate(Resources.Load<GameObject>("Props/" + "Mesa"), gameObject.transform.position, gameObject.transform.rotation);
                break;
            case 2:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
