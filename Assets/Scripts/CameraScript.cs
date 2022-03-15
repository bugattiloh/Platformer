using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

    public float damping = 1f;
    public Vector2 offset = new Vector2(2f, 1f);
    public bool faceLeft;
    private Transform _player;
    private int _lastX;

    void Start ()
    {
        offset = new Vector2(Mathf.Abs(offset.x), offset.y);
        FindPlayer(faceLeft);
    }

    private void FindPlayer(bool playerFaceLeft)
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _lastX = Mathf.RoundToInt(_player.position.x);
        if(playerFaceLeft)
        {
            var position = _player.position;
            transform.position = new Vector3(position.x - offset.x, position.y + offset.y, transform.position.z);
        }
        else
        {
            var position = _player.position;
            transform.position = new Vector3(position.x + offset.x, position.y + offset.y, transform.position.z);
        }
    }

    void Update () 
    {
        if(_player)
        {
            int currentX = Mathf.RoundToInt(_player.position.x);
            if(currentX > _lastX) faceLeft = false; else if(currentX < _lastX) faceLeft = true;
            _lastX = Mathf.RoundToInt(_player.position.x);

            Vector3 target;
            if(faceLeft)
            {
                var position = _player.position;
                target = new Vector3(position.x - offset.x, position.y + offset.y, transform.position.z);
            }
            else
            {
                var position = _player.position;
                target = new Vector3(position.x + offset.x, position.y + offset.y, transform.position.z);
            }
            Vector3 currentPosition = Vector3.Lerp(transform.position, target, damping * Time.deltaTime);
            transform.position = currentPosition;
        }
    }
}