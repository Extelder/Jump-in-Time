using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System.Threading.Tasks;

public class PlayerItem : MonoBehaviour
{
    public ReactiveProperty<InventoryItem> Current { get; private  set; } = new ReactiveProperty<InventoryItem>();
    public static ReactiveCommand CurrentItemDisActivated { get; private set; } = new ReactiveCommand();

    private CompositeDisposable _disposable = new CompositeDisposable();

    [SerializeField] private Transform _dropPlace;

    private void OnEnable()
    {
        Item.ItemPickuped += TakeItem;

        CurrentItemDisActivated.Subscribe(_ => 
        {
            Current.Value = null;
        }).AddTo(_disposable);
    }

    private void OnDisable()
    {
        Item.ItemPickuped -= TakeItem;
        _disposable.Dispose();
    }

    private void TakeItem(InventoryItem sceneReference)
    {
        if (!Current.Value)
        {
            ActivateNewItem(sceneReference);
            return;
        }
        DropCurrentItem();
        ActivateNewItem(sceneReference);
    }

    private void ActivateNewItem(InventoryItem inventoryItem)
    {
        Current.Value = inventoryItem;
        Current.Value.gameObject.SetActive(true);
    }

    public void DropCurrentItem()
    {
        if(Current.Value != null)
        {
            Current.Value.gameObject.SetActive(false);
            Instantiate(Current.Value.Prefab, _dropPlace.position, Quaternion.identity).GetComponent<Item>().GetComponent<Item>().ReferenceInScene = Current.Value;
            Current.Value = null;
        }
    }
}
