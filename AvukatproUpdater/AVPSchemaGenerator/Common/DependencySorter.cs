using System.Collections.Generic;

namespace AVPSchemaGenerator.Common
{
    public static class DependencySorter<T>
    {
        #region Methods

        public static IEnumerable<T> Sort(Dictionary<T, IEnumerable<T>> dependencies)
        {
            var visited = new Dictionary<T, bool>();

            foreach (var key in dependencies.Keys)
            {
                visited[key] = false;
            }

            foreach (var key in dependencies.Keys)
            {
                foreach (var ordered in Search(key, dependencies, visited))
                    yield return ordered;
            }
        }

        private static IEnumerable<T> Search(
            T key,
            IDictionary<T, IEnumerable<T>> dependencies,
            IDictionary<T, bool> visited
            )
        {
            if (!visited[key])
            {
                visited[key] = true;

                foreach (T value in dependencies[key])
                {
                    foreach (var ordered in Search(value, dependencies, visited))
                    {
                        yield return ordered;
                    }
                }

                yield return key;
            }
        }

        #endregion Methods
    }
}