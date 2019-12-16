using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using System.Collections.Generic;

namespace YandexTaxiScraper
{
    public class CompanyFactory
    {
        private Dictionary<string, int> _cellIndices = new Dictionary<string, int>();

        public CompanyFactory(IHtmlCollection<IElement> tableHeaderCellValues)
        {
            for (int cellIndex = 0; cellIndex < tableHeaderCellValues.Length; cellIndex++)
            {
                string cellName = tableHeaderCellValues[cellIndex].TextContent.Trim();
                _cellIndices.Add(cellName, cellIndex);
            }
        }

        public Company Create(IHtmlTableRowElement row, string city)
        {
            return new Company
            {
                Name = GetCellValue(row, TableHeaderCellValues.Name),
                Phone = GetCellValue(row, TableHeaderCellValues.Phone),
                City = city,
                Address = GetCellValue(row, TableHeaderCellValues.Address),
                WorkingTime = GetCellValue(row, TableHeaderCellValues.WorkingTime),
                Email = GetCellValue(row, TableHeaderCellValues.Email)
            };
        }

        private string GetCellValue(IHtmlTableRowElement row, IEnumerable<string> cellNames)
        {
            foreach (string cellName in cellNames)
            {
                if (!_cellIndices.ContainsKey(cellName))
                {
                    continue;
                }

                int cellIndex = _cellIndices[cellName];
                IHtmlTableCellElement cell = row.Cells[cellIndex];
                IElement paragraph = cell.QuerySelector("p");
                if (paragraph != null)
                {
                    string cellValue = paragraph.TextContent.Trim();
                    if (!string.IsNullOrEmpty(cellValue))
                    {
                        return cellValue;
                    }
                }

                break;
            }

            return null;
        }

        private static class TableHeaderCellValues
        {
            public static readonly List<string> Name = new List<string>
            {
                "Парк",
                "Название парка"
            };

            public static readonly List<string> Phone = new List<string>
            {
                "Номер телефона"
            };

            public static readonly List<string> Email = new List<string>
            {
                "Почта"
            };

            public static readonly List<string> Address = new List<string>
            {
                "Адрес"
            };

            public static readonly List<string> WorkingTime = new List<string>
            {
                "Работает"
            };
        }
    }
}
