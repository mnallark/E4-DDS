namespace Fire_Emblem_Controller;
using Fire_Emblem_Model;
using Fire_Emblem_View;

public class AttackExecutionController
{
    private readonly IFireEmblemView _view;
    private readonly Unit _unitAttacking;
    private readonly Unit _unitDefending;
    private const int _minParameter = 0;

    public AttackExecutionController(IFireEmblemView view, Unit unitAttacking)
    {
        _view = view;
        _unitAttacking = unitAttacking;
        _unitDefending = unitAttacking.Opponent;
    }
    
    public void ExecuteAttack()
    {
        _view.ShowAttackInfo(_unitAttacking, _unitDefending);
        ExecuteAttackProcedures();
    }
    
    private void ExecuteAttackProcedures()
    {
        ReceiveDamage();
        _unitAttacking.FirstAttackCommitted();
        CheckUnitDies();
        CheckHpRecovery();
    }
    
    private void ReceiveDamage()
    {
        _unitDefending.HP = Math.Max(_minParameter, _unitDefending.HP - _unitAttacking.Damage);
    }
    
    private void CheckUnitDies()
    {
        if (!_unitDefending.IsAlive())
            RemoveUnitIfDies();
    }
    
    private void RemoveUnitIfDies()
    {
        _unitDefending.Owner.RemoveUnit(_unitDefending);
    }

    private void CheckHpRecovery()
    {
        HpRecoveryController hpRecoveryController = new(_view, _unitAttacking);
        hpRecoveryController.ProcessHpRecovery();
    }
}