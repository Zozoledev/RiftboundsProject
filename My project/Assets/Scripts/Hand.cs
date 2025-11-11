using UnityEngine;

public class Hand : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Vector3 screenposition = new Vector3(Screen.width / 2, 50, 10);
        Vector3 worldposition = Camera.main.ScreenToWorldPoint(screenposition);
        gameObject.transform.position = worldposition; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
