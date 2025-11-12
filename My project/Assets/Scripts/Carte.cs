using UnityEngine;

public class Carte : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    private Plane dragPlane;

    public void OnMouseDown()
    {
        // Crée un plan horizontal (X, Z) sur la position actuelle de la carte
        dragPlane = new Plane(Vector3.up, transform.position);

        // Calcul de l'offset entre le point cliqué et la position de la carte
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        float planeDist;
        if (dragPlane.Raycast(camRay, out planeDist))
        {
            offset = transform.position - camRay.GetPoint(planeDist);
        }

        isDragging = true;
    }

    public void OnMouseUp()
    {
        isDragging = false;
    }

    public void Update()
    {
        if (isDragging)
        {
            Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            float planeDist;
            if (dragPlane.Raycast(camRay, out planeDist))
            {
                Vector3 point = camRay.GetPoint(planeDist);
                // On déplace la carte en x et z (garde y fixe)
                transform.position = new Vector3(point.x + offset.x, transform.position.y, point.z + offset.z);
            }
        }
    }
}
