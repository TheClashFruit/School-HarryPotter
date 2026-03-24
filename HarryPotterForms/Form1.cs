using HarryPotterForms.Serializables;
using HarryPotterForms.Util;

namespace HarryPotterForms;

public partial class Form1 : Form {
    private Database _db = Database.Instance;
    
    public Form1() {
        InitializeComponent();
        
        var characters = _db.GetCharacters();
        
        lvCharacters.FullRowSelect = true;
        lvCharacters.MultiSelect = false;
        
        foreach (var character in characters)
            lvCharacters.Items.Add(
                new ListViewItem([
                    character.Id.ToString(),
                    character.FullName,
                    character.Nickname,
                    character.HogwartsHouse,
                    character.BirthDate.ToString("yyyy-MM-dd")
                ]) {
                    Tag = character
                });
        
        lvCharacters.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
    }

    private void lvCharacters_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e) {
        if (!e.IsSelected) return;
        
        try {
            var character = (Character) e.Item!.Tag!;
            
            lbKnownSpells.Items.Clear();
            if (character.KnownSpells.Count == 0) {
                lbKnownSpells.Items.Add("(no spells)");
            } else {
                foreach (var spell in character.KnownSpells)
                    lbKnownSpells.Items.Add($"{spell.Name} — {spell.Use}");
            }
 
            lbChildren.Items.Clear();
            if (character.Children.Count == 0) {
                lbChildren.Items.Add("(no children)");
            } else {
                foreach (var child in character.Children)
                    lbChildren.Items.Add(child);
            }
 
            pbCharacterImage.Visible = false;
            if (string.IsNullOrWhiteSpace(character.Image)) return;
            try {
                pbCharacterImage.LoadAsync(character.Image);
                pbCharacterImage.Visible = true;
            } catch (Exception ex) {
                MessageBox.Show($"Could not load image:\n{ex.Message}",
                    "Image Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        } catch (Exception ex) {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnRefresh_Click(object sender, EventArgs e) {
        lvCharacters.Items.Clear();
        var characters = _db.GetCharacters();
        foreach (var character in characters)
            lvCharacters.Items.Add(
                new ListViewItem([
                    character.Id.ToString(),
                    character.FullName,
                    character.Nickname,
                    character.HogwartsHouse,
                    character.BirthDate.ToString("yyyy-MM-dd")
                ]) {
                    Tag = character
                });
        
        lvCharacters.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
    }

    private void btnLoadBooks_Click(object sender, EventArgs e) {
        var f2 = new BooksForm();
        f2.ShowDialog(this);
    }
}