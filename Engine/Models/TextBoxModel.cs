namespace Engine.Models
{
	public class TextBoxModel
	{
		public int TabIndex { get; set; }
		public string? Header { get; set; }
		public string? Content { get; set; } = "";
		public bool IsInternal { get; set; } = true;

		public TextBoxModel(int index, string header, string content = "", bool isInternal = true)
		{
			TabIndex = index;
			Header = header;
			Content = content;
			IsInternal = isInternal;
		}
	}
}
