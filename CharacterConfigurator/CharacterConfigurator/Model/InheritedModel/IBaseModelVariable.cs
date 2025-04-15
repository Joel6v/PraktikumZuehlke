using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterConfigurator.Model.InheritedModel
{
    public interface IBaseModelVariable<T> where T : IBaseModel<T>
    {
        string GetAttributes();

        List<string> GetListAttributes();
    }
}
