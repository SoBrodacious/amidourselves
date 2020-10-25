using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Reference to rigidbody, needed to make 3d force based movement, cannot initialize here as it doesn't exist yet
    private Rigidbody rb;

    //editable in unity editor, will be under the player controller script, all public variables are visible in editor.
    public float jumpPower = 0.0f;

    //they also have sliders which are neat
    [Range(0.0f, 10.0f)]
    public float speedSlider;

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
        movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Jump") * jumpPower, Input.GetAxis("Vertical"));
        rb.AddForce(movement);

        //Set transform rotation per frame updated by mouse axis x, note, rotating around y axis translates to world horizontal scan
        transform.Rotate(new Vector3(0f, Input.GetAxis("Mouse X"), 0f));
    }
}
