using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterConfigurator.Model
{
    public abstract class Item : BaseModel
    {
        public string PathImage { get; protected set; }
    }
}
