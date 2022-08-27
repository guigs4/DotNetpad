namespace Engine.Models
{
	public class TextBoxModel
	{
		public int TabIndex { get; set; }
		public string? Content { get; set; } = "";
		public bool IsInternal { get; set; } = true;
	}
}
