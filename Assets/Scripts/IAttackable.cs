using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttackable
{
    void Attack();  // ������վ�鹰ҹ
    void Attack(string spellType);  // Method Overloading ����Ѻ������մ��¤Ҷ�
}
