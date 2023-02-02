using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : BaseCounter
{
    [SerializeField] private CuttingRecipeSO[] cuttingRecipeSOArray ;

    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            //there is no KitchenObject here

            if (player.HasKitchenObject())
            {
                //player is carrying something

                if (HasRecipeWithInput(player.GetKitchenObject().GetKitchenObjectSO()))
                {
                    //player is carrying something that can be cut

                    //give KitchenObject to this counter
                    player.GetKitchenObject().SetKitchenObjectParent(this);
                }
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
        if (HasKitchenObject())
        {
            //there is no KitchenObject here
            KitchenObjectSO output = GetOutputForInput(GetKitchenObject().GetKitchenObjectSO());
            GetKitchenObject().DestroySelf();
            KitchenObject.SpawnKitchenObject(output, this);
        }
        else
        {
            //there is a KitchenObject here
        }
    }

    private bool HasRecipeWithInput(KitchenObjectSO input)
    {
        foreach (var item in cuttingRecipeSOArray)
        {
            if (item.input == input)
            {
                return true;
            }
        }
        return false;
    }

    private KitchenObjectSO GetOutputForInput(KitchenObjectSO input)
    {
        foreach (var item in cuttingRecipeSOArray)
        {
            if (item.input == input)
            {
                return item.output;
            }
        }
        return null;
    }
}
