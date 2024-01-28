using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public enum Sticker
{
    NONE = -1,
    SQUARE = 0,
    CIRCLE = 1,
    TRIANGLE = 2,
    STAR = 3,
}

public class PackageSystem : MonoBehaviour
{
    public int numberOfPackages = 5;
    public int numberOfErrors = 3;
    public List<Sprite> packageImages;
    public List<Sprite> correctImages;
    public GameObject package;
    public int packageOffset = 1200;
    public float packageSpeed;
    public Sticker stickerToFind;
    
    private Vector3 _packageStart;
    private float _packageXEnd;
    private bool _canInteract = false;
    private int _round = 0;
    private int _errors = 0;
    
    Sticker RandomSticker()
    {
        return (Sticker) UnityEngine.Random.Range(0, Enum.GetNames(typeof(Sticker)).Length - 1);
    }
    
    void GeneratePackage()
    {
        stickerToFind = RandomSticker();
        package.GetComponent<Image>().sprite = packageImages[(int) stickerToFind];
        package.transform.position = _packageStart;
        _canInteract = true;
    }
    
    public void CheckPackage(int sticker)
    {
        if (!_canInteract) return;
        if ((Sticker) sticker == stickerToFind) {
            _round++;
            package.GetComponent<Image>().sprite = correctImages[(int) stickerToFind];
            if (_round >= numberOfPackages) {
                _round = 0;
                _errors = 0;
                gameObject.SetActive(false);
            }
        } else {
            _errors++;
            if (_errors >= numberOfErrors) {
                _round = 0;
                _errors = 0;
            }
        }
        _canInteract = false;
    }

    private void Start()
    {
        _packageStart = package.transform.position;
        _packageXEnd = _packageStart.x + packageOffset;
    }

    private void Update()
    {
        if (!_canInteract) {
            GeneratePackage();
        } else {
            package.transform.position = new Vector3(package.transform.position.x + packageSpeed * Time.deltaTime, package.transform.position.y, package.transform.position.z);
            if (package.transform.position.x >= _packageXEnd) {
                _errors++;
                if (_errors >= numberOfErrors) {
                    _round = 0;
                    _errors = 0;
                }
                _canInteract = false;
            }
        }
    }
}
