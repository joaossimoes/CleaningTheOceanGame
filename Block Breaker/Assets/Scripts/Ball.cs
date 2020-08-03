using UnityEngine;

public class Ball : MonoBehaviour
{
    //configuration paramaters
    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;
    [SerializeField] AudioClip[] ballSounds;
    public Vector2 ballSpeed;
    //[SerializeField] float randomFactor = 0.2f;

    //state
    Vector2 paddleToBallVector;
    public bool hasStarted = false;
    

    //Cached component references
    AudioSource myAudioSource;
    Rigidbody2D myRigidBody2D;

    
    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myRigidBody2D = GetComponent<Rigidbody2D>();
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        ballSpeed = myRigidBody2D.velocity;
        if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
        //Debug.Log(myRigidBody2D.velocity.magnitude);
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            myRigidBody2D.velocity = new Vector2(xPush, yPush + (PlayerPrefsController.GetDifficulty() * 2));
            Cursor.visible = false;
        }
        
    }

    public void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Vector2 velocityTweak = new Vector2(Random.Range(0f,randomFactor), Random.Range(0f,randomFactor)); 
        if (hasStarted)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(clip, PlayerPrefsController.GetVolume());
            //myRigidBody2D.velocity += velocityTweak;
        }
        
    }

    public Vector2 GetBallSpeed()
    {
        return ballSpeed;
    }

    public void ResetBall()
    {
        hasStarted = false;
    }
}
