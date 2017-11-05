using UnityEngine;

public class PlayerShooting : MonoBehaviour {

    public Animator shootingAnimator;

   

    public bool fire;

    public GameObject bullet;
    public Transform bulletResp;


    int maxAmmo = 30;
    public int actualAmmo;

    public float shootingSpeed;
    public float timer;
    public bool czyStrzelono;
    public bool czyLiczyc;
    
    void Start () {
        czyLiczyc = true;
  

    }
	
	
	void Update () {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (actualAmmo > 0)
            {
                fire = true;
                Ak47Shooting();
                
            }
            else
            {
                fire = false;
                
            }
        }
        else
        {
            fire = false;
           
        }
       

        shootingAnimator.SetBool("IsShooting", fire);

        if(actualAmmo > maxAmmo)
        {
            actualAmmo = maxAmmo;
        }
        if(actualAmmo < 0)
        {
            actualAmmo = 0;
        }
        if(timer > 0)
        {
            timer -= Time.deltaTime;
            czyLiczyc = false;
        }
        if(timer <= 0)
        {
            timer = 0;
        }
        if(timer == 0)
        {
            czyStrzelono = false;
            czyLiczyc = true;
        }
	}


    void Ak47Shooting()
    {
        if(czyLiczyc == true)
        {
            timer = shootingSpeed;
            Debug.Log("liczyć = true");
        }
        
        if (czyStrzelono == false && czyLiczyc == true)
        {
            Debug.Log("Strzał");
            czyStrzelono = true;
            GameObject bullet1 =  Instantiate(bullet, bulletResp.position, bulletResp.rotation);
            actualAmmo -= 1;
            
        }
    }



    
}
