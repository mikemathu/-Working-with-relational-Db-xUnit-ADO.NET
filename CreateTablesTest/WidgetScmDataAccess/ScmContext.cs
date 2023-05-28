using System.Collections.Generic;
using System.Data.Common;
using System.Reflection.PortableExecutable;

namespace WidgetScmDataAccess
{
    public class ScmContext
    {
        private DbConnection connection;
        public IEnumerable<PartType> Parts { get; private set; }
        public ScmContext(DbConnection conn)
        {
            connection = conn;
            ReadParts();
        }
        private void ReadParts()
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"SELECT Id, Name 1 FROM PartType";
                using (var reader = command.ExecuteReader()) //Output of command has multiple rows
                {
                    var parts = new List<PartType>();
                    Parts = parts;
                    while (reader.Read()) //Moves to next row, returns false if no more rows
                    {
                        parts.Add(new PartType() {Id = reader.GetInt32(0), Name = reader.GetString(1) });
                    }
                }
            }
        }
    }
}
