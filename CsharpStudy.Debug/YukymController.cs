using CsharpStudy.Debug;

public class YukymController
{
    string nowDate = DateTime.Now.ToString("yyyy-MM-dd");

    private string nowTime;

    public string GetTyA()
    {
        List<YukymTimeModel> timeDataOne = _GetTimeDataOne(nowDate);

        if (timeDataOne.Any())
        {
            nowTime = timeDataOne.First().Ty1;
            
            string month = nowDate.Substring(5, 2); 

            if (month == "01" || month == "02") {
                return "경오1국";
            } else if (month == "03" || month == "04") {
                return "경오2국";
            } else if (month == "05" || month == "06") {
                return "경오3국";
            } else if (month == "07" || month == "08") {
                return "경오4국";
            } else if (month == "09" || month == "10") {
                return "경오5국";
            } else if (month == "11" || month == "12") {
                return "경오6국";
            }
            return nowTime;
        }
        else
        {
            return "경오7국";
        }
    }

    public string GetTyB()
    {
        List<YukymTimeModel> timeDataOne = _GetTimeDataOne(nowDate);
        string result = timeDataOne.First().Ty12;

        DateTime nowTime = DateTime.Now;
        
        if (nowTime.Hour < 2) {
            return timeDataOne.First().Ty1;
        } else if (nowTime.Hour >= 2 && nowTime.Hour < 4) {
            return timeDataOne.First().Ty2;
        } else if (nowTime.Hour >= 4 && nowTime.Hour < 6) {
            return timeDataOne.First().Ty3;
        } else if (nowTime.Hour >= 6 && nowTime.Hour < 8) {
            return timeDataOne.First().Ty4;
        } else if (nowTime.Hour >= 8 && nowTime.Hour < 10) {
            return timeDataOne.First().Ty5;
        } else if (nowTime.Hour >= 10 && nowTime.Hour < 12) {
            return timeDataOne.First().Ty6;
        } else if (nowTime.Hour >= 12 && nowTime.Hour < 14) {
            return timeDataOne.First().Ty7;
        } else if (nowTime.Hour >= 14 && nowTime.Hour < 16) {
            return timeDataOne.First().Ty8;    
        } else if (nowTime.Hour >= 16 && nowTime.Hour < 18) {
            return timeDataOne.First().Ty9;
        } else if (nowTime.Hour >= 18 && nowTime.Hour < 20) {
            return timeDataOne.First().Ty10;
        } else if (nowTime.Hour >= 20 && nowTime.Hour < 22) {
            return timeDataOne.First().Ty11;
        
        }

        return result;
    }

    private List<YukymTimeModel> _GetTimeDataOne(string nowDate)
    {
        List<YukymTimeModel> timeDataOne = new List<YukymTimeModel>();
        for (int i = 0; i < 24; i++)
        {
            timeDataOne.Add(new YukymTimeModel());
        }
        return timeDataOne;
    }
}