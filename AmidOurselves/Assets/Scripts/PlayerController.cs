using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Reference to rigidbody, needed to make 3d force based movement, cannot initialize here as it doesn't exist yet
    private Rigidbody rb;
    private float grounded = 1f;

    //editable in unity editor, will be under the player controller script, all public variables are visible in editor.
    public float jumpPower = 0.0f;

    //they also have sliders which are neat
    [Range(0.0f, 10.0f)]
    public float speedSlider;

    //you can plug in more abstract things, like other game objects too
    public GameObject playerCamera;

    // Start is called before the first frame update
    void Start()
    {

        //Reference to rigidbody once initialized
        rb = GetComponent<Rigidbody>();

    }

    Vector3 movement;

    // Update is called once per frame
    void Update()
    {
        /*
         * TODO ///
         * 
         * Fix movement so that forces are local to camera perspective, not world absolute
         * 
         * add grounded check, orbital jumping is neat until you fly off the map
         * 
         * Cap speed and play with rb properties to feel like in game speed
         * 
         */



        //Get movement vector from default inputs (Edit > Project > Inputs)
        Vector3 characterForward = transform.forward * Input.GetAxis("Vertical");
        Vector3 characterRight = transform.right * Input.GetAxis("Horizontal");
        Vector3 characterUp = transform.up * Input.GetAxis("Jump") * jumpPower * grounded;
        movement = characterForward + characterRight + characterUp;
        Debug.Log(movement.ToString());
        rb.AddForce(movement);

        //Set transform rotation per frame updated by mouse axis x, note, rotating around y axis translates to world horizontal scan
        transform.Rotate(new Vector3(0f, Input.GetAxis("Mouse X"), 0f));

        //Set Camera rotation about x axis
        float mouseY = -Input.GetAxis("Mouse Y");
        float newRotation = Mathf.Clamp(playerCamera.transform.rotation.x + mouseY, -89f, 89f);
        playerCamera.transform.Rotate(new Vector3(mouseY, 0f, 0f));
    }
}
