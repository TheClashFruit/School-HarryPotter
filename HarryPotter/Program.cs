using System.Globalization;
using HarryPotter.Serializables;
using HarryPotter.Util;

namespace HarryPotter;

internal class Program {
    private static List<Spell> _spells = null!;
    private static List<Character> _characters = null!;

    private static readonly Database _db = new();

    public static void Main(string[] args) {
        Console.WriteLine("Hello, World!");

        //db.CreateTables();
        _db.TruncateTables();

        _spells = CsvReader.Read<Spell>(
            "Assets/HP_spells.csv",
            new Dictionary<string, Func<string, (string, object)?>> {
                { "spell", spell => ("Name", spell.Trim('"').Trim()) },
                { "use", use => ("Use", use.Trim('"').Trim()) }, {
                    "index",
                    d => {
                        if (int.TryParse(d.Trim('"').Trim(), CultureInfo.InvariantCulture, out var index))
                            return ("Index", index + 1);
                        return null;
                    }
                }
            },
            @",(?! )"
        );

        _characters = CsvReader.Read<Character>(
            "Assets/HP_characters.csv",
            new Dictionary<string, Func<string, (string, object)?>> {
                {
                    "fullName",
                    name => ("FullName", name.Trim('"').Trim())
                }, {
                    "nickname",
                    nick => ("Nickname", nick.Trim('"').Trim())
                }, {
                    "hogwartsHouse",
                    hh => ("HogwartsHouse", hh.Trim('"').Trim())
                }, {
                    "interpretedBy",
                    ib => ("InterpretedBy", ib.Trim('"').Trim())
                }, {
                    "children",
                    c => {
                        var children = c.Trim('"').Trim().Split(';');

                        return ("Children", children.ToList());
                    }
                }, {
                    "image",
                    ib => ("Image", ib.Trim('"').Trim())
                }, {
                    "birthdate",
                    bd => {
                        if (DateTime.TryParse(bd.Trim('"').Trim(), CultureInfo.InvariantCulture, out var bdp))
                            return ("BirthDate", bdp);
                        return null;
                    }
                }, {
                    "index",
                    d => {
                        if (int.TryParse(d.Trim('"').Trim(), CultureInfo.InvariantCulture, out var index))
                            return ("Index", index + 1);
                        return null;
                    }
                }, {
                    "knownSpells",
                    c => {
                        var spells = c.Trim('"').Trim().Split(';');
                        var known = new List<int>();
                        try {
                            foreach (var spell in spells)
                                known.Add(_spells.First(s => s.Name == spell.Trim('"').Trim()).Index);
                        }
                        catch (Exception _) {
                            // ignored
                        }

                        return ("KnownSpells", known);
                    }
                }
            },
            @",(?! )"
        );

        foreach (var spell in _spells)
            _db.InsertSpell(spell);
        foreach (var character in _characters)
            _db.InsertCharacter(character);

        // Listázd a beolvasott karaktereket varázslataikkal és gyerekeikkel együtt a születési dátumuk
        // szerint csökkenő sorrendben.

        _characters.Sort((a, b) => b.BirthDate.CompareTo(a.BirthDate));
        foreach (var character in _characters) {
            Console.WriteLine($"{character.FullName} - {character.BirthDate}");

            Console.Write("  Varázslatok: ");
            var known = character.KnownSpells.Select(spell => _spells.First(s => s.Index == spell).Name);
            Console.WriteLine(string.Join(", ", known));

            Console.WriteLine($"  Gyerekek: {string.Join(", ", character.Children)}");
        }

        Console.WriteLine();

        // Írd ki a console-ra a legidősebb és a legatalabb karakter nevét (Legidősebb: {karakter teljes
        // neve}, Legatalabb: {karakter teljes neve})

        var min = _characters.MinBy(cc => cc.BirthDate)!;
        var max = _characters.MaxBy(cc => cc.BirthDate)!;

        Console.WriteLine($"Legidősebb: {min.FullName}, Legatalabb: {max.FullName}");

        Console.WriteLine();

        // Kérj be egy "becenevet" (nickname maző) és írasd ki az általa ismert varázslatokat és a
        // gyermekei nevét vesszővel elválasztva egy sorba (Varázslatai: {varázslat1, varázslat2,
        // varázslat3...}, Gyermekei: {gyermek_neve1, gyermek_neve2...}).

        Console.Write("Becenév: ");
        var nick = Console.ReadLine()!;

        var c = _characters.First(c => string.Equals(c.Nickname, nick, StringComparison.InvariantCultureIgnoreCase));
        var ck = c.KnownSpells.Select(spell => _spells.First(s => s.Index == spell).Name);
        Console.WriteLine($"Varázslatai: {{{string.Join(", ", ck)}}} Gyermekei: {{{string.Join(", ", c.Children)}}}");
    }
}