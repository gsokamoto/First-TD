using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 offset;

    private GameObject turret;

    private Renderer rend;
    private Color startColor;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    void OnMouseDown()
    {
        if(turret != null)
        {
            Debug.Log("Can't build there - TODO: Display on screen");
            return;
        }

        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position + offset, transform.rotation);
    }

    void OnMouseEnter()
    {
        //GetComponent<Renderer>().material.color = hoverColor; could do it like this instead, but less optimized
        rend.material.color = hoverColor;

    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
