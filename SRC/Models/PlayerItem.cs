namespace VRCWMT.Models;
public class PlayerItem
{
    public string displayName { get; set; } = "";
    public string playerID { get; set; } = "";
    public DateTime added { get; set; } = DateTime.Now;
    public string addedBy { get; set; } = "";
}
