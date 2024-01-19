using System;
using UnityEngine;

namespace GlassyCode.LCA.Utility
{
    public abstract class BaseSettings : ScriptableObject
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
    }
}