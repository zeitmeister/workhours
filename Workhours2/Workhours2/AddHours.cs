using System;
using UIKit;
namespace Workhours2
{
    public class AddHours
    {
        public string ToNumber(string raw, string minutes)
        {
            bool checker = false;
            int hoursCounter = 0;
            int minutesCounter = 0;

            string[] splitted = raw.Split(new char[] { ' ', ',', '.' }, StringSplitOptions.RemoveEmptyEntries);
            int[] hoursArray = new int[splitted.Length];

            for (int i = 0; i < splitted.Length; i++)
            {
                if (int.TryParse(splitted[i], out hoursArray[i]))
                    hoursArray[i] = Convert.ToInt32(splitted[i]);
                else
                {

                    UIAlertView alert = new UIAlertView()
                    {
                        Title = "Wrong hour input",
                        Message = "You can only type numbers"
                    };
                    alert.AddButton("OK");
                    alert.Show();
                    checker = true;
                    break;
                }
            }

            for (int i = 0; i < hoursArray.Length; i++)
            {
                hoursCounter += hoursArray[i];
            }

            string[] splitted2 = minutes.Split(new char[] { ' ', ',', '.' }, StringSplitOptions.RemoveEmptyEntries);
            int[] minutesArray = new int[splitted2.Length];
            for (int i = 0; i < splitted2.Length; i++)
            {
                if (int.TryParse(splitted2[i], out minutesArray[i]) && minutesArray[i] < 60)
                    minutesArray[i] = Convert.ToInt32(splitted2[i]);
                else
                {
                    UIAlertView alert = new UIAlertView()
                    {
                        Title = "Wrong minutes input",
                        Message = "You can only type numbers and the minutes can't exceed 59"
                    };
                    alert.AddButton("OK");
                    alert.Show();
                    checker = true;
                    break;
                }

            }


            for (int i = 0; i < minutesArray.Length; i++)
            {
                minutesCounter += minutesArray[i];
            }

            while (minutesCounter / 60 > 0)
            {
                hoursCounter++;
                minutesCounter -= 60;
            }
            if (checker == false)
            {
                return hoursCounter.ToString() + " hours and " + minutesCounter.ToString() + " minutes.";
            }
            else
            {
                return "";
            }

        }
    }

}
