using Assets.Mine.Scripts.LevelSystem;
using UnityEngine;
using VContainer.Unity;

namespace Assets.Mine.Scripts.Gameplay.GridSystem
{
    public class GridInitializer : IStartable
    {
        private readonly Grid _grid;
        private readonly LevelContainer _levelContainer;
        private readonly Cell _prefab;

        //todo save system.
        public GridInitializer(Grid grid, LevelContainer container, Cell prefab)
        {
            _grid = grid;
            _levelContainer = container;
            _prefab = prefab;
        }

        public void Start()
        {
            InitGrid();
        }

        private void InitGrid()
        {
            int width  = _levelContainer.GetLevel(0).width;
            int height = _levelContainer.GetLevel(0).height;

            Debug.Log($"Width: {width} -- Height: {height}");

            const float size    = 0.90f;
            const float spacing = 0.05f;

            float xStart = (width - 1) * (size + spacing); //.25f spacing
            xStart = xStart / 2 * -1.0f;
            float yStart = (height - 1) * (size + spacing);
            yStart = yStart / 2 * -1.0f;

            Vector3 startPosition = new Vector3(xStart, yStart, 0f);
            float xRef = startPosition.x;
        
            GameObject gridParent = new GameObject("Grid");
            _grid.InitGrid(width, height);

            for(int i = 0; i < height; i++)
            {
                for(int j = 0; j < width; j++)
                {
                    //todo factory
                    Cell cell = UnityEngine.Object.Instantiate(_prefab);
                    cell.transform.position = startPosition;
                    cell.transform.parent = gridParent.transform;
                    cell.name = $"Cell x:{j} - y:{i}";

                    _grid.Fill(j, i, cell);

                    startPosition.x += size + spacing; //1f /*1f size*/ + 0.25f;
                }

                startPosition.x = xRef;
                startPosition.y += size + spacing; //1f + 0.25f;
            }
        }
    }
}
