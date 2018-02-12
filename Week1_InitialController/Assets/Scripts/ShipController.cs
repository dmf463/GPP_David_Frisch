using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour {

    public float speed;
    public KeyCode upKey = KeyCode.W;
    public KeyCode downKey = KeyCode.S;
    public KeyCode leftKey = KeyCode.A;
    public KeyCode rightKey = KeyCode.D;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //move stuff
        Move(Vector3.up, upKey);
        Move(Vector3.down, downKey);
        Move(Vector3.left, leftKey);
        Move(Vector3.right, rightKey);

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 modPos;
            if (GetComponent<SpriteRenderer>().flipX == true || mousePos.x < transform.position.x) modPos = Vector3.left;
            else modPos = Vector3.right;
            GetComponent<BasicGun>().Fire(mousePos, modPos);
            StartCoroutine(PowerUp(1));
        }

    }

    void Move(Vector3 dir, KeyCode key)
    {
        if (Input.GetKey(key))
        {
            if (key == leftKey) GetComponent<SpriteRenderer>().flipX = true;
            else if (key == rightKey) GetComponent<SpriteRenderer>().flipX = false;
            transform.Translate(dir * speed * Time.deltaTime);
        }
    }

    IEnumerator PowerUp(float time)
    {
        yield return new WaitForSeconds(1);
        Services.EventManager.Fire(new PlayerPoweredUp(gameObject));
        Debug.Log("firing");
    }
}
