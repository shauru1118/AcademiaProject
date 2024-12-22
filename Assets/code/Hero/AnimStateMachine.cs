using UnityEngine;

public class AnimStateMachine : MonoBehaviour
{
    public bool isRun;
    public bool isWalk;
    public bool isIdle;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
