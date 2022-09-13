using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{

    [SerializeField] private float defDistanceRay = 100;
    public Transform laserFirePoint;
    public LineRenderer _lineRender;
    Transform _transform;


    private void Awake()
    {
        _transform = GetComponent<Transform>();
    }


    private void Update()
    {
        ShootLaser();   
    }

    void ShootLaser()
    {
        if (Physics2D.Raycast(_transform.position, transform.right))
        {
            RaycastHit2D _hit = Physics2D.Raycast(_transform.position, transform.right);
            Draw2DRay(laserFirePoint.position, _hit.point);
        }
        else
        {
            Draw2DRay(laserFirePoint.position, laserFirePoint.transform.right * defDistanceRay);
        }
    }

    void Draw2DRay(Vector2 startPos, Vector2 endPos)
    {
        _lineRender.SetPosition(0, startPos);
        _lineRender.SetPosition(1, endPos);
    }

}
