using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttackable
{
    void Attack();  // การโจมตีพื้นฐาน
    void Attack(string spellType);  // Method Overloading สำหรับการโจมตีด้วยคาถา
}
