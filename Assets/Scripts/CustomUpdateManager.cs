using UnityEngine;
using System.Collections.Generic;

public class CustomUpdateManager : MonoBehaviour
{
   public static CustomUpdateManager Instance;
   //private IUpdate[] _list;
   private List<IUpdate> _updates;
   
   
   private void Awake()
   {
      GameObject[] objs =GameObject.FindGameObjectsWithTag("CustomUpdateManager");
      if (objs.Length > 1)
      {
         Destroy(this.gameObject);
      }
      if (Instance != null && Instance!=this)
      {
         Destroy(this);
      }
      else
      {
         Instance = this;    
      }
        
      DontDestroyOnLoad(this.gameObject);
   }
   
   private void Start()
   {
      //_updates = GetComponents<IUpdate>();
      _updates = new List<IUpdate>();
   }

   private void Update()
   {
      int count = _updates.Count;
      for (int i = 0; i < count; i++)
      {
         _updates[i].CustomUpdate();
      }
   }

   public void AddToList(IUpdate newUpdate)
   {
      _updates.Add(newUpdate);
   }
   public void RemoveFromUpdateList(IUpdate removeUpdate)
   {
      _updates.Remove(removeUpdate);
   }

}
