namespace NinetyOne
{
    using NinetyOne.Models;
    using System;
    using System.Collections.Generic;

    public static class CsvParser
    {
       
            public static List<Person> ParseCsv(string csvContent)
            {
                var people = new List<Person>();

                var lines = csvContent.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
                bool isHeader = true;

                foreach (var line in lines)
                {
                    if (isHeader)
                    {
                        isHeader = false;
                        continue;
                    }

                    var columns = line.Split(',');
                    if (columns.Length < 2) continue;

                    string firstName;
                    string secondName = ""; 
                    int score;

                    if (columns.Length == 3)
                    {
                        firstName = columns[0].Trim();
                        secondName = columns[1].Trim();
                        score = int.Parse(columns[2].Trim());
                    }
                    else
                    {
                        firstName = columns[0].Trim();
                        score = int.Parse(columns[1].Trim());
                    }

                    people.Add(new Person
                    {
                        FirstName = firstName,
                        SecondName = secondName,
                        Score = score
                    });
                }

                return people;
            }
        }
    }