// using UnityEngine;

// public interface ICollectible
// {
//     string ItemName { get; }
//     void Collect(PlayerInventory inventory);
// }

// public class Coin : MonoBehaviour, ICollectible
// {
//     public string ItemName => "Coin";

//     public void Collect(PlayerInventory inventory)
//     {
//         Debug.Log("Picked up a Coin!");
//         inventory.AddItem(ItemName);
//         Destroy(gameObject);
//     }
// }

// public class Potion : MonoBehaviour, ICollectible
// {
//     public string ItemName => "Potion";

//     public void Collect(PlayerInventory inventory)
//     {
//         Debug.Log("Picked up a Potion!");
//         inventory.AddItem(ItemName);
//         Destroy(gameObject);
//     }
// }
