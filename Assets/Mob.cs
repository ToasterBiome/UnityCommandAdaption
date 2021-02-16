using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour, IMoveable
{
    public Animator animator;
    public string currentState;

    public float moveSpeed = 1f;

    public bool isMoving = false;

    public Stack<Command> pastCommands = new Stack<Command>();

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W) && !isMoving)
        {
            Command moveCommand = new MoveUpCommand();
            moveCommand.Execute(this);
            pastCommands.Push(moveCommand);
        }
        if (Input.GetKeyDown(KeyCode.A) && !isMoving)
        {
            Command moveCommand = new MoveLeftCommand();
            moveCommand.Execute(this);
            pastCommands.Push(moveCommand);
        }
        if (Input.GetKeyDown(KeyCode.S) && !isMoving)
        {
            Command moveCommand = new MoveDownCommand();
            moveCommand.Execute(this);
            pastCommands.Push(moveCommand);
        }
        if (Input.GetKeyDown(KeyCode.D) && !isMoving)
        {
            Command moveCommand = new MoveRightCommand();
            moveCommand.Execute(this);
            pastCommands.Push(moveCommand);
        }

        //undo command
        if (Input.GetKeyDown(KeyCode.U) && !isMoving)
        {
            if(pastCommands.Count == 0)
            {
                Debug.Log("Nothing left to undo!");
                return;
            }
            //get the last command
            Command previousCommand = pastCommands.Pop();

            Command moveCommand = null;

            if(previousCommand.GetType() == typeof(MoveDownCommand))
            {
                moveCommand = new MoveUpCommand();
            }
            if (previousCommand.GetType() == typeof(MoveUpCommand))
            {
                moveCommand = new MoveDownCommand();
            }
            if (previousCommand.GetType() == typeof(MoveLeftCommand))
            {
                moveCommand = new MoveRightCommand();
            }
            if (previousCommand.GetType() == typeof(MoveRightCommand))
            {
                moveCommand = new MoveLeftCommand();
                
            }

            //do the opposite me thinks

            if (moveCommand != null)
            {
                moveCommand.Execute(this);
            }
            
        }
    }

    private IEnumerator MoveToTile(Vector2 position)
    {
        ChangeAnimationState("Move");
        isMoving = true;
        while(Vector2.Distance(transform.position,position) > 0.01f)
        {
            transform.position = (Vector2)transform.position + (position - (Vector2)transform.position).normalized * moveSpeed * Time.deltaTime;

            yield return new WaitForEndOfFrame();
        }

        
        transform.position = position;
        isMoving = false;
        ChangeAnimationState("Idle");
        yield break;
    }

    void ChangeAnimationState(string newState)
    {
        if(currentState == newState)
        {
            return;
        }

        animator.Play(newState);

        currentState = newState;
    }

    public void MoveRight()
    {
        StartCoroutine(MoveToTile(transform.position + new Vector3(1, 0)));
    }

    public void MoveLeft()
    {
        StartCoroutine(MoveToTile(transform.position + new Vector3(-1, 0)));
    }

    public void MoveUp()
    {
        StartCoroutine(MoveToTile(transform.position + new Vector3(0, 1)));
    }

    public void MoveDown()
    {
        StartCoroutine(MoveToTile(transform.position + new Vector3(0, -1)));
    }
}
