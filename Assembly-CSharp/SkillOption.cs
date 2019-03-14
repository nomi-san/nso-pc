public class SkillOption
{
	public int param;

	public SkillOptionTemplate optionTemplate;

	public string optionString;

	public string getOptionString()
	{
		if (optionString == null)
		{
			if (optionTemplate.id == 62 || optionTemplate.id == 64 || optionTemplate.id == 70)
			{
				float num = (float)param / 1000f;
				optionString = NinjaUtil.replace(optionTemplate.name, "#", num + string.Empty);
			}
			else
			{
				optionString = NinjaUtil.replace(optionTemplate.name, "#", param + string.Empty);
			}
		}
		return optionString;
	}
}
