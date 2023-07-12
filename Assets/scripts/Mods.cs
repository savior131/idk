using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Mods : MonoBehaviour
{

    public enum marioModes { Default, Small, White, Super };
    public marioModes currentMode;
    SpriteRenderer sprite;
    Movement movement;
    float tempSpeed;
    float tempJumpForce;
    Vector2 defaultScale;
    // Start is called before the first frame update
    void Start()
    {
        currentMode = marioModes.Default;
        sprite = GetComponent<SpriteRenderer>();
        movement = GetComponent<Movement>();
        defaultScale = transform.localScale;
        tempSpeed = movement.moveSpeed;
        tempJumpForce = movement.jumpForce;
    }
    private void Update()
    {
        ModesBehavior();
    }
    // Update is called once per frame
    public bool ModesChangeDamage()
    {
        if (currentMode == marioModes.Super)
        {
            currentMode = marioModes.Default;
            return true;
        }
        else if (currentMode == marioModes.White)
        {
            currentMode = marioModes.Default;
            return true;
        }
        else if (currentMode == marioModes.Default)
        {
            currentMode = marioModes.Small;
            return true;
        }
        else
        {
            return false;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Mushroom"))
        {
            currentMode = marioModes.Default;
        }
        if (collision.gameObject.CompareTag("Flower"))
        {
            currentMode = marioModes.White;
        }
        if (collision.gameObject.CompareTag("Star"))
        {
            currentMode = marioModes.Super;
        }
    }
    void ModesBehavior()
    {
        if (currentMode == marioModes.White)
        {
            extend();
            sprite.color = Color.red;
        }
        if (currentMode == marioModes.Super)
        {
            extend();
            StartCoroutine(SuperMode());
        }
        if (currentMode == marioModes.Default)
        {
            extend();
            sprite.color = Color.white;
        }
        if (currentMode == marioModes.Small)
        {
            shrink();
            sprite.color = Color.gray;
        }
    }
    IEnumerator SuperMode()
    {
        movement.moveSpeed = tempSpeed + tempSpeed * 0.7f;
        sprite.color = Color.yellow;
        yield return new WaitForSeconds(5f);
        movement.moveSpeed = tempSpeed;
        currentMode = marioModes.Default;
    }
    void shrink()
    {
        movement.jumpForce = tempJumpForce - tempJumpForce * 0.3f;
        transform.localScale = new Vector2(Mathf.Lerp(defaultScale.x, defaultScale.x * 0.5f, 1f), Mathf.Lerp(defaultScale.y,defaultScale.y*0.5f,1f));
    }
    void extend()
    {
        movement.jumpForce = tempJumpForce;
        transform.localScale = new Vector2(Mathf.Lerp(defaultScale.x * 0.5f, defaultScale.x, 1f), Mathf.Lerp(defaultScale.y * 0.5f, defaultScale.y, 1f));
    }
}
