using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StoreKey : MonoBehaviour
{
    public TextMeshProUGUI keyCounter;
    public int keyCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        keyCounter.text = keyCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddKey()
    {
        keyCount++;
        keyCounter.text = keyCount.ToString();
    }
    
}
