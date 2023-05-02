using UnityEngine;
public class node : MonoBehaviour
{
    public Color hoverColor;
    public Color notEnoughMoneyColor;
    public Vector3 positionOffset;
    public GameObject turret;
    private Renderer rend;
    private Color startColor;
    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }
    void OnMouseDown()
    {
        if (turret != null)
        {
            Debug.Log("Can not build here!!");
            return;
        }
        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset,
       transform.rotation);
    }
    void OnMouseEnter()
    {
        rend.material.color = notEnoughMoneyColor;
    }
    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}