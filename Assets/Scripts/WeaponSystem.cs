using UnityEngine;

public class WeaponSystem : MonoBehaviour {


    public UnityEngine.UI.Text energyText;
    public GameObject energyBar;

    public PlayerController pc;

    public float actualEnergy;
    float maxEnergy;
    float lostEnergy;
    public Vector3 energyloosing;

    void Start () {
        maxEnergy = 100;
    
    }
	
	
	void Update () {

        if (actualEnergy > 0)
        {
            energyloosing = new Vector3(1.492624f - lostEnergy / 67.5f, 0.3068838f, 1);
        }

        lostEnergy = maxEnergy - actualEnergy;

        energyBar.transform.localScale = energyloosing;

        if (actualEnergy > 0 && Input.GetKey(KeyCode.LeftShift))
        {
            pc.movSpeed = 8;
            actualEnergy -= 8 * Time.deltaTime;
        }
        else
        {
            actualEnergy += Time.deltaTime;
            pc.movSpeed = 3;
        }

        if (actualEnergy > maxEnergy)
        {
            actualEnergy = maxEnergy;
        }
        if (actualEnergy < 0)
        {
            actualEnergy = 0;
        }

        energyText.text = "Enregy: " + actualEnergy.ToString("00");
    }
}
