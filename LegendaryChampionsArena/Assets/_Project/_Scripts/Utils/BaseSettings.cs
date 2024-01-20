using System;
using UnityEngine;

namespace GlassyCode.LCA.Utils
{
    public abstract class BaseSettings : ScriptableObject
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
    }
}