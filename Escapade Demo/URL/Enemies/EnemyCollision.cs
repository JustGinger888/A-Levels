using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URL.Enemies;
using URL.BULLET;

namespace URL.Enemies
{
    class EnemyCollision : Enemy
    {    
        public bool EnemyCollide()
        {
            if (Bullets._bulletSectionMap[_yEnemyPositionMap, _xEnemyPositionMap] == 'B')
            {
                _enemyHealth --;
                MainGame._enemyCollided = true;
            }
            return MainGame._enemyCollided;
        }        
    }
}
