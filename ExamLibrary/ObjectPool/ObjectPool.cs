using System;

namespace ObjectPool
{
    /// <summary>
    /// Abstract ObjectPool, Made as generic as possible
    /// </summary>
    public abstract class ObjectPool
    {
        /// <summary>
        /// List of all active gameObjects 
        /// </summary>
        public List<GameObject> Active { get; set; } = new List<GameObject>(); 

        /// <summary>
        /// List of all previously active gameObjects, this is where the pool will 'pull' from 
        /// </summary>
        public Stack<GameObject> Inactive { get; set; } = new Stack<GameObject>();

        /// <summary>
        /// Provides a new gameObject
        /// </summary>
        /// <returns>Either a gO from the stack if it has any, or creates a new one</returns>
        public GameObject GetObject() 
        {
            if (Inactive.Count == 0)
            {
                GameObject newGO = CreateObject();
                Active.Add(newGO);
                return newGO;
            }

            GameObject go = Inactive.Pop();
            Active.Add(go);
            return go;
        }

        public void ReleaseObject(GameObject gameObject)
        {
            Active.Remove(gameObject);
            Inactive.Push(gameObject);
        }

        protected abstract GameObject CreateObject();


    }
}
