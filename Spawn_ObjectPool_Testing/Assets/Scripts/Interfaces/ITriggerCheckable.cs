using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITriggerCheckable
{
    bool IsWithinAttackRange { get; set; }
    bool IsAggroed { get; set; }

    void SetAttackRangeBool(bool isWithinAttackRange);
    void SetAggroStatus(bool isAggroed);
}
