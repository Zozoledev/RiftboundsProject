using UnityEngine.InputSystem;
using UnityEngine;

public class RaycastMouse : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private GameObject selectedObject;
    private GameObject hand;
    void Start()
    {
        hand = GameObject.Find("Hand");

    }

 

    // Update is called once per frame
    void LateUpdate()
    {
        
        





        Vector2 mousePosition = Mouse.current.position.ReadValue();
        Debug.Log("Mouse Screen Position: " + mousePosition);
        

        Camera cam = Camera.main;

        Ray ray = cam.ScreenPointToRay(mousePosition);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
         
            //Debug.Log("Objet touché : " + hit.collider.gameObject.name);
            if(hit.collider.gameObject.name=="carte")
            {
                if (Mouse.current.leftButton.isPressed)
                {
                    //hit.collider.gameObject.transform.position = new Vector3(hit.point.x, hit.collider.gameObject.transform.position.y, hit.point.z);
                    selectedObject = hit.collider.gameObject;

                }
                else
                {
                    if(selectedObject != null)
                    {
                                            
                        if(mousePosition[1] < 170f)
                        {
                            selectedObject.transform.position = hand.transform.position;
                            selectedObject.transform.position = new Vector3(hand.transform.position.x, hand.transform.position.y + 10f, hand.transform.position.z);
                            //selectedObject.transform.SetParent(hand.transform);
                        }
                    }
                     selectedObject = null;
                }
            }

        }

        if(selectedObject != null)
        {
           

            if (mousePosition[1] < 170f) { 
                selectedObject.transform.position = hand.transform.position;
                selectedObject.transform.position = new Vector3(hand.transform.position.x, hand.transform.position.y + 10f, hand.transform.position.z);

            }
            else
            {
                selectedObject.transform.position = new Vector3(hit.point.x, 5, hit.point.z);

            }
                
                
        }

        

    }
}
