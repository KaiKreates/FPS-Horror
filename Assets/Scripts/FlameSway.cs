using UnityEngine;
using UnityEngine.VFX;

public class FlameSway : MonoBehaviour
{
    [SerializeField] private Vector3 SwayVectorA;
    [SerializeField] private Vector3 SwayVectorB;

    [SerializeField]
    private VisualEffect vfx;

    void Update()
    {
        SwayVectorA = vfx.GetVector3("SwayVelocityA");
        SwayVectorB = vfx.GetVector3("SwayVelocityB");

        switch(Mathf.Abs(Input.GetAxis("Mouse X")))
        {
            case 0:
                SwayVectorA.x = -0.1f;
                SwayVectorB.x = 0.1f;
                break;
            case <=0.4f:
                SwayVectorA.x = -Input.GetAxis("Mouse X");
                SwayVectorB.x = -Input.GetAxis("Mouse X") + 0.2f;
                break;
            case > 0.4f:
                SwayVectorA.x = Mathf.Sign(Input.GetAxis("Mouse X")) * -0.4f;
                SwayVectorB.x = Mathf.Sign(Input.GetAxis("Mouse X")) * -0.45f;
                break;
        }

        vfx.SetVector3("SwayVelocityA", SwayVectorA);
        vfx.SetVector3("SwayVelocityB", SwayVectorB);
    }
}