using UnityEngine;

public class PlayerResourcesCollector : MonoBehaviour
{
    private int money = 0;
    private int meat = 0;
    private int wood = 0;




    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("MoneyBag"))
        {
            Destroy(collision.gameObject);
            money++;
            UIManager.Instance.UpdateMoney(money);
        }
        if (collision.gameObject.CompareTag("Meat"))
        {
            Destroy(collision.gameObject);
            meat++;
            UIManager.Instance.UpdateMeat(meat);
        }
        if (collision.gameObject.CompareTag("Wood"))
        {
            Destroy(collision.gameObject);
            wood++;
            UIManager.Instance.UpdateWood(wood);
        }
    }
}
