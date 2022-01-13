using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smoothCamera : Singleton<smoothCamera>
{
    public Transform Player;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    public string levelName;

    private Vector3 startPos;
    private Quaternion startRot;
    
    private void Start()
    {
        startPos = transform.position;
        startRot = transform.rotation;
        //levelName = LevelMatrixHolder.Instance.levels[0].prefabObj0.tag;    //we can use this tag to make camera behave different for different presets which are determined by prefab tags
        SetPlayer(Player);
    }

    public void SetPlayer(Transform pTransform)
    {
        transform.position = startPos;
        transform.rotation = startRot;

        offset = this.transform.position - pTransform.position;
    }
    
    void LateUpdate()
    {
        if (Player == null)
        {
            return;
        }
        
        Vector3 desiredPosition = Player.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(this.transform.position, desiredPosition, smoothSpeed);
        this.transform.position = smoothPosition;
    }
}
