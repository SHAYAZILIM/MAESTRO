using AvukatProLib2.Entities;
using System.Collections.Generic;
using TablesDatasConverter;

namespace RecordGenerator
{
    public static class TarafInfo
    {
        public static List<Taraf> GetTaraf(IEntity Record)
        {
            return TablesDatasConverter.TableTarafData.GetTaraf(Record);
        }

        public static void SetTaraf(List<Taraf> tarflar, IEntity Record)
        {
            TablesDatasConverter.TableTarafData.SetTaraf(tarflar, Record);
        }
    }
}