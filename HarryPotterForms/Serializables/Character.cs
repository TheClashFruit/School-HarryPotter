namespace HarryPotterForms.Serializables;

public class Character {
    public int Id { get; set; }
    
    public string FullName { get; set; }
    public string Nickname { get; set; }
    
    public string HogwartsHouse { get; set; }
    public string InterpretedBy { get; set; }
    
    public List<string> Children    { get; set; }
    public List<Spell>  KnownSpells { get; set; }
    
    public string Image { get; set; }
    
    public DateTime BirthDate { get; set; }
}