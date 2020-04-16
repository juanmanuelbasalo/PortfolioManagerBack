using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common.Services
{
    /// <summary>
    /// <c>IServiceHost</c> Interface with the <c>Run()</c> method, that helps to run our custom Service Host.
    /// </summary>
    public interface IServiceHost
    {
        /// <summary>
        /// Method to Run our custom Service Host.
        /// </summary>
        /// <returns> Empty Task </returns>
        Task Run();
    }
}
