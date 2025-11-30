using UnityEngine;
using System.Collections;
using DG.Tweening;
using TinyAdventure;
using tiny_adventure;

public interface IInteractable
{
    public void StartInteraction();
    public void FinishInteraction();
}

public class PlayerAction : MonoBehaviour
{
    public GameObject weapon;

    public float attackCooldown;
    public float attackSpeed = 0.2f;
    public bool canAttack = true;

    private IInteractable currentInteractable;

    public void DoAction(Vector2 _movingDirection)
    {
        if (!canAttack) return;
        weapon.gameObject.SetActive(true);

        if (_movingDirection.x > 0)
        {
            SwingAttack(0, -180);
            weapon.transform.localPosition = new Vector2(0.3f, 0);
        }
        else if (_movingDirection.x < 0)
        {
            SwingAttack(0, 180);
            weapon.transform.localPosition = new Vector2(-0.3f, 0);
        }
        else if (_movingDirection.y > 0)
        {
            SwingAttack(90, -90);
            weapon.transform.localPosition = new Vector2(0, 0.3f);
        }
        else if (_movingDirection.y < 0)
        {
            SwingAttack(-90, -270);
            weapon.transform.localPosition = new Vector2(0, -0.3f);
        }
        else
        {
            Debug.LogWarning("Direção de ataque indefinida: " + _movingDirection);
        }

        StartCoroutine(CooldownRoutine());
    }

    void SwingAttack(int _startAngle, int _finalAngle)
    {
        GetComponentInParent<PlayerSounds>().PlaySword();

        weapon.transform.rotation = Quaternion.Euler(0, 0, _startAngle);

        weapon.transform.DORotate(new Vector3(0, 0, _finalAngle), attackSpeed, RotateMode.Fast)
            .OnComplete(() => weapon.gameObject.SetActive(false));
    }

    IEnumerator CooldownRoutine()
    {
        canAttack = false;
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }

    IEnumerator DisableRoutine()
    {
        yield return new WaitForSeconds(0.25f);
        gameObject.SetActive(false);
    }

    void Start()
    {
        gameObject.SetActive(false);
    }

    public void StartInteraction(Vector2 _movingDirection)
    {
        gameObject.SetActive(true);
        StartCoroutine(DisableRoutine());

        if (_movingDirection.x > 0)
            transform.localPosition = new Vector2(0.3f, 0);
        else if (_movingDirection.x < 0)
            transform.localPosition = new Vector2(-0.3f, 0);
        else if (_movingDirection.y > 0)
            transform.localPosition = new Vector2(0, 0.3f);
        else if (_movingDirection.y < 0)
            transform.localPosition = new Vector2(0, -0.3f);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Interaction"))
        {
            // Collectable mushrooms
            if (collision.CompareTag("Mushroom"))
            {
                DataManager.CollectMushroom();
                collision.gameObject.SetActive(false);

                PlayerSounds sounds = GetComponentInParent<PlayerSounds>();
                sounds?.PlayCollect();
            }

            // NPC interaction
            if (collision.CompareTag("Sage") || collision.CompareTag("Inn"))
            {
                currentInteractable = collision.GetComponent<IInteractable>();

                // Just registers the NPC.
                // Interaction will happen when pressing E.
            }
        }
        else
        {
            // Attack hits something
            DoAction(GetComponentInParent<PlayerInput>().lastDirection);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Sage") || collision.CompareTag("Inn"))
        {
            if (currentInteractable != null &&
                currentInteractable == collision.GetComponent<IInteractable>())
            {
                currentInteractable = null;
            }
        }
    }

    void Update()
    {
        // If in range of NPC AND dialogue is closed -> attempt interaction
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (DialogueSystem.Instance.DialogueIsOpen)
            {
                DialogueSystem.Instance.NextLine();
                return;
            }

            currentInteractable?.StartInteraction();
        }
    }
}
