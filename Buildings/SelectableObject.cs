using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectableObject : Singleton<SelectableObject>
{

    public virtual void Select()
    {

    }

    public virtual void Deselect()
    {

    }

    #region MarketTaxes
    public virtual float GetCurrentGoldFromMarket()=>0;
    public virtual float GetCurrentGoldCapacity() => 0;
    #endregion
}
