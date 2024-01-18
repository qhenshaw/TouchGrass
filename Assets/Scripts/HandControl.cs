using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class HandControl : MonoBehaviour
{
    [SerializeField] private float _lerpSpeed = 5f;
    [SerializeField] private VisualEffect _vfxTrail;
    [SerializeField] private Vector2 _height = new Vector2(0.25f, 0.75f);

    private Vector3 _position = new Vector3(5f, 1f, 5f);

    private void Start()
    {
        Cursor.visible = false;
    }

    private void Update()
    {
        Ray mouseRay = Camera.main.ScreenPointToRay( Input.mousePosition );
        Plane plane = new Plane(Vector3.up, Vector3.zero);
        if(plane.Raycast(mouseRay, out float distance))
        {
            Vector3 point = mouseRay.GetPoint(distance);
            Vector3 offset = Input.GetMouseButton(0) ? new Vector3(0f, _height.x, 0f) : new Vector3(0f, _height.y, 0f);
            _position = point + offset;
        }

        transform.position = Vector3.Lerp(transform.position, _position, _lerpSpeed * Time.deltaTime);
        _vfxTrail.SetFloat("Strength", 1f - Mathf.InverseLerp(_height.x, _height.y, transform.position.y));
    }
}