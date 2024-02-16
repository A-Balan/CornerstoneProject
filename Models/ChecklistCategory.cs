namespace CornerstoneChecklist.Models
{
    public class ChecklistCategory
    {
        public string CategoryName { get; set; }
        public List<ChecklistItem> Items { get; set; }
    }
}
