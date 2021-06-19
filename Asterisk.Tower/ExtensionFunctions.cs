using System.Collections.Generic;
using System.Linq;
using Asterisk.Tower.Gateway;
using Dependency;

namespace Asterisk.Tower
{
    public static class ExtensionFunctions
    {
        private static char Brick => Shelf.RetrieveInstance<IConfig>().Brick;
        private static char Padding => Shelf.RetrieveInstance<IConfig>().Padding;

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
            new string(Brick, numberOfAsterisks);

        private static string PaddingSpacesStringFor(this int numberOfAsterisks, int width) =>
            new string(Padding, numberOfAsterisks.PaddingFor(width));

        private static int PaddingFor(this int numberOfAsterisks, int width) =>
            (width - numberOfAsterisks) / 2;

        private static int WidthOfBaseRow(this int rows) =>
            rows * 2 - 1;

        private static int NumberOfAsterisks(this int row) =>
            row * 2 - 1;
    }
}