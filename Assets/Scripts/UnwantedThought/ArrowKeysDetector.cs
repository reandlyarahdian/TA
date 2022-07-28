using Assets.Scripts;
using UnityEngine;

public class ArrowKeysDetector : MonoBehaviour, IInputDetector
{
    public InputDirection? DetectInputDirection()
    {
        if (Input.GetKeyUp(KeyCode.W))
            return InputDirection.Top;
        else if (Input.GetKeyUp(KeyCode.S))
            return InputDirection.Bottom;
        else if (Input.GetKeyUp(KeyCode.D))
            return InputDirection.Right;
        else if (Input.GetKeyUp(KeyCode.A))
            return InputDirection.Left;
        else
            return null;
    }
}