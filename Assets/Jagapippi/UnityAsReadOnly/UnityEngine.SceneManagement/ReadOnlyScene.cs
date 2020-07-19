using System.Collections.Generic;
using UnityEngine.SceneManagement;

namespace Jagapippi.UnityAsReadOnly
{
    public readonly struct ReadOnlyScene
    {
        private readonly Scene _scene;

        public ReadOnlyScene(Scene scene)
        {
            _scene = scene;
        }

        #region Properties

        public int buildIndex => _scene.buildIndex;
        public bool isDirty => _scene.isDirty;
        public bool isLoaded => _scene.isLoaded;
        public string name => _scene.name;
        public string path => _scene.path;
        public int rootCount => _scene.rootCount;

        #endregion

        #region Public Methods

        public IReadOnlyGameObject[] GetRootGameObjects()
        {
            var gameObjects = _scene.GetRootGameObjects();
            var readOnlyGameObjects = new IReadOnlyGameObject[gameObjects.Length];

            for (var i = 0; i < gameObjects.Length; i++)
            {
                readOnlyGameObjects[i] = gameObjects[i].AsReadOnly();
            }

            return readOnlyGameObjects;
        }

        public void GetRootGameObjects(List<IReadOnlyGameObject> rootGameObjects)
        {
            var gameObjects = _scene.GetRootGameObjects();

            if (rootGameObjects.Capacity < gameObjects.Length)
            {
                rootGameObjects.Capacity = gameObjects.Length;
            }

            for (var i = 0; i < gameObjects.Length; i++)
            {
                rootGameObjects[i] = gameObjects[i].AsReadOnly();
            }
        }

        public bool IsValid() => _scene.IsValid();

        #endregion

        #region Operators

        public static bool operator ==(ReadOnlyScene lhs, ReadOnlyScene rhs) => (lhs._scene == rhs._scene);
        public static bool operator !=(ReadOnlyScene lhs, ReadOnlyScene rhs) => !(lhs == rhs);
        public static bool operator ==(ReadOnlyScene lhs, Scene rhs) => (lhs._scene == rhs);
        public static bool operator !=(ReadOnlyScene lhs, Scene rhs) => !(lhs == rhs);
        public static bool operator ==(Scene lhs, ReadOnlyScene rhs) => (lhs == rhs._scene);
        public static bool operator !=(Scene lhs, ReadOnlyScene rhs) => !(lhs == rhs);

        public override bool Equals(object other)
        {
            if (other is Scene scene) return (_scene == scene);
            if (other is ReadOnlyScene readOnlyScene) return (_scene == readOnlyScene._scene);
            return false;
        }

        public override int GetHashCode() => _scene.GetHashCode();

        #endregion
    }

    public static class SceneExtensions
    {
        public static ReadOnlyScene AsReadOnly(this Scene self) => new ReadOnlyScene(self);
    }
}