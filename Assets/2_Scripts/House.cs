public class House
{
    public string tv = "전체공개";
    private string diary = "비공개";
    protected string secretKey = "비밀번호";
    public string GetDiary()
    {
        Driver driver = new Driver();
        //driver.movespeed = 1;
        return diary;
    }
}
