using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{

    interface ICalculator
    {
        double calculateTDEE(double weight, double height, int age, bool isMale);
        double calculateCalorieNorm(double TDEE, bool loseWeight, bool isMale, int weeks, double weightChangeKg);
        

    }

    internal class Calculator : ICalculator
    {

        public double calculateTDEE(double weight, double height, int age, bool isMale)
        {
            double TDEE;
            if (isMale)
            {
                TDEE = 10 * weight + 6.25 * height - 5 * age + 5;
            }
            else
            {
                TDEE = 10 * weight + 6.25 * height - 5 * age - 161;

            }

            return TDEE;

        }

           private const double MIN_CALORIES_MALE = 1500;  // Минимальная безопасная норма для мужчин
            private const double MIN_CALORIES_FEMALE = 1200; // Минимальная безопасная норма для женщин
            private const double CALORIES_PER_KG = 7700;  // Калорий в 1 кг веса
            private const double MAX_SAFE_DEFICIT = 1000; // Максимальный безопасный дефицит/профицит калорий в день

            public int actualWeeks { get; private set; }   // Реальное количество недель

       public double calculateCalorieNorm(double TDEE, bool loseWeight, bool isMale, int weeks, double weightChangeKg)
        
            {
                

                double minCalories = isMale ? MIN_CALORIES_MALE : MIN_CALORIES_FEMALE;
                double calorieChangePerDay = ((weightChangeKg) * CALORIES_PER_KG) / (weeks * 7);
                double calorieNorm = loseWeight ? TDEE - calorieChangePerDay : TDEE + calorieChangePerDay;

                // Проверяем, если норма калорий опустилась ниже безопасного минимума
                if (calorieNorm < minCalories)
                {
                    // Рассчитываем минимально возможное время с безопасным дефицитом
                    double maxCalorieChangePerDay = Math.Min(TDEE - minCalories, MAX_SAFE_DEFICIT);
                    actualWeeks = (int)Math.Ceiling((weightChangeKg * CALORIES_PER_KG) / (maxCalorieChangePerDay * 7));
                    actualWeeks = Math.Max(actualWeeks, 1); // Минимум 1 неделя

                    // Пересчитываем норму калорий
                    calorieChangePerDay = (weightChangeKg * CALORIES_PER_KG) / (actualWeeks * 7);
                    calorieNorm = loseWeight ? TDEE - calorieChangePerDay : TDEE + calorieChangePerDay;
                }
                else
                {
                    actualWeeks = weeks;
                }

                return Math.Max(calorieNorm, minCalories);
            }
        



    }
}
