using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAbility {

    public void ExecuteAbility();
}


public interface ICastableAbility : IAbility
{
}

public interface IProcAbility : IAbility 
{ 
}


public interface ITransformAbility : IAbility 
{
}