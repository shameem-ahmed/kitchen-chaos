using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            //there is no KitchenObject here
            
            if (player.HasKitchenObject())
            {
                //player is carrying something

                //give KitchenObject to this counter
                player.GetKitchenObject().SetKitchenObjectParent(this);
            }
            else
            {
                //player is not carrying anything
            }
        }
        else
        {
            //there is a KitchenObject here

            if (player.HasKitchenObject())
            {
                //player is carrying something
            }
            else
            {
                //player is not carrying anything
                GetKitchenObject().SetKitchenObjectParent(player);
            }

        }

    }

    public override void InteractAlternate(Player player)
    {
        Interact(player);
    }

}
