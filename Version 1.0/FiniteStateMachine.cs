using System.Collections.Generic;

public class FiniteStateMachine<Enum>
{
    private     IState                      _currentState;
    private     Dictionary<Enum, IState>    _allStates      = new Dictionary<Enum, IState>();

    public IState CurrentState()
    {
        return _currentState;
    }

    public void AddState(Enum name, IState action) //Al inicializar la lista se deberá agregar al diccionario una clase IState con su Enum caracteristico
    {
        if (_allStates.ContainsKey(name))
        {
            return; //Si existe el Enum no hace nada
        }
        else
        {
            _allStates.Add(name, action); //Si no existe el Enum lo agrega al diccionario junto con la clase de IState
        }
    }

    public void ChangeState(Enum name)
    {
        if (_allStates.ContainsKey(name))
        {
            _currentState?.OnExit(); //el ? pregunta si es null
            _currentState = _allStates[name];
            _currentState.OnEnter();
        }
        else
        {
            return;
        }
    }
}