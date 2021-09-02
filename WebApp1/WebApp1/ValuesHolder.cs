using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp1
{
    public class ValuesHolder
    {
        public List<Values> valuesHolderList = new List<Values>();

        // Функция Add предназначения для вставки элемента
        public void Add(Values value)
        {
            valuesHolderList.Add(value);
        }

        // Функция Put предназначения для изменения значения
        // В соответствии с заданным временем
        public void Put(Values value)
        {
            foreach (Values vs in valuesHolderList)
            {
                if (vs.Date.CompareTo(value.Date) == 0) vs.Temperature = value.Temperature;
            }
        }

        // Функция Del предназначения для удаления элементов
        // В соответствии с заданным интервалом
        public void Del(DateTime start, DateTime finish)
        {
            valuesHolderList.RemoveAll(
                (Values v) =>
                {
                    if (v.Date.CompareTo(start) >= 0 && v.Date.CompareTo(finish) <= 0) return true;
                    else return false;
                }
            );
        }

        // Функция Sort предназначения для выдачи списка
        // Отсортированного в соответствии с заданным интервалом
        public IEnumerable<Values> Sort(DateTime start, DateTime finish)
        {
            var query = from val in valuesHolderList
                        where val.Date.CompareTo(start) >= 0 && val.Date.CompareTo(finish) <= 0
                        select val;
            return query;
        }
    }
}