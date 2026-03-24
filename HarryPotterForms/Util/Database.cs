using HarryPotterForms.Serializables;
using MySql.Data.MySqlClient;

namespace HarryPotterForms.Util;

public class Database : IDisposable {
    private static Database? _instance;
    public static Database Instance {
        get {
            _instance ??= new Database();
            return _instance;
        }
    }
    
    private static readonly MySqlConnection Connection =
        new("server=localhost;uid=schl;password=secure123;database=schl_harrypotter");
    
    private Database() {
        Connection.Open();
    }

        public List<Character> GetCharacters() {
        var characters = new Dictionary<int, Character>();
 
        // 1. Base character rows
        using (var cmd = new MySqlCommand(@"
            SELECT id, full_name, nickname, hogwarts_house,
                   interpreted_by, image, birthdate
            FROM   characters
            ORDER  BY id", Connection))
        using (var rdr = cmd.ExecuteReader()) {
            while (rdr.Read()) {
                var c = new Character {
                    Id            = rdr.GetInt32("id"),
                    FullName      = rdr.GetString("full_name"),
                    Nickname      = rdr.GetString("nickname"),
                    HogwartsHouse = rdr.GetString("hogwarts_house"),
                    InterpretedBy = rdr.GetString("interpreted_by"),
                    Image         = rdr.GetString("image"),
                    BirthDate     = rdr.GetDateTime("birthdate"),
                    Children      = new List<string>(),
                    KnownSpells   = new List<Spell>()
                };
                characters[c.Id] = c;
            }
        }
 
        // 2. Children
        using (var cmd = new MySqlCommand(@"
            SELECT character_id, name
            FROM   children", Connection))
        using (var rdr = cmd.ExecuteReader()) {
            while (rdr.Read()) {
                var charId = rdr.GetInt32("character_id");
                if (characters.TryGetValue(charId, out var c))
                    c.Children.Add(rdr.GetString("name"));
            }
        }
 
        // 3. Spells (via join table)
        using (var cmd = new MySqlCommand(@"
            SELECT cs.character_id, s.id, s.name, s.use
            FROM   character_spells cs
            JOIN   spells           s  ON s.id = cs.spell_id", Connection))
        using (var rdr = cmd.ExecuteReader()) {
            while (rdr.Read()) {
                var charId = rdr.GetInt32("character_id");
                if (characters.TryGetValue(charId, out var c))
                    c.KnownSpells.Add(new Spell {
                        Id   = rdr.GetInt32("id"),
                        Name = rdr.GetString("name"),
                        Use  = rdr.GetString("use")
                    });
            }
        }
 
        return characters.Values.ToList();
    }
    
    public void Dispose() {
        Connection.Dispose();
    }
}