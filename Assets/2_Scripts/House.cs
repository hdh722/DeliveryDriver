public class House
{
    public string tv = "��ü����";
    private string diary = "�����";
    protected string secretKey = "��й�ȣ";
    public string GetDiary()
    {
        Driver driver = new Driver();
        //driver.movespeed = 1;
        return diary;
    }
}
