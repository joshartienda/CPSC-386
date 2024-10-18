using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int coinCount;
    public Text coinText;
    public Text TotalCoinsCollected;
    public GameObject door;
    private bool doorDestroyed;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = "Coins: " + coinCount.ToString();

        if (coinCount == 6 && !doorDestroyed)
        {
            doorDestroyed = true;
            Destroy(door);
            FindObjectOfType<AudioManager>().Play("DoorOpen");
        }
    }
}
