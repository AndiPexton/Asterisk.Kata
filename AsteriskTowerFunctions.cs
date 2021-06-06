using System.Collections.Generic;
using System.Linq;

namespace Asterisk.Kata.Tests
{
    public static class AsteriskTowerFunctions
    {
        public static IEnumerable<string> CreateAsteriskTower(this int rows) =>
            rows == 0
                ? Enumerable
                    .Empty<string>()
                : Enumerable
                    .Range(1, rows)
                    .Select(row => row.ToAsterisks(rows));

        private static string ToAsterisks(this int row, int rows) =>
            GetAsterisksRow(
                rows.WidthOfBaseRow(),
                row.NumberOfAsterisks());

        private static string GetAsterisksRow(int width, int numberOfAsterisks) =>
            GetPaddingSpacesAndAsterisks(width, numberOfAsterisks)
                .BuildRowString();

        private static (string, string) GetPaddingSpacesAndAsterisks(int width, int numberOfAsterisks) =>
            (numberOfAsterisks.PaddingSpacesStringFor(width), numberOfAsterisks.AsterisksString());

        private static string BuildRowString(this (string spaces, string asterisks) elements) =>
            $"{elements.spaces}{elements.asterisks}{elements.spaces}";

        private static string AsterisksString(this int numberOfAsterisks) =>
            new string('*', numberOfAsterisks);

        private static string PaddingSpacesStringFor(this int numberOfAsterisks, int width) =>
            new string(' ', numberOfAsterisks.PaddingFor(width));

        private static int PaddingFor(this int numberOfAsterisks, int width) =>
            (width - numberOfAsterisks) / 2;

        private static int WidthOfBaseRow(this int rows) =>
            rows * 2 - 1;

        private static int NumberOfAsterisks(this int row) =>
            row * 2 - 1;
    }
}