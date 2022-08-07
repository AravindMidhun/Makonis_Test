using System;
using System.Collections.Generic;
using System.Text;

namespace Makonis.Contracts.Interfaces
{
    public interface IFileHelper
    {
        List<T> ReadFile<T>() where T : class;
        void WriteFile(string data);
    }
}
