using Assets.Mine.Scripts.Gameplay.Factory;
using Assets.Mine.Scripts.Gameplay.GridSystem;
using Assets.Mine.Scripts.Utils;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Assets.Mine.Scripts.Gameplay.Unit
{
    public class UnitDragPresenter : VObject<UnitContext>, IStartable
    {
        [Inject] private readonly GridSystem.Grid _grid;
        [Inject] private readonly UnitFactory _factory;

        void IStartable.Start()
        {
            if(Context.isByMerge == false)
                Place();
            InitalizeView();
        }

        private void Clear()
        {
            if(Context.LocatedCell != null)
            {
                Context.LocatedCell.PlacedUnit = null;
                Context.LocatedCell = null;
            }
        }

        private void Place()
        {
            Clear();

            Cell emptyCell = _grid.GetFirstEmpty();
            Context.transform.position = emptyCell.transform.position;
            emptyCell.PlacedUnit = Context;
            Context.LocatedCell = emptyCell;
        }

        private void Place(Cell cell)
        {
            Clear();

            Context.transform.position = cell.transform.position;
            cell.PlacedUnit = Context;
            Context.LocatedCell = cell;
        }

        private void InitalizeView()
        {
            Vector3 delta = Vector3.zero;

            Context.OnMouseDownAsObservable()
            .Subscribe(_ => 
            {
                if(Context.gameObject != null)
                {
                    Vector3 camPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    camPos.z = 0f;
                    Vector3 unitPos = Context.transform.position;
                    unitPos.z = 0f;
                }
            }).AddTo(Context.gameObject);

            Context.OnMouseDragAsObservable()
            .Subscribe(_ => 
            {
                Vector3 camPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                camPos.z = 0f;
                Context.transform.position = camPos - delta;
            }).AddTo(Context.gameObject);

            Context.OnMouseUpAsObservable()
            .Subscribe(_ => 
            {
                UnitContext first = Context;
                Cell closest = _grid.GetClosest(Context.transform.position);
                UnitContext second = closest.PlacedUnit;

                if(closest == first.LocatedCell)
                {
                    Place(closest);
                    return;
                }

                if(second == null)
                {
                    Place(closest);
                }
                else
                {
                    if(_grid.CanMerge(first, second))
                    {
                        Vector3 secondCellPosition = second.LocatedCell.transform.position;
                        var unit = _factory.CreateByMerge(first, second);
                        Clear();
                        unit.transform.position = secondCellPosition;
                        unit.LocatedCell = closest;
                        closest.PlacedUnit = unit;   
                    }
                    else
                    {
                        Place(_grid.GetClosestEmpty(Context.transform.position));
                    }
                }
            }).AddTo(Context.gameObject);
        }
    }
}

