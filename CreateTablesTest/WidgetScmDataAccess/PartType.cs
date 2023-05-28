namespace WidgetScmDataAccess
{
    public class PartType
    {
        public int Id { get; internal set; } //Don’t allow modifying the Id outside of this library
        public string Name { get; set; }
    }
}