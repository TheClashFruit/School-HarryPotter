namespace HarryPotterConsole.Serializables;

public class Character {
    public string FullName { get; set; }
    public string Nickname { get; set; }
    
    public string HogwartsHouse { get; set; }
    public string InterpretedBy { get; set; }
    
    public List<string> Children { get; set; }
    
    public string Image { get; set; }
    
    public DateTime BirthDate { get; set; }
    
    public int Index { get; set; }
    
    public List<int> KnownSpells { get; set; }
}