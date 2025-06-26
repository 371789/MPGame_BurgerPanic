using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ClearCounter : BaseCounter
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    public override void Interact(Player player)
    {
       if (!HasKitchenObject()) //если нет китчен объекта
        {
            if (player.HasKitchenObject())
            {
                // игрок что-то несет
                player.GetKitchenObject().SetKitchenObjectParent(this);
            }
            else
            {
                 // игрок ничего не несет
            }
        }
        else // если есть китчен объект
        {
            if (player.HasKitchenObject())
            {
                if (player.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject)) // держит тарелку
                {
                    if (plateKitchenObject.TryAddIngredient(GetKitchenObject().GetKitchenObjectSO()))
                    {
                        KitchenObject.DestroyKitchenObject(GetKitchenObject());
                    } 
                }
                else
                {
                    //несет не тарелку 
                    if (GetKitchenObject().TryGetPlate(out plateKitchenObject))
                    {
                       if (plateKitchenObject.TryAddIngredient(player.GetKitchenObject().GetKitchenObjectSO()))
                        {
                            KitchenObject.DestroyKitchenObject(player.GetKitchenObject());
                        }
                    }
                }
            }
            else
            {
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }
}
 