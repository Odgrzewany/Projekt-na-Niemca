using UnityEngine;

public class Bullet : MonoBehaviour {
    
    [Range(1,300)]
    public int bulletSpeed;




    void Start()
    {
    
        GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed, ForceMode.Impulse);
    }
}
