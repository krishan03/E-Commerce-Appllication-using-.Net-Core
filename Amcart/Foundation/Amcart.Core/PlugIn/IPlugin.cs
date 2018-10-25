using System;
using System.Collections.Generic;
using System.Text;

namespace Amcart.Core.PlugIn
{
    /// <summary>
    /// Defines the contract for plugin implementations
    /// </summary>
    public interface IPlugin
    {
        string Name { get; }
    }
}
