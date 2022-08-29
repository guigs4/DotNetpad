namespace Engine.Models
{
	public class TabModel
	{
		public int TabIndex { get; set; }
		public string? Header { get; set; }
		public string? Content { get; set; } = "";
		public bool IsInternal { get; set; } = true;

		public TabModel(int index, string header, string content = "", bool isInternal = true)
		{
			TabIndex = index;
			Header = header;
			Content = content;
			IsInternal = isInternal;
		}

		public TabModel(int index)
		{
			TabIndex = index;
			Header = $"Tab {index}";
			Content = "";
			IsInternal = true;
		}
	}
}
