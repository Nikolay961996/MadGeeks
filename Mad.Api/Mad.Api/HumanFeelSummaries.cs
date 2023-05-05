using Mad.Api.Controllers;

namespace Mad.Api
{
    public class HumanFeelSummaries
    {
        public int CalculateIndex(int temperature)
        {
            double index;
            // Для определения ощущений температуры взята средняя статистика от -40 до +40. Работает с любой температурой которую
            // получает эта функция. Все что ниже -40 будет считаться "Freezing", всё что выше +40 будет считаться "Scorching"
            index = (temperature - (-40)) / 80.0 * 9;

            // Корректировка если индекс получился больше 9 или меньше 0
            index = Math.Max(Math.Min(9, index), 0);

            return (int)index;
        }
    }
}
