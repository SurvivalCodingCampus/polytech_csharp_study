namespace CsharpStudy.Debug;

public class YukymController
{
    string nowDate = DateTime.Now.ToString("yyyy-MM-dd"); // nowDate = "2025-08-25" 

    private string nowTime;

    public string GetTyA()
    {
        List<YukymTimeModel> timeDataOne = _GetTimeDataOne(nowDate);

        if (timeDataOne.Any()) // timeDataOne 리스트에 하나라도 원소 있으면 true 
        {
            nowTime = timeDataOne.First().Ty1;

            string month = nowDate.Substring(5, 2); // month = "08" 

            if (month == "01" || month == "02")
            {
                return "경오1국";
            }
            else if (month == "03" || month == "04")
            {
                return "경오2국";
            }
            else if (month == "05" || month == "06")
            {
                return "경오3국";
            }
            else if (month == "07" || month == "08")
            {
                return "경오4국";
            }
            else if (month == "09" || month == "10")
            {
                return "경오5국";
            }
            else if (month == "11" || month == "12")
            {
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
        List<YukymTimeModel> timeDataOne = _GetTimeDataOne(nowDate); // "08" 
        string result = timeDataOne.First().Ty12; // result = "갑자12국"

        DateTime nowTime = DateTime.Now; // nowTime =  날짜+시간 변수에 저장 

        if (nowTime.Hour >= 0 && nowTime.Hour < 2) // Hour : 0-23시  > && > '이면서'로 변경 
        {
            return timeDataOne.First().Ty1; // 0-1시  > 
        }
        else if (nowTime.Hour >= 4 && nowTime.Hour < 6)
        {
            return timeDataOne.First().Ty2;
        }
        else if (nowTime.Hour >= 6 && nowTime.Hour < 8)
        {
            return timeDataOne.First().Ty3;
        }
        else if (nowTime.Hour >= 8 && nowTime.Hour < 10)
        {
            return timeDataOne.First().Ty4;
        }
        else if (nowTime.Hour >= 10 && nowTime.Hour < 12)
        {
            return timeDataOne.First().Ty5;
        }
        else if (nowTime.Hour >= 12 && nowTime.Hour < 14)
        {
            return timeDataOne.First().Ty6;
        }
        // else if (nowTime.Hour >= 14 || nowTime.Hour < 16) // 14 -16 사이가 비어 있어서 추가
        // {
        //     return timeDataOne.First().Ty7; // Ty7 추가 
        // }
        else if (nowTime.Hour >= 16 && nowTime.Hour < 18)
        {
            return timeDataOne.First().Ty7; // Ty8로 변경 
        }
        else if (nowTime.Hour >= 18 && nowTime.Hour < 20)
        {
            return timeDataOne.First().Ty8; // Ty9로 변경 
        }
        else if (nowTime.Hour >= 20 && nowTime.Hour < 22)
        {
            return timeDataOne.First().Ty9; // Ty10로 변경 
        }
        else if (nowTime.Hour >= 22 && nowTime.Hour < 24)
        {
            return timeDataOne.First().Ty10; // // Ty11로 변경 
        }

        return result;
    }

    private List<YukymTimeModel> _GetTimeDataOne(string nowDate) // nowDate = "08"
    {
        List<YukymTimeModel> timeDataOne = new List<YukymTimeModel>();
        for (int i = 0; i < 24; i++) // 24번 반복 
        {
            timeDataOne.Add(new YukymTimeModel()); // timeDataOne[0] - timeDataOne[23] 접근 가능 
        }

        return timeDataOne;
    }
}