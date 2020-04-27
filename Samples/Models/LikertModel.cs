
using System.Collections.Generic;
using System.Linq;

namespace Samples.Models
{
    public class LikertModel
    {
        public LikertModel(string[] columns, string[] questions)
        {
            Scale = columns.Select((v, i) => new KeyValuePair<int, string>(i + 1, v)).ToList();
            Rows = questions.Select((v) => new LikertRow(v, columns.Count())).ToList();
        }

        public LikertModel(int columns, string[] Questions)
        {
            Scale = new List<KeyValuePair<int, string>>();

           for (int i = 1; i < columns; i++)
            {
                Scale.Add(new KeyValuePair<int, string>(i, i.ToString()));
            }
            Rows = Questions.Select((v) => new LikertRow(v, columns)).ToList();
        }

        public List<KeyValuePair<int, string>> Scale { get; set; }
        public List<LikertRow> Rows { get; set; }


    }

    public class LikertRow
    {
        public LikertRow(string question, int range)
        {
            Question = question;
            Range = range;
        }

        public string Question { get; set; }
        public decimal Answer { get; set; }
        public decimal Range { get; set; }
        public decimal CalculatedValue
        {
            get
            {
                if (Range != 0 && Answer != 0)
                {
                    var x = Range / Answer;
                    return Range / Answer;
                }
                return 0;
            }
        }

    }
}
