using CharacterConfigurator.Model.DbEnum;
using MySql.Data.MySqlClient;

namespace CharacterConfigurator.Model
{
    public interface IBaseModel<T> where T : IBaseModel<T>
    {
        int Id { get; set; }

        static abstract ModelTypeDb DbModel { get; }

        string Name { get; set; }

        void SetAttributes(MySqlDataReader sqlResult);
    }
}
