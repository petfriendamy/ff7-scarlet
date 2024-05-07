using FF7Scarlet.AIEditor;

namespace FF7Scarlet.SceneEditor
{
    public class Formation : AIContainer
    {
        public const int AI_BLOCK_SIZE = 504, ENEMY_COUNT = 6;
        private readonly EnemyLocation[] enemyLocations = new EnemyLocation[ENEMY_COUNT];

        public BattleSetupData BattleSetupData { get; }
        public CameraPlacementData CameraPlacementData { get; }
        public EnemyLocation[] EnemyLocations
        {
            get { return enemyLocations; }
        }

        public Formation(Scene parent) :base(parent)
        {
            BattleSetupData = new BattleSetupData();
            CameraPlacementData = new CameraPlacementData();
            for (int i = 0; i < ENEMY_COUNT; ++i)
            {
                EnemyLocations[i] = new EnemyLocation();
            }
        }

        public Formation(Scene parent, BattleSetupData setupData, CameraPlacementData cameraData,
            EnemyLocation[] enemyLocations) :base(parent)
        {
            BattleSetupData = setupData;
            CameraPlacementData = cameraData;
            Array.Copy(enemyLocations, EnemyLocations, ENEMY_COUNT);
        }
    }
}
