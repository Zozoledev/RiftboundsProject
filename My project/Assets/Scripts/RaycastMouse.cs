using UnityEngine.InputSystem;
using UnityEngine;

public class RaycastMouse : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private GameObject selectedObject;
    private GameObject placement;

    private bool showcard = false;
    private Vector3 lastcoordinate;
    void Start()
    {
        placement = GameObject.Find("Placement");

    }

 

    // Update is called once per frame
    void Update()
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
                if (Mouse.current.leftButton.isPressed && !showcard)
                {
                    //hit.collider.gameObject.transform.position = new Vector3(hit.point.x, hit.collider.gameObject.transform.position.y, hit.point.z);
                    selectedObject = hit.collider.gameObject;

                }
                else
                {
                    /*if(selectedObject != null)
                    {
                                            
                        if(mousePosition[1] < 170f)
                        {
                            selectedObject.transform.position = hand.transform.position;
                            selectedObject.transform.position = new Vector3(hand.transform.position.x, hand.transform.position.y + 10f, hand.transform.position.z);
                            //selectedObject.transform.SetParent(hand.transform);
                        }
                    }*/
                     selectedObject = null;
                }

                if(Mouse.current.rightButton.wasPressedThisFrame)
                {
                    showcard = !showcard;
                    if (showcard)
                    {
                        lastcoordinate = hit.collider.gameObject.transform.position;
                        hit.collider.gameObject.transform.position = new Vector3(0f, 101f, 0f);
                    }
                    else
                    {
                        hit.collider.gameObject.transform.position = lastcoordinate;
                    }
                }
            }

        }

        if(selectedObject != null && !showcard)
        {


            /*if (mousePosition[1] < 170f) { 
                selectedObject.transform.position = hand.transform.position;
                selectedObject.transform.position = new Vector3(hand.transform.position.x, hand.transform.position.y + 10f, hand.transform.position.z);

            }
            else
            {
                selectedObject.transform.position = new Vector3(hit.point.x, 5, hit.point.z);

            }*/

            float max = 999f;
            foreach(Transform enfant in placement.transform)
            {
                Vector2 xz = new Vector2(enfant.position.x, enfant.position.z);
                Vector2 mousePositiontest = new Vector2(hit.point.x, hit.point.z);

                float distance = Vector3.Distance(xz, mousePositiontest);
                if(distance < max)
                {
                    max = distance;
                    selectedObject.transform.position = new Vector3(enfant.position.x, enfant.position.y + 5f, enfant.position.z);
                }


            }

        }

        

    }
}
