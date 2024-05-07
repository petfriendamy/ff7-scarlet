using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF7Scarlet.SceneEditor
{
    public enum SearchType { Enemy, Formation }

    public class SceneSearchResult
    {
        public SearchType SearchType { get; }
        public int SceneIndex { get; }
        public int EnemyPosition { get; }
        public int FormationPosition { get; }

        public SceneSearchResult(SearchType searchType, int sceneIndex, int enemyPosition, int formationPosition)
        {
            SearchType = searchType;
            SceneIndex = sceneIndex;
            EnemyPosition = enemyPosition;
            FormationPosition = formationPosition;
        }
    }
}
