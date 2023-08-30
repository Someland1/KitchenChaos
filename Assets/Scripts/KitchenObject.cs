using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class KitchenObject : MonoBehaviour
{
    [SerializeField]
    private KitchenObjectSO kitchenObjectSO;

    private IKitchenObjectParent kitchenObjectPareenntt;

    public KitchenObjectSO GetKitchenObjectSO()
    {
        return kitchenObjectSO;
    }

    public void SetKitchenObjectParent(IKitchenObjectParent kitchenObjectParent)
    {
        if(this.kitchenObjectPareenntt != null)
        {
            this.kitchenObjectPareenntt.ClearKitchenObject();
        }

        this.kitchenObjectPareenntt = kitchenObjectParent;

        if(kitchenObjectParent.HasKitchenObject())
        {
            Debug.LogError("IKitchenObjectParent already has a KitchenObject!");
        }

        kitchenObjectParent.SetKitchenObject(this);
        
        transform.parent = kitchenObjectParent.GetKitchenObjectFollowTransform();
        transform.localPosition = Vector3.zero;
    }

    public IKitchenObjectParent GetKitchenObjectParent()
    {
        return kitchenObjectPareenntt;
    }

}
