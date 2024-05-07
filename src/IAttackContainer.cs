using FF7Scarlet.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF7Scarlet
{
    public interface IAttackContainer
    {
        public Attack? GetAttackByID(ushort id);
        public string GetAttackName(ushort id);
    }
}
