using System.IO;
using UnityEngine;

namespace Assets.Scripts
{
    public class CollectItem : MonoBehaviour
    {
        public Material GlowMaterial;

        private Inventory _inventory;

        private GameObject _lastItem;

        private Material _lastMaterial;

        public Camera Camera;

        void Start()
        {
            _inventory = GetComponent<Inventory>();
        }

        // Update is called once per frame
        void Update ()
        {
            RaycastHit hitInfo;
            var ray = new Ray(Camera.transform.position, Camera.transform.forward);
            if (Physics.Raycast(ray, out hitInfo, 10f, 1 << LayerMask.NameToLayer("Item")))
            {
                if (hitInfo.collider.tag == "Item")
                {
                    var item = hitInfo.collider.gameObject;
                    Debug.Log(item);
                //    if (item != _lastItem)
                  //  {
                        //_lastItem.GetComponent<MeshRenderer>().material = _lastMaterial;
                        //_lastMaterial = item.GetComponent<MeshRenderer>().material.;
                        //item.GetComponent<MeshRenderer>().material = GlowMaterial;
                    //    if (_lastItem != null)
                      //  {
                        //    _lastItem.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", Color.black);
                        //}
                        //item.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", Color.white);
                        //_lastItem = item;
                    //}
                    if(Input.GetKeyDown(KeyCode.E))
                    {
                        _inventory.AddItem(item.GetComponent<ShopItem>().ShopItemData);
                        Destroy(item);
                    }
                    return;
                }
            }
            //if (_lastItem != null)
            //{
                //_lastItem.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", Color.black);
              //  _lastItem = null;
            //}

        }
        
        void OnGUI() 
        {
            
        }
    }
}
