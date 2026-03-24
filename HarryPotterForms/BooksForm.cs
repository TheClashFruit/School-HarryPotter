using System.Text.Json;
using HarryPotterForms.Serializables;

namespace HarryPotterForms;

public partial class BooksForm : Form {
    private static readonly HttpClient _http  = new();
    private const           string     ApiUrl = "https://potterapi-fedeperin.vercel.app/en/books";
    
    private List<Book> _books = new();
    
    public BooksForm() {
        InitializeComponent();
    }


    private async  void btnDownloadBooks_Click(object sender, EventArgs e) {
        btnDownloadBooks.Enabled = false;
        btnDownloadBooks.Text    = "…";
 
        try {
            string json = await _http.GetStringAsync(ApiUrl);
 
            _books = JsonSerializer.Deserialize<List<Book>>(json)
                     ?? new List<Book>();
 
            dgvBooks.DataSource = null;
            dgvBooks.DataSource = _books;
        }
        catch (Exception ex) {
            MessageBox.Show($"Error:\n{ex.Message}",
                "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
        } finally {
            btnDownloadBooks.Enabled = true;
            btnDownloadBooks.Text    = "(Re)Load Data";
        }
    }

    private void dgvBooks_SelectionChanged(object sender, EventArgs e) {
        if (dgvBooks.CurrentRow?.DataBoundItem is not Book book) {
            lbDescription.Text = string.Empty;
            pbCover.Image      = null;
            return;
        }
 
        lbDescription.Text       = book.Description;
        pbCover.Visible = false;
        if (string.IsNullOrWhiteSpace(book.Cover)) return;
        try {
            pbCover.LoadAsync(book.Cover);
            pbCover.Visible = true;
        } catch (Exception ex) {
            MessageBox.Show($"Could not load image:\n{ex.Message}",
                "Image Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }
    }
}