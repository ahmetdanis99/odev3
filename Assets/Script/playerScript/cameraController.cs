using UnityEngine;
using Cinemachine;

public class cameraController : MonoBehaviour

{
    private CinemachineFreeLook cam;
    public float scrollSpeed = 5f;
    public float minRadius = 2f;
    public float maxRadius = 15f;


    void Start()
    {
        cam = GetComponent<CinemachineFreeLook>();
        if (cam != null)
        {
            OffDrag();
        }
    }
    void Update()
    {
        CamZoom(Input.GetAxis("Mouse ScrollWheel"));
        if (Input.GetMouseButton(0))
        {
            OnDrag();
        }
        else
        {
            OffDrag();
        }
    }

    void OnDrag()
    {
        cam.m_XAxis.m_InputAxisName = "Mouse X";
        cam.m_YAxis.m_InputAxisName = "Mouse Y";
    }

    void OffDrag()
    {
        cam.m_XAxis.m_InputAxisName = "";
        cam.m_YAxis.m_InputAxisName = "";
        cam.m_XAxis.m_InputAxisValue = 0f;
        cam.m_YAxis.m_InputAxisValue = 0f;
    }
    void CamZoom(float scrollValue)
    {
        //TODO: Küre oranlarını düzelt
        float newRadius = cam.m_Orbits[1].m_Radius - scrollValue * scrollSpeed;

        newRadius = Mathf.Clamp(newRadius, minRadius, maxRadius);

        cam.m_Orbits[1].m_Radius = newRadius;
        cam.m_Orbits[1].m_Height = newRadius;
        cam.m_Orbits[0].m_Height = newRadius * 2;

    }
}
