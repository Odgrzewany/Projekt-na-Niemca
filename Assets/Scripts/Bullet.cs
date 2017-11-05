using UnityEngine;

public class Bullet : MonoBehaviour {
    
    [Range(1,300)]
    public int bulletSpeed;




    void Start()
    {
        //transform.Translate(new Vector3(0,0,bulletSpeed * Time.deltaTime));
        GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed, ForceMode.Impulse);
    }
}
