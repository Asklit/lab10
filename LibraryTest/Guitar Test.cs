using Musical_Instrument;

namespace Guitar_Test
{
    public class UnitTest1
    {
        /// <summary>
        /// Сравнение разных способов создания объектов
        /// </summary>
        [Fact]
        public void CheckDifferentConstructions()
        {
            Guitar guitar1 = new Guitar();
            Guitar guitar2 = new Guitar("Guitar", 0, -1);
            Assert.Equal(guitar1, guitar2);
        }

        /// <summary>
        /// Проверка метода Compare
        /// </summary>
        [Fact]
        public void CheckCompare()
        {
            Guitar guitar1 = new Guitar();
            Guitar guitar2 = new Guitar("Guitar", 0, -1);
            Assert.Equal(0, guitar1.CompareTo(guitar2));
        }

        /// <summary>
        /// Проверка метода Equals
        /// </summary>
        [Fact]
        public void CheckEquals()
        {
            Guitar guitar1 = new Guitar();
            Guitar guitar2 = new Guitar("Guitar", 0, -1);
            Assert.True(guitar1.Equals(guitar2));
        }

        /// <summary>
        /// Проверка копирования
        /// </summary>
        [Fact]
        public void CheckCopy()
        {
            Guitar guitar1 = new Guitar("Guitar", 0, 10);
            Guitar guitar2 = (Guitar)guitar1.ShallowCopy();
            guitar1.Id.Number = 10;
            Assert.Equal(guitar1, guitar2);
        }

        /// <summary>
        /// Проверка клонирования
        /// </summary>
        [Fact]
        public void CheckClone()
        {
            Guitar guitar1 = new Guitar("Guitar", 0, 10);
            Guitar guitar2 = (Guitar)guitar1.Clone();
            guitar1.Name = "Piano";
            Assert.NotEqual(guitar1, guitar2);
        }

        /// <summary>
        /// Проверка свойств
        /// </summary>
        [Fact]
        public void SetCountString()
        {
            Guitar guitar = new Guitar("Guitar", 0, 10);
            guitar.Id.Number = 10;
            guitar.CountString = 15;
            Assert.Equal(15, guitar.CountString);
            Assert.Equal(10, guitar.Id.Number);
        }

        /// <summary>
        /// Проверка на преобразование свойств
        /// </summary>
        [Fact]
        public void CheckCountStringArePositive()
        {
            Guitar guitar = new Guitar("Guitar", 0, -10);
            Assert.Equal(0, guitar.CountString);
        }
    }
}