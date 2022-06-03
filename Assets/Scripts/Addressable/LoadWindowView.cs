using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;


public class LoadWindowView : MonoBehaviour
{
    [SerializeField]
    private AssetReference _loadPrefab;
    [SerializeField]
    private RectTransform _mountSpawnTransform;
    [SerializeField]
    private Button _loadAsssetsButton;
    [SerializeField]
    private Button _spawnAssetsButton;
    private List<AsyncOperationHandle<GameObject>> _addressablePrefabs = new List<AsyncOperationHandle<GameObject>>();
    private void Start()
    {
        _spawnAssetsButton.onClick.AddListener(CreateAddressablesPrefab);
    }
    private void OnDestroy()
    {
        _loadAsssetsButton.onClick.RemoveAllListeners();
        foreach (var addressablePrefab in _addressablePrefabs)
            Addressables.ReleaseInstance(addressablePrefab);
        _addressablePrefabs.Clear();
    }

    private async void CreateAddressablesPrefab()
    {
        var addressablePrefab = await Addressables.InstantiateAsync(_loadPrefab, _mountSpawnTransform).Task;
        if (addressablePrefab != null)
        {
            //_addressablePrefabs.Add(addressablePrefab);
            addressablePrefab.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right);
        }





    }
}

