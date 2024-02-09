using Assets.Mine.Scripts.Gameplay.Unit;
using UnityEngine;

namespace Assets.Mine.Scripts.Gameplay.GridSystem
{
    public class Grid
    {
        public Cell[,] _grid;
        private int _width;
        private int _height;

        public void InitGrid(int x, int y)
        {
            _grid = new Cell[x,y];

            _width  = x;
            _height = y;
        }

        public void Fill(int x, int y, Cell cell)
        {
            _grid[x, y] = cell;
        }

        public Cell GetFirstEmpty()
        {
            for(int i = 0; i < _height; i++)
            {
                for(int j = 0; j < _width; j++)
                {
                    if(_grid[j, i].IsEmpty) 
                        return _grid[j, i];
                }
            }

            return null;
        }

        public bool IsFull()
        {
            for(int i = 0; i < _height; i++)
            {
                for(int j = 0; j < _width; j++)
                {
                    if(_grid[j, i].IsEmpty) 
                        return false;
                }
            }

            return true;
        }

        public Cell GetClosestEmpty(Vector3 position)
        {
            float distance = float.MaxValue;
            Cell cell = null;

            for(int i = 0; i < _height; i++)
            {
                for(int j = 0; j < _width; j++)
                {

                    if(_grid[j, i].IsEmpty == false)
                        continue;

                    Vector3 cellPosition = _grid[j, i].transform.position;
                    float temp = Vector3.Distance(position, cellPosition);

                    if(temp < distance)
                    {
                        distance = temp;
                        cell = _grid[j, i];
                    }
                }
            }

            return cell;
        }

        public Cell GetClosest(Vector3 position)
        {
            float distance = float.MaxValue;
            Cell cell = null;

            for(int i = 0; i < _height; i++)
            {
                for(int j = 0; j < _width; j++)
                {
                    Vector3 cellPosition = _grid[j, i].transform.position;
                    float temp = Vector3.Distance(position, cellPosition);

                    if(temp < distance)
                    {
                        distance = temp;
                        cell = _grid[j, i];
                    }
                }
            }

            return cell;
        }

        public bool CanMerge(UnitContext first, UnitContext second)
        {
            if(first.model.Score.Value != second.model.Score.Value)
                return false;

            return true;
        }
    }
}
