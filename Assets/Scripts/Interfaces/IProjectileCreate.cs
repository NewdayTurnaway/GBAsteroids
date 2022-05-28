using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBAsteroids
{
    public interface IProjectileCreate
    {
        Ammunition CreateProjectile(WeaponType type);
    }
}
