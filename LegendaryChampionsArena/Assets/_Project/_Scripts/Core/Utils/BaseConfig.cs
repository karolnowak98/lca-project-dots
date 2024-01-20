using System;
using UnityEngine;

namespace GlassyCode.LCA.Core.Utils
{
    public abstract class BaseConfig : ScriptableObject
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
    }
}